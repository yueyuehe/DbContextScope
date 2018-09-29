using HWAdmin.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace qqliwuwang.Controllers
{
    [RoutePrefix("api/QQArticle")]
    public class QQArticleController : ApiController
    {
        // GET: api/QQArticle
        public HttpResponseMessage Get()
        {
            JsonResponse jr = new JsonResponse();
            jr.Data = new { data = "lis", age = 8, name = "lis" };
            return jr.ToHttpResponse();
        }

        // GET: api/QQArticle/5
        public string Get(int id)
        {

            return "";

        }

        // POST: api/QQArticle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QQArticle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QQArticle/5
        public void Delete(int id)
        {
        }
    }
}
