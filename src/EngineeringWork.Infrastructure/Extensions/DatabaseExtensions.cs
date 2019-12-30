using EngineeringWork.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EngineeringWork.Repository.Database;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddDatabaseService(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            var key = Configuration.GetSettings<JwtSettings>().Key;
            var issuer = Configuration.GetSettings<JwtSettings>().Issuer;
            var database = Configuration.GetSettings<DatabaseSettings>().ConnectionString;

            services.AddJwtConfiguration(key, issuer);
            services.AddDbContext<PassengerContext>(options =>
            {
                options.UseSqlServer(database, x => x.MigrationsAssembly("EngineeringWork.Repository"));
            });
        }
    }
}
