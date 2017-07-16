using Auth0.Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Configuration;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode;

namespace CompetitionFisher.Api.App_Start
{
    public class Auth0Config
    {
        internal static void Configure(IAppBuilder app)
        {
            var domain = $"https://{ConfigurationManager.AppSettings["Auth0Domain"]}/";
            var apiIdentifier = ConfigurationManager.AppSettings["Auth0ApiIdentifier"];

            var keyResolver = new OpenIdConnectSigningKeyResolver(domain);
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = apiIdentifier,
                        ValidIssuer = domain,
                        IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) => keyResolver.GetSigningKey(identifier)
                    },
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        // create subject claim for userId
                        OnValidateIdentity = context =>
                        {
                            var subject = context.Ticket.Identity.Claims.FirstOrDefault(el => el.Type == ClaimTypes.NameIdentifier)?.Value;
                            //var sub = context.Ticket.Identity.Claims.FirstOrDefault(el => el.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
                            if (!string.IsNullOrEmpty(subject) && subject.Contains("|"))
                            {
                                subject = subject.Substring(subject.IndexOf("|") + 1);
                            }
                            context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("auth0userId", subject));
                            return Task.FromResult<object>(null);
                        }

                    }

                });
        }
    }
}