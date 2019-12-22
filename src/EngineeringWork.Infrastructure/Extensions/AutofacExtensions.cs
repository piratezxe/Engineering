using Autofac;
using Autofac.Extensions.DependencyInjection;
using EngineeringWork.Infrastructure.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class AutofacExtensions
    {
        public static AutofacServiceProvider RegisterAutofacServices(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(configuration));
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}