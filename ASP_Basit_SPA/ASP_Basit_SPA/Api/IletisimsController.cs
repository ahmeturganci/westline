using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class IletisimsController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/Iletisims
        public IQueryable<Iletisim> GetIletisims()
        {
            return db.Iletisims;
        }

        // GET: api/Iletisims/5
        public Iletisim GetIletisim(int id)
        {
            return db.Iletisims.FirstOrDefault(x => x.Id == id);
        }

        // PUT: api/Iletisims/5
        public void PutIletisim(int id,string email, string telefon,string skype, int adresId)
        {
            Iletisim i = db.Iletisims.FirstOrDefault(x => x.Id == id);
            i.Email = email;
            i.Telefon = telefon;
            i.Skype = skype;
            i.AdresId = adresId;
            
            db.SaveChanges();
        
        }

        // POST: api/Iletisims
        public int PostIletisim(string tel, int adresId, string skype, string email)
        {
            Iletisim i = new Iletisim();
            i.Telefon = tel;
            i.AdresId = adresId;
            i.Skype = skype;
            i.Email = email;
            
            db.Iletisims.Add(i);
            db.SaveChanges();
            return i.Id;
        }

        // DELETE: api/Iletisims/5
        
        public void DeleteIletisim(int id)
        {
            Iletisim iletisim = db.Iletisims.FirstOrDefault(x => x.Id == id);
            db.Iletisims.Remove(iletisim);
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

        private bool IletisimExists(int id)
        {
            return db.Iletisims.Count(e => e.Id == id) > 0;
        }
    }
}