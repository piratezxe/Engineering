using System.Reflection;
using Autofac;
using MediatR;

namespace EngineeringWork.Infrastructure.IoC.Modules
{
    public class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(MediatRModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                 .AsClosedTypesOf(typeof(IRequestHandler<,>))
                 .InstancePerLifetimeScope();
        }
    }
}