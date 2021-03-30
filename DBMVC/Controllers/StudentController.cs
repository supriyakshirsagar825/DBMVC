using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLModelLayer;
using CLDataBaseLayer;
using CLDataBaseLayer.DBOperations;
using System.Threading.Tasks;
using DBMVC.Models;
using System.IO;
namespace DBMVC.Controllers
{
    [AllowAnonymous]
    public class StudentController : Controller
    {
        
      
        // GET: Student
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult create()
        {
            ViewBag.city = city.getcitylist();
            return View();
        }
        [HttpPost]
        //public ActionResult create(student model,string create,string edit)
        public ActionResult create(student model, string submit)
        {
            if(ModelState.IsValid)
            {
                string folderpath = Server.MapPath("~/App_Data/File");
                string filename = Path.GetFileName(model.file.FileName);
                string fullpath = Path.Combine(folderpath, filename);
                model.file.SaveAs(fullpath);

                return RedirectToAction("create");
            }
            ViewBag.city = city.getcitylist();
            return View();
        }
        public FileResult Downloadfile()
        {
            //student s = new student();
            string folderpath = Server.MapPath("~/App_Data/File");
            string filename = Path.GetFileName("formvcdemo.txt");
            string fullpath = Path.Combine(folderpath, filename);
            return File(fullpath, "text/plain",filename);
        }

    }
    public class city
    {
     public   int id { get; set; }
      public  string text { get; set; }

        public static List<city> getcitylist()
        {
            var res = new List<city>()
            {
                new city() { id = 1, text = "Mumbai" },
                new city() { id = 2, text = "Pune" },
                new city() { id = 3, text = "Nashik" },
                new city() { id = 4, text = "Amravati" },
                new city() { id = 5, text = "Nagpur" },
            };
            return res;
        }
    }
}