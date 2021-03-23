using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using CLDataBaseLayer.DBOperations;
using System.Web.Security;

namespace DBMVC.Controllers
{
    public class AccountController : Controller
    {
        EmployeeRepository repo = null;
        public AccountController()
        {
            repo = new EmployeeRepository();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberShip model)
        {
            var res = repo.Login(model);
            if(res == true)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("GetAllEmployees", "Employee");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(MemberShip model)
        {
            var result = repo.SignUP(model);
            return RedirectToAction("Login");
        }


    }
}