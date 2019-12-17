using Autofac;
using EngineeringWork.Infrastructure.IoC.Modules;
using EngineeringWork.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace EngineeringWork.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<MediatRModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }          
    }
}