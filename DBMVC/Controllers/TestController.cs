using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using Newtonsoft.Json;
namespace DBMVC.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Test
        public JsonResult GetEmployeeWithJson()
        {
            EmployeeModel e = new EmployeeModel()
            {
                FirstName = "sup",
                LastName = "ska",
                Gender = "female",
                Salary = 10000,
                Address = new AddressModel()
                {
                    AddressLine1 = "1 line",
                    AddressLine2 = "2 line",
                    City = "pune",
                    Country = "india",
                    State = "mahahrashtra"
                }
            };
            var json = JsonConvert.SerializeObject(e);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public void PostGetEmp(EmployeeModel m)
        {

        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
    }
}