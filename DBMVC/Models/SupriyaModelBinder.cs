using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CLModelLayer;

namespace DBMVC.Models
{
    public class SupriyaModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = controllerContext.HttpContext.Request;
            var values = result.Headers.GetValues("SupriyaKey");
            return JsonConvert.DeserializeObject<EmployeeModel>(values.First());
            //throw new NotImplementedException();
        }
    }
}