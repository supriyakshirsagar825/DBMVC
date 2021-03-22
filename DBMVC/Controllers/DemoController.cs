using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace DBMVC.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult ListForAjaxHelper()
        {
            return View();
        }

        public JsonResult GetCountries()
        {
            List<string> countries = new List<string>()
         {
                    "Afghanistan" ,
                    "Albania",
                    "Algeria",
                    "Andorra",
                    "Angola ",
                    "Antigu ",
                    "Argentina",
                    "Armenia ",
                    "Australia ",
                    "Austria",
                    "Azerbai",
         };
            var json = JsonConvert.SerializeObject(countries);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStates()
        {
            List<string> States = new List<string>()
         {
                    "state --Afghanistan" ,
                    "state --Albania",
                    "state --Algeria",
                    "state --Andorra",
                    "state --Angola ",
                    "state --Antigu ",
                    "state --Argentina",
                    "state --Armenia ",
                    "state --Australia ",
                    "state --Austria",
                    "state --Azerbai",
         };
            var json = JsonConvert.SerializeObject(States);
            return Json(json, JsonRequestBehavior.AllowGet);
          
        }
        public JsonResult City()
        {
            List<string> States = new List<string>()
         {
                    "city--Afghanistan" ,
                    "city--Albania",
                    "city--Algeria",
                    "city--Andorra",
                    "city--Angola ",
                    "city--Antigu ",
                    "city--Argentina",
                    "city--Armenia ",
                    "city--Australia ",
                    "city--Austria",
                    "city--Azerbai",
         };
            var json = JsonConvert.SerializeObject(States);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}