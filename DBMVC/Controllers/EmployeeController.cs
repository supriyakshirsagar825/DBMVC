using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using CLDataBaseLayer.DBOperations;
using DBMVC.Models;

namespace DBMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        EmployeeRepository employeeRepository = null;
        IEmployeeExperience _employeeExperience;
        public EmployeeController( IEmployeeExperience employeeExperience)
        {
            _employeeExperience = employeeExperience;
            employeeRepository = new EmployeeRepository();
        }
        // GET: Employee
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            var res = _employeeExperience.IsExperienced();
            ViewBag.listcountry = new List<string>() { "India", "USA", "Japan", "Canada" };
            ViewBag.listcity = new List<string>() { "Mumbai", "Louisville", "okasa", "Toranto" };
            ViewBag.liststate = new List<string>() { "MH", "KY", "JP", "TO" };
            return View();
        }
        [Authorize(Roles = "admin")]
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
            ViewBag.listcountry = new List<string>() { "India", "USA", "Japan", "Canada" };
            ViewBag.listcity = new List<string>() { "Mumbai", "Louisville", "okasa", "Toranto" };
            ViewBag.liststate = new List<string>() { "MH", "KY", "JP", "TO" };
            return View();
        }
         [Authorize(Roles = "admin")]
        // [HttpPost]
        [HttpPost]
        public ActionResult GetAllEmployeesForModelBinder([ModelBinder(typeof(SupriyaModelBinder))] EmployeeModel model)
        {
            var result = model;
            return View(result);
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
        [Authorize(Roles ="user")]
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            var result = employeeRepository.GetEmployee(Id);
            return View(result);
        }
        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int Id,int addid)
        {
            employeeRepository.DeleteEmployeeByID(Id,addid);
            return RedirectToAction("GetAllEmployees");
        }
    }
}