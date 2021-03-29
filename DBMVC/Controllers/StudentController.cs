using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using CLDataBaseLayer;
using CLDataBaseLayer.DBOperations;
using System.Threading.Tasks;

namespace DBMVC.Controllers
{
    public class StudentController : Controller
    {
        EmployeeRepository repo = null;
       public StudentController()
        {
           repo= new EmployeeRepository();
        }
        // GET: Student
        public ActionResult Index()
        {
           
            return View();
        }
    }
}