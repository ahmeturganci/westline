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
    public class UniversitesController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/Universites
        public IQueryable<Universite> GetUniversites()
        {
            return db.Universites;
        }

        // GET: api/Universites/5
        [ResponseType(typeof(Universite))]
        public IHttpActionResult GetUniversite(int id)
        {
            Universite universite = db.Universites.Find(id);
            if (universite == null)
            {
                return NotFound();
            }

            return Ok(universite);
        }

        // PUT: api/Universites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUniversite(int id, Universite universite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != universite.Id)
            {
                return BadRequest();
            }

            db.Entry(universite).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversiteExists(id))
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

        // POST: api/Universites
        [ResponseType(typeof(Universite))]
        public IHttpActionResult PostUniversite(Universite universite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Universites.Add(universite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = universite.Id }, universite);
        }

        // DELETE: api/Universites/5
        [ResponseType(typeof(Universite))]
        public IHttpActionResult DeleteUniversite(int id)
        {
            Universite universite = db.Universites.Find(id);
            if (universite == null)
            {
                return NotFound();
            }

            db.Universites.Remove(universite);
            db.SaveChanges();

            return Ok(universite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UniversiteExists(int id)
        {
            return db.Universites.Count(e => e.Id == id) > 0;
        }
    }
}