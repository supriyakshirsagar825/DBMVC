using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiProject.Controllers
{
    public class DemoController : ApiController
    {
       static List<string> listString = new List<string>()
        {
            "value0","value1","value2","value3","value4"
        };
        // GET: api/Demo
        public IEnumerable<string> Get()
        {
            return listString;
        }

        // GET: api/Demo/5
        public string Get(int id)
        {
            return listString[id];
        }
        [HttpPost]
        // POST: api/Demo
        public void Post([FromBody]string value)
        {
            listString.Add(value);
        }

        // PUT: api/Demo/5
        public void Put(int id, [FromBody]string value)
        {
            listString[id] = value;
        }

        // DELETE: api/Demo/5
        public void Delete(int id)
        {
            listString.RemoveAt(id);
        }
    }
}
