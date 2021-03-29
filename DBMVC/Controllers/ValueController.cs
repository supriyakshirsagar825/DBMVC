using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBMVC.Controllers
{
    public class ValueController : ApiController
    {
        [Route("api/supriyamethod/{id}")]
        public IHttpActionResult Get([FromUri] int id)
        {
            if (id > 5)
            { return Ok(2); }
            else
            { return NotFound(); }
        }
    }
}
