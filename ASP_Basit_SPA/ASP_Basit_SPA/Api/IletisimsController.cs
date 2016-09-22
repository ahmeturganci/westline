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
    public class IletisimsController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/Iletisims
        public IQueryable<Iletisim> GetIletisims()
        {
            return db.Iletisims;
        }

        // GET: api/Iletisims/5
        [ResponseType(typeof(Iletisim))]
        public IHttpActionResult GetIletisim(int id)
        {
            Iletisim iletisim = db.Iletisims.Find(id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return Ok(iletisim);
        }

        // PUT: api/Iletisims/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIletisim(int id, Iletisim iletisim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iletisim.Id)
            {
                return BadRequest();
            }

            db.Entry(iletisim).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IletisimExists(id))
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

        // POST: api/Iletisims
        [ResponseType(typeof(Iletisim))]
        public IHttpActionResult PostIletisim(Iletisim iletisim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Iletisims.Add(iletisim);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iletisim.Id }, iletisim);
        }

        // DELETE: api/Iletisims/5
        [ResponseType(typeof(Iletisim))]
        public IHttpActionResult DeleteIletisim(int id)
        {
            Iletisim iletisim = db.Iletisims.Find(id);
            if (iletisim == null)
            {
                return NotFound();
            }

            db.Iletisims.Remove(iletisim);
            db.SaveChanges();

            return Ok(iletisim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IletisimExists(int id)
        {
            return db.Iletisims.Count(e => e.Id == id) > 0;
        }
    }
}