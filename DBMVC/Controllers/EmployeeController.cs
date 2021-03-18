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
        [HttpGet]
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
                    ViewBag.EmployeeMsssage ="Employee With Id "+ id +" Added ";
                }
            }
            return View();
        }

        public ActionResult GetAllEmployees()
        {
            var result = employeeRepository.GetAllEmployees();
            return View(result);
        }

        public ActionResult GetEmployee(int Id)
        {
            var result = employeeRepository.GetEmployee(Id);
            return View(result);
        }
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            var result = employeeRepository.GetEmployee(Id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.UpdateEmployee(model.Id, model);
                return RedirectToAction("GetAllEmployees");
            }
            return View();
        }

    }
}