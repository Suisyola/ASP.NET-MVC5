using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // This MapRoute has to be before Default because this MapRoute is more specific.
            // movies/released can be routed to Default MapRoute if the order of MoviesByReleaseDate is after Default
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new {controller = "Movies", action = "ByReleaseDate"}, // new{} is anonymous  object
            //    new {year = @"\d{4}", month = @"\d{2}"} // constraints for URL params. Applies regular expression. Year must be 4 digit.
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
