using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class KisiController : ApiController
    {
        Westline context = new Westline();
        // GET api/<controller>
        public IEnumerable<Kisi> Get()
        {
            return context.Kisis;
        }
        // GET api/<controller>/5
        public Kisi Get(int id)
        {
            return context.Kisis.FirstOrDefault(x=>x.Id == id);
        }
        // POST api/<controller>
        public void Post(string ad="", string ortaAd = "", string soyad = "", string tcKimlikNo = "", string email = "", string tel="")
        {
           
            Kisi k = new Kisi();
            k.Ad = ad;
            k.OrtaAd = ortaAd;
            k.Soyad = soyad;
            k.TcKimlikNo = tcKimlikNo;

            /*Iletisim i = new Iletisim();
            i.Email = email;
            i.Telefon = tel;

            context.Iletisims.Add(i);

            k.IletisimId = i.Id;*/
            context.Kisis.Add(k);
            context.SaveChanges();
        }
        // PUT api/<controller>/5
        public void Put(int id, string ad, string ortaAd, string soyad, bool pasaport, DateTime dogumTarihi, int ingSeviyeId, string tcKimlikNo, string anneAdi, string babaAdi, int isTercihi, int iletisimId, int acilDurumId, int universiteId, int belgeId, int liseId, int dsId)
        {
            Kisi k = context.Kisis.FirstOrDefault(x => x.Id == id);
            k.Ad = ad;
            k.OrtaAd = ortaAd;
            k.Soyad = soyad;
            k.AcilDurumId = acilDurumId;
            k.AnneAdi = anneAdi;
            k.BabaAdi = babaAdi;
            k.BelgeId = belgeId;
            k.DogumTarihi = dogumTarihi;
            k.DsId = dsId;
            k.IletisimId = iletisimId;
            k.IngilizceSeviyeId = ingSeviyeId;
            k.IsTercihi = isTercihi;
            k.LiseId = liseId;
            k.Pasaport = pasaport;
            k.TcKimlikNo = tcKimlikNo;
            k.UniversiteId = universiteId;
            
            context.SaveChanges();
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Kisi k = context.Kisis.FirstOrDefault(x => x.Id == id);
            context.Kisis.Remove(k);
            context.SaveChanges();
        }
    }
}