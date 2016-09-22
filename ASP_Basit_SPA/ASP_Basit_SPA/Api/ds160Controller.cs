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
    public class ds160Controller : ApiController
    {
        private Westline db = new Westline();

        // GET: api/ds160
        public IQueryable<ds160> Getds160()
        {
            return db.ds160;
        }

        // GET: api/ds160/5
        [ResponseType(typeof(ds160))]
        public IHttpActionResult Getds160(int id)
        {
            ds160 ds160 = db.ds160.Find(id);
            if (ds160 == null)
            {
                return NotFound();
            }

            return Ok(ds160);
        }

        // PUT: api/ds160/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putds160(int id, ds160 ds160)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ds160.Id)
            {
                return BadRequest();
            }

            db.Entry(ds160).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ds160Exists(id))
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

        // POST: api/ds160
        [ResponseType(typeof(ds160))]
        public IHttpActionResult Postds160(ds160 ds160)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ds160.Add(ds160);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ds160.Id }, ds160);
        }

        // DELETE: api/ds160/5
        [ResponseType(typeof(ds160))]
        public IHttpActionResult Deleteds160(int id)
        {
            ds160 ds160 = db.ds160.Find(id);
            if (ds160 == null)
            {
                return NotFound();
            }

            db.ds160.Remove(ds160);
            db.SaveChanges();

            return Ok(ds160);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ds160Exists(int id)
        {
            return db.ds160.Count(e => e.Id == id) > 0;
        }
    }
}