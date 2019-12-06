using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class CorsExtensions
    {
        public static void InitialCors(this IApplicationBuilder app)
        {
            //before add.mvc
            app.UseCors("AllowAll");
        }

        public static void InitialCors(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                    .WithOrigins("http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
    }
}