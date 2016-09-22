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
    public class UlkesController : ApiController
    {
        private Westline db = new Westline();
        // GET: api/Ulkes
        public IQueryable<Ulke> GetUlkes()
        {
            return db.Ulkes;
        }
        // GET: api/Ulkes/5
        public Ulke GetUlke(int id)
        {
            return db.Ulkes.FirstOrDefault(x => x.Id == id);
        }
        // PUT: api/Ulkes/5
        public void PutUlke(int id, string gidilenUlkeId)//burda bişeyler oldu !!! 
        {
            Ulke ulke = db.Ulkes.FirstOrDefault(x => x.Id == id);
            db.Ulkes.Add(ulke);
            db.SaveChanges();
        }
        // POST: api/Ulkes
        public int PostUlke(string gidilenUlkeId)
        {
            Ulke ulke = new Ulke();
            

            db.Ulkes.Add(ulke);
            db.SaveChanges();

            return ulke.Id;
        }
        // DELETE: api/Ulkes/5
        public void DeleteUlke(int id)
        {
            Ulke ulke= db.Ulkes.FirstOrDefault(x => x.Id == id);
            db.Ulkes.Remove(ulke);
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
        private bool UlkeExists(int id)
        {
            return db.Ulkes.Count(e => e.Id == id) > 0;
        }
    }
}