using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

// tell owin about our new entry point
[assembly: OwinStartup(typeof(Chirper.API.Startup))]
namespace Chirper.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // map url routes to the right C# methods
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        //setup OAth
        public void ConfigureOAuth(IAppBuilder app)
        {
            //configure authentication
            var authenticationOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(authenticationOptions);

            //configure authorization, configure token
            var authorizationOptions = new OAuthAuthorizationServerOptions
            {
                //for development only
                AllowInsecureHttp = true,
                //map token api endpoint
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ChirperAuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(authorizationOptions);
        }

    }
}