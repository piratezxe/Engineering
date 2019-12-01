using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class JwtExtensions
    {
        public static void AddJwtConfiguration(this IServiceCollection services, string key, string issuer)
        {
            services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.Authority = "http://localhost:5000";
                    cfg.RequireHttpsMetadata = false;
                    cfg.Audience = "api1";
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidIssuer = issuer,
                        ValidateAudience = false
                    };
                });
        }
    }
}