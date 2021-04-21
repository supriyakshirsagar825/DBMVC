using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CLDataBaseLayer.DBOperations;
using CLModelLayer;

namespace WebApiProject.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeRepository repository = null;
        public EmployeeController()
        {
            repository = new EmployeeRepository();
        }
        [HttpGet]
        public IEnumerable<EmployeeModel> GetEmployee()
        {
            return repository.GetAllEmployees();
        }
        [HttpGet]
        public HttpResponseMessage Get(string gender)
        {
            var listemp= repository.GetEmployeeByGender(gender);
            if(listemp!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, listemp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Employee found");
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var entity= repository.GetEmployee(id);
            if(entity!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee With Id " + id.ToString() + " Not Found");
            }
        }
        [HttpPost]
        public HttpResponseMessage Post(EmployeeModel employee)
        {
            try
            {
                repository.AddEmployee(employee);
                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                message.Headers.Location = new Uri(Request.RequestUri +"id......"+ employee.Id);
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
           bool val= repository.DeleteEmployeeByID(Id,0);
            if(val==true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, val);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + Id.ToString() + " Not found in record");
            }
        }

        public HttpResponseMessage Put(int Id, [FromBody] EmployeeModel employee)
        {
            try
            {
                bool val = repository.UpdateEmployee(Id, employee);
                if (val == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + Id.ToString() + " Not found");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
