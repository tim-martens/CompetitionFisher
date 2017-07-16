using System.Web.Http;
using Owin;

namespace CompetitionFisher.Api
{
    public class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "webapi/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});

            app.UseWebApi(config);
        }
    }
}