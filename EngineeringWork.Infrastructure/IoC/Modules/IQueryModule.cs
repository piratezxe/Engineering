using System.Reflection;
using Autofac;

namespace EngineeringWork.Infrastructure.IoC.Modules
{
    public class IQueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;
            
            

        }
    }
}