using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ASP_Basit_SPA.Api
{
    public class DilsController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/Dils
        public IQueryable<Dil> GetDils()
        {
            return db.Dils;
        }

        // GET: api/Dils/5
        public Dil GetDil(int id)
        {
            return db.Dils.FirstOrDefault(x=>x.Id==id);
        }

        // PUT: api/Dils/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDil(int id, Dil dil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dil.Id)
            {
                return BadRequest();
            }

            db.Entry(dil).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DilExists(id))
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

        // POST: api/Dils
        [ResponseType(typeof(Dil))]
        public IHttpActionResult PostDil(Dil dil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dils.Add(dil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dil.Id }, dil);
        }

        // DELETE: api/Dils/5
        [ResponseType(typeof(Dil))]
        public IHttpActionResult DeleteDil(int id)
        {
            Dil dil = db.Dils.Find(id);
            if (dil == null)
            {
                return NotFound();
            }

            db.Dils.Remove(dil);
            db.SaveChanges();

            return Ok(dil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DilExists(int id)
        {
            return db.Dils.Count(e => e.Id == id) > 0;
        }
    }
}