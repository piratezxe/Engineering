using System.Reflection;
using Autofac;
using EngineeringWork.Infrastructure.Services;
using EngineeringWork.Infrastructure.Services.JwtTokenService;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Infrastructure.Services.Password;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EngineeringWork.Infrastructure.IoC.Modules
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

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();
        }
    }
}