using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Passenger.Core.Database;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.IoC;
using Passenger.Infrastructure.Seed;
using Passenger.Infrastructure.Settings;

namespace EngineeringWork.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddAuthorization();
            services.AddAuthentication();
            services.AddMemoryCache();
            services.AddMvc();
            services.AddSwaggerToService();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            var key = Configuration.GetSettings<JwtSettings>().Key;
            var issuer = Configuration.GetSettings<JwtSettings>().Issuer;
            var database = Configuration.GetSettings<DatabaseSettings>().ConnectionString;
            
            services.AddJwtConfiguration(key, issuer);
            services.AddDbContext<PassengerContext>(options =>
                {
                    options.UseSqlServer(database, x => x.MigrationsAssembly("EngineeringWork.Api"));
                });    
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();
            
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {

            app.UseAuthentication();
            app.AddSwaggerToApp();
            app.UseMvc();
            app.ApplicationServices.GetService<ISeedData>().Init();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
