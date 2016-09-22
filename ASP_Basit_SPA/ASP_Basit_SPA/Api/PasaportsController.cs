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
    public class PasaportsController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/Pasaports
        public IQueryable<Pasaport> GetPasaports()
        {
            return db.Pasaports;
        }

        // GET: api/Pasaports/5
        [ResponseType(typeof(Pasaport))]
        public IHttpActionResult GetPasaport(int id)
        {
            Pasaport pasaport = db.Pasaports.Find(id);
            if (pasaport == null)
            {
                return NotFound();
            }

            return Ok(pasaport);
        }

        // PUT: api/Pasaports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasaport(int id, Pasaport pasaport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasaport.Id)
            {
                return BadRequest();
            }

            db.Entry(pasaport).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasaportExists(id))
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

        // POST: api/Pasaports
        [ResponseType(typeof(Pasaport))]
        public IHttpActionResult PostPasaport(Pasaport pasaport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pasaports.Add(pasaport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pasaport.Id }, pasaport);
        }

        // DELETE: api/Pasaports/5
        [ResponseType(typeof(Pasaport))]
        public IHttpActionResult DeletePasaport(int id)
        {
            Pasaport pasaport = db.Pasaports.Find(id);
            if (pasaport == null)
            {
                return NotFound();
            }

            db.Pasaports.Remove(pasaport);
            db.SaveChanges();

            return Ok(pasaport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasaportExists(int id)
        {
            return db.Pasaports.Count(e => e.Id == id) > 0;
        }
    }
}