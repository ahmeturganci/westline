using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ASP_Basit_SPA;

namespace ASP_Basit_SPA.Api
{
    public class LisesController : ApiController
    {
        private Westline db = new Westline();
        // GET: api/Lises
        public IQueryable<Lise> GetLises()
        {
            return db.Lises;
        }
        // GET: api/Lises/5
        public Lise GetLise(int id)
        {
            return db.Lises.FirstOrDefault(x => x.Id == id);
        }
        // PUT: api/Lises/5
        public void PutLise(int id, string liseAd, int liseAdresId, string mezunYil, string alan)
        {
            Lise l = db.Lises.FirstOrDefault(x => x.Id == id);
            l.Ad = liseAd;
            l.AdresId = liseAdresId;
            l.MezunYilAralik = mezunYil;
            l.Alan = alan;

            db.Lises.Add(l);
            db.SaveChanges();

        }
        // POST: api/Lises
        public int PostLise(string liseAd, int liseAdresId, string mezunYil, string alan)//;
        {
            Lise l = new Lise();
            l.Ad = liseAd;
            l.AdresId = liseAdresId;
            l.MezunYilAralik = mezunYil;
            l.Alan = alan;

            db.Lises.Add(l);
            db.SaveChanges();

            return l.Id;
        }
        // DELETE: api/Lises/5
        public void DeleteLise(int id)
        {
            Lise l = db.Lises.FirstOrDefault(x => x.Id == id);
            db.Lises.Remove(l);
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
        private bool LiseExists(int id)
        {
            return db.Lises.Count(e => e.Id == id) > 0;
        }
    }
}