using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Seed;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Services.JwtTokenService;
using Passenger.Infrastructure.Services.NodeService;
using Passenger.Infrastructure.Services.Password;

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

            builder.RegisterType<PasswordHasher<IPasswordService>>()
                .As<IPasswordHasher<IPasswordService>>()
                .SingleInstance();
            
            builder.RegisterType<JwtHandler>()
                   .As<IJwtHandler>()
                   .SingleInstance();
            
            builder.RegisterType<NodeManager>()
                .As<INodeManager>()
                .SingleInstance();

            builder.RegisterType<SeedData>()
                .As<ISeedData>()
                .SingleInstance();

        }
    }
}