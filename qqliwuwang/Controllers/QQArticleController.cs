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
        [HttpGet, Route("Test")]
        public string Test()
        {
            return "value1";
        }

        // GET: api/QQArticle/5
        public string Get(int id)
        {
            return "value";
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
