using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class DilKisiController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<DilKisi> Get()
        {
            return context.DilKisis;
        }

        // GET api/<controller>/5
        public DilKisi Get(int id)
        {
            return context.DilKisis.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(int dilId, int kisiId)
        {
            DilKisi dk = new DilKisi();
            dk.DilId = dilId;
            dk.KisiId = kisiId;

            context.DilKisis.Add(dk);
            context.SaveChanges();
            return dk.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, int dilId, int kisiId)
        {
            DilKisi dk = context.DilKisis.FirstOrDefault(x=>x.Id == id);
            dk.DilId = dilId;
            dk.KisiId = kisiId;

            context.DilKisis.Add(dk);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            DilKisi dk = context.DilKisis.FirstOrDefault(x => x.Id == id);
            context.DilKisis.Remove(dk);
            context.SaveChanges();
        }
    }
}