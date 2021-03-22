using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using CLDataBaseLayer.DBOperations;

namespace DBMVC.Controllers
{
    public class PartialViewDemoController : Controller
    {
        // GET: PartialViewDemo
        EmployeeRepository repo = null;
        public PartialViewDemoController()
        {
            repo = new EmployeeRepository();
        }
        public ActionResult Index()
        {
            var emplist = repo.GetAllEmployees();
            return View(emplist);
        }
    }
}