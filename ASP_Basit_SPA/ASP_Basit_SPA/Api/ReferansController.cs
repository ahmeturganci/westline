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
    public class ReferansController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/Referans
        public IQueryable<Referan> GetReferans()
        {
            return db.Referans;
        }

        // GET: api/Referans/5
        [ResponseType(typeof(Referan))]
        public IHttpActionResult GetReferan(int id)
        {
            Referan referan = db.Referans.Find(id);
            if (referan == null)
            {
                return NotFound();
            }

            return Ok(referan);
        }

        // PUT: api/Referans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReferan(int id, Referan referan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referan.Id)
            {
                return BadRequest();
            }

            db.Entry(referan).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferanExists(id))
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

        // POST: api/Referans
        [ResponseType(typeof(Referan))]
        public IHttpActionResult PostReferan(Referan referan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Referans.Add(referan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = referan.Id }, referan);
        }

        // DELETE: api/Referans/5
        [ResponseType(typeof(Referan))]
        public IHttpActionResult DeleteReferan(int id)
        {
            Referan referan = db.Referans.Find(id);
            if (referan == null)
            {
                return NotFound();
            }

            db.Referans.Remove(referan);
            db.SaveChanges();

            return Ok(referan);
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