using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class KisiReferansController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<KisiReferan> Get()
        {
            return context.KisiReferans;
        }

        // GET api/<controller>/5
        public KisiReferan Get(int id)
        {
            return context.KisiReferans.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(int kisiId, int refId)
        {
            KisiReferan kr = new KisiReferan();
            kr.KisiId = kisiId;
            kr.ReferansId = refId;

            context.KisiReferans.Add(kr);
            context.SaveChanges();
            return kr.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, int kisiId, int refId)
        {
            KisiReferan kr = context.KisiReferans.FirstOrDefault(x=>x.Id==id);
            kr.KisiId = kisiId;
            kr.ReferansId = refId;

            context.KisiReferans.Add(kr);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            KisiReferan kr = context.KisiReferans.FirstOrDefault(x => x.Id == id);
            context.KisiReferans.Remove(kr);
            context.SaveChanges();
        }
    }
}