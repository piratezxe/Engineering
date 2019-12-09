using System.Linq;
using EngineeringWork.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

    //namespace EngineeringWork.Infrastructure.Extensions
//{
    //public static class ODataExtensions
    //{
        //public static void AddOdataExtensions(this IServiceCollection services)
     //   {
//            services.AddOData();    
//            services.AddMvcCore(options =>
//            {
//                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
//                {
//                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
//                }
//                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
//                {
//                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
//                }
//            });
     //   }

      //  public static void AddOdataExtensions(this IApplicationBuilder app)
       // {
//            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
//            builder.EntitySet<DailyRoute>(nameof(DailyRoute));
//           
//            app.UseMvc(routeBuilder  =>
//            {
//                routeBuilder.EnableDependencyInjection();
//                routeBuilder.Expand().Select().OrderBy().Filter();
//            });
  //      }
  //  }
//}