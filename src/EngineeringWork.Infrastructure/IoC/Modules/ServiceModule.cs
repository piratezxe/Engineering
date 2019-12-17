using System.Reflection;
using Autofac;
using EngineeringWork.Core.Interface.Services;
using EngineeringWork.Core.Interface.Services.JwtTokenService;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Core.Interface.Services.Password;
using EngineeringWork.Infrastructure.Services.JwtTokenService;
using EngineeringWork.Infrastructure.Services.NodeService;
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