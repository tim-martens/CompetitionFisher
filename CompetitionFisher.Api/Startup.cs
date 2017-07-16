using Microsoft.Owin;
using Owin;
using CompetitionFisher.Api.App_Start;
using CompetitionFisher.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace CompetitionFisher.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Configure Auth0
            Auth0Config.Configure(app);

            // Configure Web API
            WebApiConfig.Configure(app);

        }

    }
}
