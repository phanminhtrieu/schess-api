using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCHESS.Application.Interfaces.Catalog.Emails;
using SCHESS.Application.Interfaces.System.AppUsers;
using SCHESS.Domain.Entity.System;
using SCHESS.Extensions;
using SCHESS.Models.Systems.AppUsers.Request;
using static SCHESS.Infrastructure.Constants.SystemConstants;

namespace SCHESS.Controllers.Frontend
{
    public class AppUsersController : BaseFrontendController
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IAppUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AppUsersController(UserManager<AppUser> userManager,
            IAppUserService appUserService,
            IConfiguration configuration,
            IEmailService emailService)
        {
            _userManager = userManager;
            _userService = appUserService;
            _configuration = configuration;
            _emailService = emailService;
        }

        /// <summary>
        /// Login user with username or email and password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.Login(request);

            if (!result.IsSucceeded) return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Register a new user with username, email and password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _userService.Register(request);

            if (!result.IsSucceeded) return BadRequest(result);

            var user = result.ResultObj;
            if (user is null) throw new Exception(ErrorMessage.INTERNAL_SERVER_ERROR);

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink = UrlExtension.EmailConfirmationLink(
                this.Url,
                user.Id,
                code,
                Request.Scheme);

            bool isConfirmationNull = string.IsNullOrEmpty(confirmationLink);
            if (!isConfirmationNull)
            {
                var sendEmailResult = await _emailService.SendEmailConfirmation(confirmationLink, user);
            }

            var loginRequest = new LoginRequest
            {
                Email = user.Email,
                Password = request.Password,
                RememberMe = true
            };

            var loginResult = await _userService.Login(loginRequest);

            bool canLogin = loginResult.IsSucceeded;
            if (!canLogin) return BadRequest(loginResult);

            return Ok(loginResult);
        }

        /// <summary>
        /// Confirm user's email with userId and code
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId is null || code is null)
            {
                return BadRequest();
            }

            // TODO: Add link page
            string redirectUrl = _configuration[PageLinks.CONFIRMATION_EMAIL_SUCCESS]!;

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new Exception($"Can't find user with id: {userId}");

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded) return BadRequest();

            return Redirect(redirectUrl);
        }
    }
}
