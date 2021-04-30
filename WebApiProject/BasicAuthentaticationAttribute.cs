using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CLDataBaseLayer.DBOperations;
using CLModelLayer;

namespace WebApiProject
{
    public class BasicAuthentaticationAttribute:AuthorizationFilterAttribute 
    {
        EmployeeRepository employeeRepository = null;
        public BasicAuthentaticationAttribute()
        {
            employeeRepository = new EmployeeRepository();
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedauthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamepasswordarray=  decodedauthenticationToken.Split(':');
                MemberShip m = new MemberShip();
                m.UserName = usernamepasswordarray[0];
                m.Password = usernamepasswordarray[1];
                if(employeeRepository.Login(m))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(usernamepasswordarray[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
        }
    }
}