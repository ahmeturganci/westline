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
        [ResponseType(typeof(Lise))]
        public IHttpActionResult GetLise(int id)
        {
            Lise lise = db.Lises.Find(id);
            if (lise == null)
            {
                return NotFound();
            }

            return Ok(lise);
        }

        // PUT: api/Lises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLise(int id, Lise lise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lise.Id)
            {
                return BadRequest();
            }

            db.Entry(lise).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiseExists(id))
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

        // POST: api/Lises
        [ResponseType(typeof(Lise))]
        public IHttpActionResult PostLise(Lise lise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lises.Add(lise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lise.Id }, lise);
        }

        // DELETE: api/Lises/5
        [ResponseType(typeof(Lise))]
        public IHttpActionResult DeleteLise(int id)
        {
            Lise lise = db.Lises.Find(id);
            if (lise == null)
            {
                return NotFound();
            }

            db.Lises.Remove(lise);
            db.SaveChanges();

            return Ok(lise);
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