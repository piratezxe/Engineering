using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class CorsExtensions
    {
        public static void InitialCors(this IApplicationBuilder app)
        {
            //before add.mvc
            app.UseCors("MyPolicy");
        }

        public static void InitialCors(this IServiceCollection service)
        {
            service.AddCors( o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
        }
    }
}