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

namespace ASP_Basit_SPA.Controllers
{
    public class UrunsController : ApiController
    {
        private UrunDB db = new UrunDB();

        // GET: api/Uruns
        public IQueryable<Urun> GetUrun()
        {
            return db.Urun;
        }

        // GET: api/Uruns/5
        [ResponseType(typeof(Urun))]
        public IHttpActionResult GetUrun(int id)
        {
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return NotFound();
            }

            return Ok(urun);
        }

        // PUT: api/Uruns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUrun(int id, Urun urun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != urun.Id)
            {
                return BadRequest();
            }

            db.Entry(urun).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExists(id))
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

        // POST: api/Uruns
        [ResponseType(typeof(Urun))]
        public IHttpActionResult PostUrun(Urun urun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Urun.Add(urun);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = urun.Id }, urun);
        }

        // DELETE: api/Uruns/5
        [ResponseType(typeof(Urun))]
        public IHttpActionResult DeleteUrun(int id)
        {
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return NotFound();
            }

            db.Urun.Remove(urun);
            db.SaveChanges();

            return Ok(urun);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UrunExists(int id)
        {
            return db.Urun.Count(e => e.Id == id) > 0;
        }
    }
}