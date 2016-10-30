using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class IletisimController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<Iletisim> Get()
        {
            return context.Iletisims;
        }

        // GET api/<controller>/5
        public Iletisim Get(int id)
        {
            return context.Iletisims.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(string tel, int adresId, string skype, string email)
        {
            Iletisim i = new Iletisim();
            i.Telefon = tel;
            i.AdresId = adresId;
            i.Skype = skype;
            i.Email = email;

            context.Iletisims.Add(i);
            context.SaveChanges();
            return i.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, string tel, int adresId, string skype, string email)
        {
            Iletisim i = context.Iletisims.FirstOrDefault(x=>x.Id==id);
            i.Telefon = tel;
            i.AdresId = adresId;
            i.Skype = skype;
            i.Email = email;

            context.Iletisims.Add(i);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Iletisim i = context.Iletisims.FirstOrDefault(x => x.Id == id);
            context.Iletisims.Remove(i);
            context.SaveChanges();
        }
    }
}