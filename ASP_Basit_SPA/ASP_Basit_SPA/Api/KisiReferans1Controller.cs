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
    public class KisiReferans1Controller : ApiController
    {
        private Westline db = new Westline();

        // GET: api/KisiReferans1
        public IQueryable<KisiReferan> GetKisiReferans()
        {
            return db.KisiReferans;
        }

        // GET: api/KisiReferans1/5
        public KisiReferan GetKisiReferan(int id)
        {
            return db.KisiReferans.FirstOrDefault(x => x.Id == id);
        }

        // PUT: api/KisiReferans1/5
        public IHttpActionResult PutKisiReferan(int id, KisiReferan kisiReferan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kisiReferan.Id)
            {
                return BadRequest();
            }

            db.Entry(kisiReferan).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KisiReferanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KisiReferans1
        [ResponseType(typeof(KisiReferan))]
        public IHttpActionResult PostKisiReferan(KisiReferan kisiReferan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KisiReferans.Add(kisiReferan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kisiReferan.Id }, kisiReferan);
        }

        // DELETE: api/KisiReferans1/5
        
        public IHttpActionResult DeleteKisiReferan(int id)
        {
            KisiReferan kisiReferan = db.KisiReferans.Find(id);
            if (kisiReferan == null)
            {
                return NotFound();
            }

            db.KisiReferans.Remove(kisiReferan);
            db.SaveChanges();

            return Ok(kisiReferan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KisiReferanExists(int id)
        {
            return db.KisiReferans.Count(e => e.Id == id) > 0;
        }
    }
}