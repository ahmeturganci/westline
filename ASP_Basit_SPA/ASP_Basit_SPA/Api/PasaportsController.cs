using System;
using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class PasaportsController : ApiController
    {
        private Westline db = new Westline();
        // GET: api/Pasaports
        public IQueryable<Pasaport> GetPasaports()
        {
            return db.Pasaports;
        }
        // GET: api/Pasaports/5
        public Pasaport GetPasaport(int id)
        {
            return db.Pasaports.FirstOrDefault(x => x.Id == id);
        }
        // PUT: api/Pasaports/5
        public void PutPasaport(int id, string pasNo, int aldigiUlke, string aldigiSehir,DateTime pasBaslangic,DateTime pasBittis, bool pasKayip, string pasUcretKisi, string pasUcretKisiAkraba,string pasKisiAkrabaNo)

        {
            Pasaport p = db.Pasaports.FirstOrDefault(x => x.Id == id);
            p.No = pasNo;
            p.AldigiUlke = aldigiUlke;
            p.AldigiSehir = aldigiSehir;
            p.PasaportBaslangic = pasBaslangic;
            p.PasaportBitis = pasBittis;
            p.PasaportKayipCalinti = pasKayip;
            p.PasaportUcretKisi = pasUcretKisi;
            p.PasaportUcretKisiAkraba = pasUcretKisiAkraba;
            p.PasaportUcretKisiAkrabaNo = pasKisiAkrabaNo;
            
            db.SaveChanges();
        }
        // POST: api/Pasaports
        public int PostPasaport(string pasNo, int aldigiUlke, string aldigiSehir, DateTime pasBaslangic, DateTime pasBittis, bool pasKayip, string pasUcretKisi, string pasUcretKisiAkraba, string pasKisiAkrabaNo)
        {

            Pasaport p = new Pasaport();
            p.No = pasNo;
            p.AldigiUlke = aldigiUlke;
            p.AldigiSehir = aldigiSehir;
            p.PasaportBaslangic = pasBaslangic;
            p.PasaportBitis = pasBittis;
            p.PasaportKayipCalinti = pasKayip;
            p.PasaportUcretKisi = pasUcretKisi;
            p.PasaportUcretKisiAkraba = pasUcretKisiAkraba;
            p.PasaportUcretKisiAkrabaNo = pasKisiAkrabaNo;

            db.Pasaports.Add(p);
            db.SaveChanges();

            return p.Id;
        }
        // DELETE: api/Pasaports/5
        public void DeletePasaport(int id)
        {
            Pasaport p = db.Pasaports.FirstOrDefault(x => x.Id == id);  
            db.Pasaports.Remove(p);
            db.SaveChanges();

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasaportExists(int id)
        {
            return db.Pasaports.Count(e => e.Id == id) > 0;
        }
    }
}