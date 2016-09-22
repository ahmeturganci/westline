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
        [ResponseType(typeof(Ulke))]
        public IHttpActionResult GetUlke(int id)
        {
            Ulke ulke = db.Ulkes.Find(id);
            
            if (ulke == null)
            {
                return NotFound();
            }

            return Ok(ulke);
        }

        // PUT: api/Ulkes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUlke(int id, Ulke ulke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ulke.Id)
            {
                return BadRequest();
            }

            db.Entry(ulke).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlkeExists(id))
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

        // POST: api/Ulkes
        [ResponseType(typeof(Ulke))]
        public IHttpActionResult PostUlke(Ulke ulke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ulkes.Add(ulke);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ulke.Id }, ulke);
        }

        // DELETE: api/Ulkes/5
        [ResponseType(typeof(Ulke))]
        public IHttpActionResult DeleteUlke(int id)
        {
            Ulke ulke = db.Ulkes.Find(id);
            if (ulke == null)
            {
                return NotFound();
            }

            db.Ulkes.Remove(ulke);
            db.SaveChanges();

            return Ok(ulke);
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