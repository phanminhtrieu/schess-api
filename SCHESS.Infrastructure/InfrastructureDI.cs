using Microsoft.Extensions.DependencyInjection;
using SCHESS.Infrastructure.Provider.AzureBlob;

namespace SCHESS.Infrastructure
{
    public static class InfrastructureDI
    {
        public static void AddInfrastructureDIServices(this IServiceCollection services)
        {
            //services.AddAutoMapperConfig();
            services.AddInfrastructureServices();
        }

        private static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IAzureBlobService, AzureBlobService>();
        }
    }
}
