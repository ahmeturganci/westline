using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class AcilDurumController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<AcilDurum> Get()
        {
            return context.AcilDurums;
        }

        // GET api/<controller>/5
        public AcilDurum Get(int id)
        {
            return context.AcilDurums.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<controller>
        public int Post(string ad = "", string soyad = "", string tel = "")
        {
            AcilDurum a = new AcilDurum();
            a.Ad = ad;
            a.Soyad = soyad;
            a.Telefon = tel;

            context.AcilDurums.Add(a);
            context.SaveChanges();

            return a.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, string ad, string soyad, string tel)
        {
            AcilDurum a = context.AcilDurums.FirstOrDefault(x=>x.Id == id);
            a.Ad = ad;
            a.Soyad = soyad;
            a.Telefon = tel;
            
            context.SaveChanges();
            
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            AcilDurum a = context.AcilDurums.FirstOrDefault(x => x.Id == id);
            context.AcilDurums.Remove(a);
            context.SaveChanges();
        }
    }
}