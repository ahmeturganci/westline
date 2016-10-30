using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Controllers
{
    public class FormController : ApiController
    {
        // GET api/<controller>
        [HttpGet, ActionName("hede")]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        [HttpGet, ActionName("deneme")]
        public IEnumerable<string> Deneme()
        {
            return new string[] { "ert" };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}