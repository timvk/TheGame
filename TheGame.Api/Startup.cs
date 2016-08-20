namespace TheGame.Api
{
    using Owin;
    using System;
    using Microsoft.Owin;
    using Newtonsoft.Json;
    using System.Web.Http;
    using Microsoft.Owin.Cors;
    using Newtonsoft.Json.Serialization;
    using Microsoft.Owin.Security.OAuth;

    using AuthProvider;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Set Token provider
            this.ConfigureOAuth(appBuilder);

            var config = new HttpConfiguration();

            // Cors
            appBuilder.UseCors(CorsOptions.AllowAll);

            // Routing
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            // JSON options
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatter.UseDataContractJsonSerializer = false;
            formatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;

            appBuilder.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
