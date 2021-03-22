using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMVC.Controllers
{
    public class ExceptionHandlingController : Controller
    {
        // GET: ExceptionHandling
        //[HandleError]
        public ActionResult Index()
        {
           
                throw new Exception("new exception");
         
        }
    }
}