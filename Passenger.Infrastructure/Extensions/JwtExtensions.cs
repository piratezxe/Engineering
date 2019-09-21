using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Passenger.Infrastructure.Extensions
{
    public static class JwtExtensions
    {
        public static void AddJwtConfiguration(this IServiceCollection services, string key, string issuer)
        {
//            var key = Configuration.GetSettings<JwtSettings>().Key;
//            var issuer = Configuration.GetSettings<JwtSettings>().Issuer;
            services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg => {
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