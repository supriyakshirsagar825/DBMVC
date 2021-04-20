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
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return repository.GetAllEmployees();
        }

        [HttpGet]
        public EmployeeModel GetEmployee(int id)
        {
            return repository.GetEmployee(id);
        }

    }
}
