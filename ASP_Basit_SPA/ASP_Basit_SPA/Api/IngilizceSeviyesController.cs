﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace ASP_Basit_SPA.Api
{
    public class IngilizceSeviyesController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/IngilizceSeviyes
        public IQueryable<IngilizceSeviye> GetIngilizceSeviyes()
        {
            return db.IngilizceSeviyes;
        }

        // GET: api/IngilizceSeviyes/5
        public IngilizceSeviye GetIngilizceSeviye(int id)
        {
            return db.IngilizceSeviyes.FirstOrDefault(x => x.Id == id);
        }

        // PUT: api/IngilizceSeviyes/5
        public void PutIngilizceSeviye(int id, string seviyeAd)
        {
            IngilizceSeviye ingS = db.IngilizceSeviyes.FirstOrDefault(x => x.Id == id);
            ingS.SeviyeAdi = seviyeAd;

            db.SaveChanges();
        }

        // POST: api/IngilizceSeviyes
        public int PostIngilizceSeviye(string seviyeAde)
        {
            IngilizceSeviye ingS = new IngilizceSeviye { SeviyeAdi = seviyeAde };
            db.IngilizceSeviyes.Add(ingS);
            db.SaveChanges();
            return ingS.Id;
        }

        // DELETE: api/IngilizceSeviyes/5
        [ResponseType(typeof(IngilizceSeviye))]
        public void DeleteIngilizceSeviye(int id)
        {
            IngilizceSeviye ingS = db.IngilizceSeviyes.FirstOrDefault(x=>x.Id==id);
            db.IngilizceSeviyes.Remove(ingS);
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

        private bool IngilizceSeviyeExists(int id)
        {
            return db.IngilizceSeviyes.Count(e => e.Id == id) > 0;
        }
    }
}