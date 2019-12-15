using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class CorsExtensions
    {
        public static void InitialCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()

                .AllowAnyMethod()

                .AllowAnyHeader()

                .AllowCredentials());
        }

        public static void InitialCors(this IServiceCollection service)
        {
            service.AddCors();
        }
    }
}