using Microsoft.Extensions.DependencyInjection;
using SCHESS.Domain.Repositories;
using SCHESS.Domain.UnitOfWork;
using SCHESS.Persistence.Repositories;
using SCHESS.Persistence.UnitOfWork;

namespace SCHESS.Persistence
{
    public static class PersistenceDI
    {
        public static void AddPersistenceDIServices(this IServiceCollection services)
        {
            services.AddPersistenceServices();
            //services.AddDbContext<SCHESSDbContext>(options =>
            //    options.UseSqlServer(SystemConstants.ConnectionStringConstants.MAIN_CONNECTION_STRING));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IRepository<AppRole>, Repository<AppRole>>();
            //services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            //services.AddScoped<IRepository<ChessGame>, Repository<ChessGame>>();
            //services.AddScoped<IRepository<ChessMove>, Repository<ChessMove>>();
        }

        private static void AddPersistenceServices(this IServiceCollection services)
        {
            // Inject Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            // Email Repository
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailSentLogRepository, EmailSentLogRepository>();
        }
    }
}