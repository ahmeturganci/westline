using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class ReferansController : ApiController
    {
        private Westline db = new Westline();
        // GET: api/Referans
        public IQueryable<Referan> GetReferans()
        {
            return db.Referans;
        }
        // GET: api/Referans/5
        public Referan GetReferan(int id)
        {
            return db.Referans.FirstOrDefault(x => x.Id == id);
        }
        // PUT: api/Referans/5
        public void PutReferan(int id,string ad,string soyad,string tel,string email, int adresId )//adamın adresi kayıt olann adresinden farklı
        {
            Referan r = db.Referans.FirstOrDefault(x => x.Id == id);
            r.Adi = ad;
            r.Soyadi = soyad;
            r.Tel = tel;
            r.Email = email;
            r.AdresId = adresId;
            
            db.SaveChanges();
        }
        // POST: api/Referans
        public int PostReferan(string ad, string soyad, string tel, string email, int adresId)
        {
            Referan r = new Referan();
            r.Adi = ad;
            r.Soyadi = soyad;
            r.Tel = tel;
            r.Email = email;
            r.AdresId = adresId;

            db.Referans.Add(r);
            db.SaveChanges();
            return r.Id;
        }
        // DELETE: api/Referans/5
        public void DeleteReferan(int id)
        {
            Referan r = db.Referans.FirstOrDefault(x => x.Id == id);
            db.Referans.Remove(r);
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
        private bool ReferanExists(int id)
        {
            return db.Referans.Count(e => e.Id == id) > 0;
        }
    }
}