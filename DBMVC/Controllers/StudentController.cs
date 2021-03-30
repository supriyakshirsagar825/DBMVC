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
using System.Dynamic;

namespace DBMVC.Controllers
{
    [AllowAnonymous]
    public class StudentController : Controller
    {
        
      
        // GET: Student
        public ActionResult Index()
        {
            //View Model example
            //StudentPersonVM studentPersonVM = new StudentPersonVM();
            //studentPersonVM.listperson = GetPeopleList();
            //studentPersonVM.liststudent = GetStudentsList();
            //return View(studentPersonVM);

            //dynamic data passing
            //dynamic studentPerson = new ExpandoObject();
            //studentPerson.listperson = GetPeopleList();
            //studentPerson.liststudent = GetStudentsList();
            //return View(studentPerson);

            var model = new Tuple<List<person> , List<student>, string>(GetPeopleList(), GetStudentsList(),"supriya");
            return View(model);

        }
        [ChildActionOnly]
        public PartialViewResult PartialViewResultStudent()
        {
            return PartialView("_student", GetStudentsList());
        }
        [ChildActionOnly]
        public PartialViewResult PartialViewResultPerson()
        {
            return PartialView("_person", GetPeopleList());
        }

        public List<person> GetPeopleList()
        {
            return new List<person>()
            {
                new person{ id=1, name="supriya", email="supriya@gamil.com"},
                new person{ id=2, name="shubham" ,email="shubham@gmail.com"}
            };
        }
        public List<student> GetStudentsList()
        {
            return new List<student>()
            {
                new student{ name="shreddha", city=1},
                new student{ name="seema" , city=2}

            };
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