using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class LiseController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<Lise> Get()
        {
            return context.Lises;
        }

        // GET api/<controller>/5
        public Lise Get(int id)
        {
            return context.Lises.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(string ad, int adresId, string mezunYilAralik, string alan)
        {
            Lise l = new Lise();
            l.Ad = ad;
            l.AdresId = adresId;
            l.MezunYilAralik = mezunYilAralik;
            l.Alan = alan;

            context.Lises.Add(l);
            context.SaveChanges();
            return l.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, string ad, int adresId, string mezunYilAralik, string alan)
        {
            Lise l = context.Lises.FirstOrDefault(x=>x.Id==id);
            l.Ad = ad;
            l.AdresId = adresId;
            l.MezunYilAralik = mezunYilAralik;
            l.Alan = alan;

            context.Lises.Add(l);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Lise l = context.Lises.FirstOrDefault(x => x.Id == id);
            context.Lises.Remove(l);
            context.SaveChanges();
        }
    }
}