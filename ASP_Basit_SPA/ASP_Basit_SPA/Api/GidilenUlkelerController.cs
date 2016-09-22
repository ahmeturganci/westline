using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class GidilenUlkelerController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<GidilenUlkeler> Get()
        {
            return context.GidilenUlkelers;
        }

        // GET api/<controller>/5
        public GidilenUlkeler Get(int id)
        {
            return context.GidilenUlkelers.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(int kisiId,int ulkeId)
        {
            GidilenUlkeler gu = new GidilenUlkeler();
            gu.KisiId = kisiId;
            gu.UlkeId = ulkeId;

            context.GidilenUlkelers.Add(gu);
            context.SaveChanges();
            return gu.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, int kisiId, int ulkeId)
        {
            GidilenUlkeler gu = context.GidilenUlkelers.FirstOrDefault(x=>x.Id==id);
            gu.KisiId = kisiId;
            gu.UlkeId = ulkeId;

            context.GidilenUlkelers.Add(gu);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            GidilenUlkeler gu = context.GidilenUlkelers.FirstOrDefault(x => x.Id == id);
            context.GidilenUlkelers.Remove(gu);
            context.SaveChanges();
        }
    }
}