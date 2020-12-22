using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Services
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {

        public CustomCookieAuthenticationEvents()
        {
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;
            var checkClaim = userPrincipal.Claims.First(p => p.Type == "LastCheckDateTime");
            var lastcheckDateTime = DateTime.ParseExact(checkClaim.Value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            int intervalMin = 15;

            if (lastcheckDateTime.AddMinutes(intervalMin) < DateTime.UtcNow)
            {
                if(true)
                {
                    var identity = userPrincipal.Identity as ClaimsIdentity;
                    identity.RemoveClaim(checkClaim);
                    identity.AddClaim(new Claim("LastCheckDateTime", DateTime.UtcNow.ToString("yyyyMMddHHmmss")));

                    await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                }
                else
                {
                    context.RejectPrincipal();
                    await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
             
            }
        }
    }
}
