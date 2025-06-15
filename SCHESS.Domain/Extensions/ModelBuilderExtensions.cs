using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCHESS.Domain.Entity.System;
using SCHESS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHESS.Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Default Roles
            var ADMIN_ROLE_ID = Guid.Parse("851afdd4-0756-4759-b860-625aba4d8024");
            var TRAINER_ROLE_ID = Guid.Parse("72895e7d-549d-4d1c-aa24-11e0f05fa93c");
            var PLAYER_ROLE_ID = Guid.Parse("69d88ef3-900e-48f1-a45e-1a3bd91eb8d1");

            // Default account
            var ADMIN_ACCOUNT_ID = Guid.Parse("680b988b-4c45-4f74-9972-c9d3897aa93c");
            var TRAINER_ACCOUNT_ID = Guid.Parse("28879b28-9806-4c3d-9783-88f121e5df97"); 
            var PLAYER_ACCOUNT_ID = Guid.Parse("af6c5318-d37a-4359-beb6-19f0ce1b6e38");

            // User
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    RoleDescription = "Administrator",
                    Description = "Administrator"
                },
                new AppRole
                {
                    Id = TRAINER_ROLE_ID,
                    Name = "Trainer",
                    NormalizedName = "TRAINER",
                    RoleDescription = "Trainer",
                    Description = "Trainer"
                },
                new AppRole
                {
                    Id = PLAYER_ROLE_ID,
                    Name = "Player",
                    NormalizedName = "PLAYER",
                    RoleDescription = "Player",
                    Description = "Player"
                });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = ADMIN_ACCOUNT_ID,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "123456"),
                    SecurityStamp = string.Empty,
                    FullName = "Phan Minh Trieu",
                    Dob = new DateTime(2004, 10, 11),
                    CreatedDate = new DateTime(2024, 6, 13, 10, 0, 0),
                    ModifiedDate = new DateTime(2024, 6, 13, 10, 0, 0),
                    IsActive = true
                },
                new AppUser
                {
                    Id = TRAINER_ACCOUNT_ID,
                    UserName = "trainer",
                    NormalizedUserName = "TRAINER",
                    Email = "trainer@gmail.com",
                    NormalizedEmail = "TRAINER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "123456"),
                    SecurityStamp = string.Empty,
                    FullName = "Nguyen Thanh Tung",
                    Dob = new DateTime(1955, 10, 11),
                    CreatedDate = new DateTime(2024, 6, 13, 10, 0, 0),
                    ModifiedDate = new DateTime(2024, 6, 13, 10, 0, 0),
                    IsActive = true
                },
                new AppUser
                {
                    Id = PLAYER_ACCOUNT_ID,
                    UserName = "player",
                    NormalizedUserName = "PLAYER",
                    Email = "player@gmail.com",
                    NormalizedEmail = "PLAYER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "123456"),
                    SecurityStamp = string.Empty,
                    FullName = "Le Ngoc Hieu",
                    Dob = new DateTime(2004, 1, 1),
                    CreatedDate = new DateTime(2024, 6, 13, 10, 0, 0),
                    ModifiedDate = new DateTime(2024, 6, 13, 10, 0, 0),
                    IsActive = true
                }
            );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ACCOUNT_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = TRAINER_ROLE_ID,
                    UserId = TRAINER_ACCOUNT_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = PLAYER_ROLE_ID,
                    UserId = PLAYER_ACCOUNT_ID
                }
            );

            // Email Settings
            modelBuilder.Entity<EmailSetting>().HasData(
                new EmailSetting
                {
                    Id = 1,
                    IsActive = true,
                    IsSsl = true,
                    CreatedUserId = ADMIN_ACCOUNT_ID,
                    ModifiedUserId = ADMIN_ACCOUNT_ID,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                });

            // Email
            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    Id = 1,
                    Code = "SEND_EMAIL_CONFIRMATION",
                    Function = EmailFunction.SendEmailConfirmation,
                    Title = "Email Confirmation",
                    Subject = "Email Confirmation",
                    Body = "<figure class=\"table\">\r\n  <table>\r\n    <tbody>\r\n      <!-- Phần nội dung chính -->\r\n      <tr>\r\n        <td>\r\n          <p style=\"margin-left:20px;\">\r\n            <strong>Chào mừng đến với SCHESS!</strong>\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            Để kích hoạt tài khoản, vui lòng nhấn nút bên dưới để xác thực địa chỉ email.\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            <a href=\"{{confirmationLink}}\">Kích hoạt tài khoản</a>\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            Trong trường hợp nút kích hoạt ở trên không hoạt động, hãy sao chép và dán đường link này vào trình duyệt của bạn:\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            <a href=\"{{confirmationLink}}\">{{confirmationLink}}</a>\r\n          </p>\r\n        </td>\r\n      </tr>\r\n    </tbody>\r\n  </table>\r\n</figure>",
                    EmailSettingId = 1,
                    CreatedUserId = ADMIN_ACCOUNT_ID,
                    ModifiedUserId = ADMIN_ACCOUNT_ID,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                });
        }
        
    }
}
