using Microsoft.AspNetCore.Http;
using SCHESS.Application.Interfaces.System.AuditLogins;
using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Domain.Entity.System;
using SCHESS.Models.Systems.AuditLogins.Request;
using SCHESS.Persistence;

namespace SCHESS.Application.Services.System.AuditLogins
{
    public class AuditLoginService : IAuditLoginService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string UserAgent = string.Empty;
        private string RemoteIpAddress = string.Empty;
        private string HostName = string.Empty;
        private string Method = string.Empty;
        private string Path = string.Empty;

        public AuditLoginService(AppDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

            var httpContext = _httpContextAccessor.HttpContext;

            this.UserAgent = httpContext?.Request.Headers["User-Agent"].ToString() ?? string.Empty;
            this.RemoteIpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString() ?? string.Empty;
            this.HostName = httpContext?.Request.Host.Value ?? string.Empty;
            this.Method = httpContext?.Request.Method ?? string.Empty;
            this.Path = httpContext?.Request.Path ?? string.Empty;
        }

        public async Task<ApiResult<int>> AddAsync(AuditLoginRequest request)
        {
            var auditLogin = new AuditLogin
            {
                Url = $"{this.HostName}{this.Path}",
                Domain = this.HostName,
                UserAgent = $"{this.UserAgent}",
                Method = this.Method,
                IpAddress = this.RemoteIpAddress,
                Email = request.Email,
                IsSuccessded = request.IsSuccessded,
                Notes = request.Notes,
                UserId = request.UserId,
                DateCreated = DateTime.Now
            };

            await _context.AuditLogins.AddAsync(auditLogin);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(auditLogin.Id);
        }
    }
}
