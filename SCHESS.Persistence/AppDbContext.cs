using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCHESS.Domain.Entity.System;
using SCHESS.Domain.Extensions;

namespace SCHESS.Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            // Initialize the database context here
        }

        // System
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AuditLogin> AuditLogins { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }
        public DbSet<EmailSentLog> EmailSentLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // Additional model configurations can be added here

            // User, Role Claimns
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
