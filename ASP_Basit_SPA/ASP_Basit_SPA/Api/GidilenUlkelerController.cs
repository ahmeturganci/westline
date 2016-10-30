using System.Linq;
using System.Web.Http;

namespace ASP_Basit_SPA.Api
{
    public class GidilenUlkelerController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/GidilenUlkeler
        public IQueryable<GidilenUlkeler> GetGidilenUlkelers()
        {
            return db.GidilenUlkelers;
        }

        // GET: api/GidilenUlkeler/5
        public GidilenUlkeler  GetGidilenUlkeler(int id)
        {
            return db.GidilenUlkelers.FirstOrDefault(x =>x.Id == id);
        }

        // PUT: api/GidilenUlkeler/5
        public void PutGidilenUlkeler(int id, int kisiId ,int ulkeId)
        {
            GidilenUlkeler gu = db.GidilenUlkelers.FirstOrDefault(x => x.Id == id);

            gu.KisiId = kisiId;
            gu.UlkeId = ulkeId;

            db.SaveChanges();
        }

        // POST: api/GidilenUlkeler
        
        public int PostGidilenUlkeler(int kisiId, int ulkeId)
        {
            GidilenUlkeler gu = new GidilenUlkeler();
            gu.KisiId = kisiId;
            gu.UlkeId = ulkeId;

            db.GidilenUlkelers.Add(gu);
            db.SaveChanges();

            return gu.Id;
        }

        // DELETE: api/GidilenUlkeler/5
        public void DeleteGidilenUlkeler(int id)
        {
            GidilenUlkeler gu = db.GidilenUlkelers.FirstOrDefault(x=>x.Id==id);
            db.GidilenUlkelers.Remove(gu);
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

        private bool GidilenUlkelerExists(int id)
        {
            return db.GidilenUlkelers.Count(e => e.Id == id) > 0;
        }
    }
}