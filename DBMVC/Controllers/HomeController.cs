using DBMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DBMVC.Controllers
{
   [AllowAnonymous] 
    public class HomeController : Controller
    {
        /* [SupriyaAuthenticationFilters]
        [SupriyaActionFilter] */
        /* [SupriyaException] */
        public ActionResult Index()
        {
            // return View("supriya");
            return View();
        }
        ////[NonAction]
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