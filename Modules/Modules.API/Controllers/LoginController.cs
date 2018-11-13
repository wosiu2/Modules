using Modules.API.Models;
using Modules.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Modules.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class LoginController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Authenticate(AuthCredentials auth)
        {
            
            var repo = new UserRepository();
            var user = repo.GetByCredentials(auth.Login, auth.Password);
            if (user==null)
            {
                var resp= Request.CreateResponse(HttpStatusCode.Unauthorized);
                resp.Content = new StringContent("Persmission Denied");
                return resp;
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);

            user.IpAdress = HttpContext.Current?.Request.UserHostAddress;
            user.Cookie = Guid.NewGuid();

            var cookie = new CookieHeaderValue("msidt", user.Cookie.ToString());
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";
            

            if (user.Expire==0)
            {
                cookie.Expires = DateTime.Now.AddSeconds(3600);
            }
            else
            {
                cookie.Expires = DateTime.Now.AddSeconds(user.Expire);
            }
            
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            repo.Complete();
            response.Content = new StringContent("Persmission Granted");
            return response;
        }


        [HttpPost]
        public HttpResponseMessage Authorization()
        {
            var cookie = Request.Headers.GetCookies("msidt").FirstOrDefault();

            if (cookie==null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var repo = new UserRepository();
            var isValidUser = repo.GetAll().Any(n => n.Cookie.ToString().Equals(cookie["msidt"].Value));
            if (isValidUser)
            {
                var respo= Request.CreateResponse(HttpStatusCode.Accepted);
                respo.Content = new StringContent("Accepted");
                return respo;
            }
            else
            {
                var respo = Request.CreateResponse(HttpStatusCode.Unauthorized);
                respo.Content = new StringContent("Not Authorized");
                return respo;
            }
  
            
        }


        [HttpPost]
        public HttpResponseMessage Deauth()
        {
            var cookie = Request.Headers.GetCookies("msidt").FirstOrDefault();
 
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1d);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        /*  [HttpPost]
          public HttpResponseMessage Authenticate(AuthCredentials auth)
          {
              var repo = new UserRepository();

              return response;
          }*/

    }
}
