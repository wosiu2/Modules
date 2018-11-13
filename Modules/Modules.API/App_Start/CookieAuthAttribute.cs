using Modules.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Modules.API.App_Start
{
    public class CookieAuthAttribute:AuthorizationFilterAttribute
    {
        

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var cookie=actionContext.Request.Headers.GetCookies("msidt").FirstOrDefault();

            if (cookie==null)
            {
                actionContext.Response=actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                var repo = new UserRepository();
                var user = repo.GetByCookie(cookie["msidt"].Value);
                if (user==null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.Id.ToString()),null);
                }

            }

        }
    }
}