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
    public class IngilizceSeviyesController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/IngilizceSeviyes
        public IQueryable<IngilizceSeviye> GetIngilizceSeviyes()
        {
            return db.IngilizceSeviyes;
        }

        // GET: api/IngilizceSeviyes/5
        [ResponseType(typeof(IngilizceSeviye))]
        public IHttpActionResult GetIngilizceSeviye(int id)
        {
            IngilizceSeviye ingilizceSeviye = db.IngilizceSeviyes.Find(id);
            if (ingilizceSeviye == null)
            {
                return NotFound();
            }

            return Ok(ingilizceSeviye);
        }

        // PUT: api/IngilizceSeviyes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngilizceSeviye(int id, IngilizceSeviye ingilizceSeviye)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingilizceSeviye.Id)
            {
                return BadRequest();
            }

            db.Entry(ingilizceSeviye).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngilizceSeviyeExists(id))
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

        // POST: api/IngilizceSeviyes
        [ResponseType(typeof(IngilizceSeviye))]
        public IHttpActionResult PostIngilizceSeviye(IngilizceSeviye ingilizceSeviye)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngilizceSeviyes.Add(ingilizceSeviye);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingilizceSeviye.Id }, ingilizceSeviye);
        }

        // DELETE: api/IngilizceSeviyes/5
        [ResponseType(typeof(IngilizceSeviye))]
        public IHttpActionResult DeleteIngilizceSeviye(int id)
        {
            IngilizceSeviye ingilizceSeviye = db.IngilizceSeviyes.Find(id);
            if (ingilizceSeviye == null)
            {
                return NotFound();
            }

            db.IngilizceSeviyes.Remove(ingilizceSeviye);
            db.SaveChanges();

            return Ok(ingilizceSeviye);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngilizceSeviyeExists(int id)
        {
            return db.IngilizceSeviyes.Count(e => e.Id == id) > 0;
        }
    }
}