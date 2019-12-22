using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using EngineeringWork.Core;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.ExceptionsModels;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Infrastructure.IoC;
using EngineeringWork.Infrastructure.Settings;
using EngineeringWork.Web.Application;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using IConfiguration = AutoMapper.Configuration.IConfiguration;

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
            services.AddAuthorization();
            services.AddAuthentication();
            services.AddMemoryCache();
            services.InitialCors();
            services.AddSwaggerToService();
            services.AddOdataExtensions();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddDatabaseService(Configuration);
            services.AddTransient<ISeedData, SeedData>();
            services.AddMvc();

            return services.RegisterAutofacServices(Configuration);
        }

       
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ExceptionHandler>();
            }

            app.UseAuthentication();
            app.AddSwaggerToApp();
            app.InitialCors();
            app.UseMvc();
            app.AddOdataExtensions();
            app.ApplicationServices.GetService<ISeedData>().Init();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
