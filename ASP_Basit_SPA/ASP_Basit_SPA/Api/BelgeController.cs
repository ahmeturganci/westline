using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class BelgeController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<Belge> Get()
        {
            return context.Belges;
        }

        // GET api/<controller>/5
        public Belge Get(int id)
        {
            return context.Belges.FirstOrDefault(x=>x.Id == id);
        }

        // POST api/<controller>
        public int Post(string ogrBelgeUrl,string transkriptUrl,string sabikaKaydiUrl, string fotoUrl)
        {
            Belge b = new Belge();
            b.OgrenciBelgeUrl = ogrBelgeUrl;
            b.TranskriptUrl = transkriptUrl;
            b.SabikaKaydiUrl = sabikaKaydiUrl;
            b.FotografUrl = fotoUrl;

            context.Belges.Add(b);
            context.SaveChanges();
            return b.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, string ogrBelgeUrl, string transkriptUrl, string sabikaKaydiUrl, string fotoUrl)
        {
            Belge b = context.Belges.FirstOrDefault(x=>x.Id == id);
            b.OgrenciBelgeUrl = ogrBelgeUrl;
            b.TranskriptUrl = transkriptUrl;
            b.SabikaKaydiUrl = sabikaKaydiUrl;
            b.FotografUrl = fotoUrl;

            context.Belges.Add(b);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Belge b = context.Belges.FirstOrDefault(x => x.Id == id);
            context.Belges.Remove(b);
            context.SaveChanges();
        }
    }
}