using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Http;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Services.JwtTokenService;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                   .As<IEncrypter>()
                   .SingleInstance();

            builder.RegisterType<JwtHandler>()
                   .As<IJwtHandler>()
                   .SingleInstance();
            
            builder.RegisterType<NodeManager>()
                .As<INodeManager>()
                .SingleInstance();

        }
    }
}