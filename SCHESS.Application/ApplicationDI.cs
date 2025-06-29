using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SCHESS.Application.Interfaces.Catalog.Emails;
using SCHESS.Application.Interfaces.Common;
using SCHESS.Application.Interfaces.System.AppUsers;
using SCHESS.Application.Interfaces.System.AuditLogins;
using SCHESS.Application.Services.Catalog.Emails;
using SCHESS.Application.Services.Common;
using SCHESS.Application.Services.System.AppUsers;
using SCHESS.Application.Services.System.AuditLogins;
using SCHESS.Domain.Entity.System;
using SCHESS.Infrastructure.Provider.Email;

namespace SCHESS.Application
{
    public static class ApplicationDI
    {
        public static void AddApplicationDIServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
        }

        private static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            //services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            //services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();

            // Common services
            services.AddTransient<IFileStorageService, FileStorageService>();

            // System services
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IAuditLoginService, AuditLoginService>();

            // Email
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailSentLogService, EmailSentLogService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
        }
    }
}
