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
    [AllowAnonymous]
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
        public ActionResult SignUP(MemberShip model, bool admin, bool user, bool customer)
        {
            List<string> s = new List<string>();
            if (admin == true) s.Add("admin");
            if (user == true) s.Add("user");
            if (customer == true) s.Add("customer");

            var result = repo.SignUP(model, s);
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}