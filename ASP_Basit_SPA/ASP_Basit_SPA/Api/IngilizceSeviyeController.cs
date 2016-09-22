using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class IngilizceSeviyeController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<IngilizceSeviye> Get()
        {
            return context.IngilizceSeviyes;
        }

        // GET api/<controller>/5
        public IngilizceSeviye Get(int id)
        {
            return context.IngilizceSeviyes.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(string seviyeAdi)
        {
            IngilizceSeviye i = new IngilizceSeviye();
            i.SeviyeAdi = seviyeAdi;

            context.IngilizceSeviyes.Add(i);
            context.SaveChanges();
            return i.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, string seviyeAdi)
        {
            IngilizceSeviye i = context.IngilizceSeviyes.FirstOrDefault(x=>x.Id==id);
            i.SeviyeAdi = seviyeAdi;

            context.IngilizceSeviyes.Add(i);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            IngilizceSeviye i = context.IngilizceSeviyes.FirstOrDefault(x => x.Id == id);
            context.IngilizceSeviyes.Remove(i);
            context.SaveChanges();
        }
    }
}