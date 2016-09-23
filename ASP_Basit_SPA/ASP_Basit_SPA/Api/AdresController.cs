using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class AdresController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<Adre> Get()
        {
            return context.Adres;
        }

        // GET api/<controller>/5
        public Adre Get(int id)
        {
            return context.Adres.FirstOrDefault(x=>x.Id == id);
        }

        // POST api/<controller>
        public int Post(string tamAdres, string adresSatirIki, string sehir, int eyaletId, int ulkeId) 
        {
            Adre a = new Adre();
            a.TamAdres = tamAdres;
            a.AdresSatirIki = adresSatirIki;
            a.Sehir = sehir;
            a.EyaletId = eyaletId;
            a.UlkeId = ulkeId;

            context.Adres.Add(a);
            context.SaveChanges();

            return a.Id;
        }

        // PUT api/<controller>/5
        public void Put(int id, string tamAdres, string adresSatirIki, string sehir, int eyaletId, int ulkeId)
        {
            Adre a = context.Adres.FirstOrDefault(x=>x.Id == id);
            a.TamAdres = tamAdres;
            a.AdresSatirIki = adresSatirIki;
            a.Sehir = sehir;
            a.EyaletId = eyaletId;
            a.UlkeId = ulkeId;
            
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Adre a = context.Adres.FirstOrDefault(x => x.Id == id);
            context.Adres.Remove(a);
            context.SaveChanges();
        }
    }
}