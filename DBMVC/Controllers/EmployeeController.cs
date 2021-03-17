using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using CLDataBaseLayer.DBOperations;

namespace DBMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository employeeRepository = null;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }
        // GET: Employee
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
              int id=  employeeRepository.AddEmployee(model);
                if(id>0)
                {
                    ModelState.Clear();
                    ViewBag.EmployeeMsssage = id +"Employee Added ";
                }
            }
            return View();
        }
    }
}