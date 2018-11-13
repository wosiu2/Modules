using Modules.API.App_Start;
using Modules.Base.Model;
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
    [CookieAuth]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SieveSamplesController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetSamples()
        {
            var repo = new SoilSampleRepository();
            SoilSample usr = repo.GetEager(1);
            usr.User = null;
            usr.User.Sample = null;
            usr.SieveParameter.SoilSample = null;

            var ddd = Request.Headers.GetCookies();



            if (usr == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {

                var response = Request.CreateResponse(HttpStatusCode.OK, usr);
                var cookie = new CookieHeaderValue("Session-id", "12345");
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                //cookie.
                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });


                return response;
            }

        }
 
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage TestPost(Object json)
        {

            var token = Guid.NewGuid().ToString();
            var ipAdress = HttpContext.Current?.Request.UserHostAddress;

            return Request.CreateResponse(HttpStatusCode.Created);
        }


    }
}
