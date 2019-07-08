using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApplication1.App_Start;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Login","Login","~/Login.aspx");
            routes.MapPageRoute("Main", "MovieDetail/{id}", "~/MovieDetail.aspx");
            routes.MapPageRoute("MoviesCounter", "MoviesCounter", "~/MoviesCounter.aspx");
            routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        void Application_Start(object sender, EventArgs e)
        {
                    GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
             .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    GlobalConfiguration.Configuration.Formatters
                        .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}