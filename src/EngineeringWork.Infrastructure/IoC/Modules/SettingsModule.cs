using Autofac;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace EngineeringWork.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<DatabaseSettings>())
                    .SingleInstance();
        }  
    }
}