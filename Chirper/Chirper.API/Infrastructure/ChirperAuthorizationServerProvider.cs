using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Chirper.API.Infrastructure
{
    //inherits
    public class ChirperAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // 2 override methods
        // check login context
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //allow cors specifically for oauth and authenticating
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            {
                //find user based on username and password in auth repository
                using (var authorizationRepository = new AuthorizationRepository())
                {
                    var user = await AuthorizationRepository.FindUser(context.UserName, context.Password);

                    //thore error if no user found
                    if (user = null)
                    {
                        context.SetError("invalid_grant", "username or password is incorrect");

                    }
                    else
                    {
                        //create a token and add some claims - name, role and auth type
                        var token = new ClaimsIdentity(context.Options.AuthenticationType);
                        token.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                        token.AddClaim(new Claim(ClaimTypes.Role, "user"));

                        context.Validated(token);
                    }
                }
            }
        }
    }

}