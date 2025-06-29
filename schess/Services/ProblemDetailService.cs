using Hellang.Middleware.ProblemDetails;
using SCHESS.Infrastructure.Exceptions;

namespace SCHESS.Services
{
    public static class ProblemDetailService
    {
        public static IServiceCollection AddProblemDetailService(this IServiceCollection services)
        {
            //services.AddProblemDetails();

            services.AddProblemDetails(options =>
            {
                options.MapToStatusCode<NotFoundException>(StatusCodes.Status404NotFound);
                options.MapToStatusCode<UnauthorizedAccessException>(StatusCodes.Status401Unauthorized);
                options.MapToStatusCode<BadHttpRequestException>(StatusCodes.Status400BadRequest);
                options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
                options.IncludeExceptionDetails = (ctx, ex) =>
                    ctx.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment();
            });

            return services;
        }
    }
}
