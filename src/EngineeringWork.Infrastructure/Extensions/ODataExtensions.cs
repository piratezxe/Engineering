using System.Linq;
using EngineeringWork.Core.Domain;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class ODataExtensions
    {
        public static void AddOdataExtensions(this IServiceCollection services)
        {
            services.AddOData();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }

        public static void AddOdataExtensions(this IApplicationBuilder app)
        {
            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EntitySet<DailyRoute>(nameof(DailyRoute));
            builder.EntitySet<Route>(nameof(Route));
            builder.EntitySet<PassengerBookingProposal>(nameof(PassengerBookingProposal));
            builder.EntitySet<PassengerBooking>(nameof(PassengerBooking));

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().OrderBy().Filter();
            });
        }
    }
}