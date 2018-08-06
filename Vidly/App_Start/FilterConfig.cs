using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Redirects user to an Error page when action throws an exception
            filters.Add(new HandleErrorAttribute());
            
            // Apply authorisation globally
            filters.Add(new AuthorizeAttribute());

            // Require access via HTTPS only
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
