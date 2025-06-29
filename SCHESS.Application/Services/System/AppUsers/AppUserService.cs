using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCHESS.Application.Interfaces.Common;
using SCHESS.Application.Interfaces.System.AppUsers;
using SCHESS.Application.Interfaces.System.AuditLogins;
using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Domain.Entity.System;
using SCHESS.Models.Systems.AppRoles.Dto;
using SCHESS.Models.Systems.AppUsers.Dto;
using SCHESS.Models.Systems.AppUsers.Request;
using SCHESS.Models.Systems.AuditLogins.Request;
using SCHESS.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static SCHESS.Infrastructure.Constants.SystemConstants;

namespace SCHESS.Application.Services.System.AppUsers
{
    public class AppUserService : IAppUserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IAuditLoginService _auditLoginService;
        private readonly IConfiguration _configuration;
        private readonly IFileStorageService _storageService;

        public AppUserService(AppDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IAuditLoginService auditLoginService,
            IConfiguration configuration,
            IFileStorageService fileStorageService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _auditLoginService = auditLoginService;
            _configuration = configuration;
            _storageService = fileStorageService;
        }

        public async Task<ApiResult<ClientLoginDto>> Login(LoginRequest request)
        {
            var user = new AppUser();

            var auditLoginRequest = new AuditLoginRequest
            {
                UserId = string.Empty,
                Email = request.Email,
                IsSuccessded = false,
            };  

            bool isEmailNull = string.IsNullOrEmpty(request.Email);
            if (!isEmailNull)
            {
                user = await _userManager.FindByEmailAsync(request.Email);
            }
                
            if (user is null)
            {
                auditLoginRequest.Notes = ErrorMessage.WRONG_EMAIL;
                await this.SaveUserAuditLogin(auditLoginRequest);
                return new ApiErrorResult<ClientLoginDto>(ErrorMessage.WRONG_EMAIL);
            }

            // TODO: Production case
            switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            {
                case "Development":
                    if (!request!.Password!.Equals("123456"))
                    {
                        auditLoginRequest.Notes = ErrorMessage.WRONG_PASSWORD;
                        await this.SaveUserAuditLogin(auditLoginRequest);
                        return new ApiErrorResult<ClientLoginDto>(ErrorMessage.WRONG_PASSWORD);
                    }
                    break;

                default:
                    var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

                    if (!result.Succeeded)
                    {
                        auditLoginRequest.Notes = ErrorMessage.WRONG_PASSWORD;
                        await this.SaveUserAuditLogin(auditLoginRequest);
                        return new ApiErrorResult<ClientLoginDto>(ErrorMessage.WRONG_PASSWORD);
                    }

                    break;
            }

            auditLoginRequest.UserId = user.Id.ToString();
            auditLoginRequest.IsSuccessded = true;
            auditLoginRequest.Notes = ErrorMessage.LOGIN_SUCCESSFULLY;

            await this.SaveUserAuditLogin(auditLoginRequest);

            var token = this.GenerateToken(user);

            var clientLoginDto = await this.MapClientLoginDto(user, token);

            await this.UpdateUserLastLoginDate(user);

            return new ApiSuccessResult<ClientLoginDto>(clientLoginDto);

        }

        public async Task<ApiResult<AppUser>> Register(RegisterRequest request)
        {
            var user = new AppUser();

            bool isEmailNotNull = !string.IsNullOrEmpty(request.Email);

            if (isEmailNotNull)
            {
                user = await _userManager.FindByEmailAsync(request.Email!);
            }

            if (user is not null) return new ApiErrorResult<AppUser>(ErrorMessage.USER_CREATED);

            user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                Bio = string.Empty,
                PhoneNumber = null,
                Avatar = string.Empty,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                ActivateDate = DateTime.UtcNow,
                LastLogin = DateTime.UtcNow,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, request.Password!);

            bool isUserNotCreated = !result.Succeeded;

            if (isUserNotCreated) return new ApiErrorResult<AppUser>(ErrorMessage.CREATE_USER_FAILED);

            return new ApiSuccessResult<AppUser>(user);
        }

        private async Task UpdateUserLastLoginDate(AppUser user)
        {
            user.LastLogin = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) throw new Exception(ErrorMessage.INTERNAL_SERVER_ERROR);
        }

        private async Task<ClientLoginDto> MapClientLoginDto(AppUser user, JwtSecurityToken token)
        {
            if (user == null) return null;

            var roles = from ur in _context.UserRoles
                        join r in _context.AppRoles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new AppRoleDto() 
                        { 
                            Id = r.Id,
                            Name = r.Name,
                            Description = r.Description,
                        };

            var clientLoginDto = new ClientLoginDto
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                FullName = user.FullName,
                Dob = user.Dob.ToString(),
                Bio = user.Bio,
                UserName = user.UserName,
                City = user.City,
                Country = user.Country,
                Avatar = !string.IsNullOrEmpty(user.Avatar) ? await _storageService.GetFileAsync(user.Avatar) : string.Empty,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Roles = roles ?? null
            };

            // TODO: Get nessesary information of user

            return clientLoginDto;
        }

        private JwtSecurityToken GenerateToken(AppUser user)
        {
            var claims = new[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.Name, user.UserName!)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[AppConstants.TOKENS_KEY]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration[AppConstants.TOKENS_ISSUER],
                _configuration[AppConstants.TOKENS_ISSUER],
                claims,
                expires: DateTime.UtcNow.AddDays(180),
                signingCredentials: creds);

            return token;
        }

        private async Task SaveUserAuditLogin(AuditLoginRequest auditLoginRequest)
        {
            await _auditLoginService.AddAsync(auditLoginRequest);
        }

        
    }
}
