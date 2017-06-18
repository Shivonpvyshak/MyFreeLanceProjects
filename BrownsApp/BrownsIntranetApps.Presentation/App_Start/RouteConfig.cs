using System.Web.Mvc;
using System.Web.Routing;

namespace BrownsIntranetApps.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" }
           );

            routes.MapRoute(
                 name: "HomeRoute",
                 url: "BrownsIntranetApps/{controller}/{action}/{name}"
                );

            //routes.MapRoute(
            //    name: "Login",
            //    url: "{controller}/{action}/{username}/{password}",
            //    defaults: new { controller = "Home", action = "Index", username = UrlParameter.Optional, password = UrlParameter.Optional }
            //);
        }
    }
}