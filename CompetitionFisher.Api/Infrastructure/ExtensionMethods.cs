using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace CompetitionFisher.Api.Infrastructure
{
    public static class ExtensionMethods
    {
        public static string Auth0UserId(this ApiController apiController)
        {
            var claim = ((ClaimsPrincipal)apiController.User).Claims.FirstOrDefault(x => x.Type == "auth0userId"); // TODO: remove magic string. see https://stackoverflow.com/questions/41046879/asp-mvc-ef6-multi-tenant-based-on-host
            if (claim == null)
                return string.Empty;

            return claim.Value;
        }
    }
}