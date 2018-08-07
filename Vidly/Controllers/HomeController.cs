using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    // AllowAnonymous is applied to all actions in this controller. 
    // Users need not be authorized to access the actions here.
    [AllowAnonymous] 
    public class HomeController : Controller
    {
        // Disable cache for Index(). VaryByParam is set to wildcard, so that regardless of what URL param, there is no cache.
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}