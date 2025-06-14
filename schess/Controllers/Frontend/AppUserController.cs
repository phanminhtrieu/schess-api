using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCHESS.Application.Interfaces.System.AppUsers;
using SCHESS.Models.Systems;
using SCHESS.Models.Systems.AppUsers.Request;

namespace SCHESS.Controllers.Frontend
{
    public class AppUserController : BaseFrontendController
    {
        private readonly IAppUserService _userService;

        public AppUserController(IAppUserService appUserService)
        {
            _userService = appUserService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.Login(request);

            if (!result.IsSucceeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
