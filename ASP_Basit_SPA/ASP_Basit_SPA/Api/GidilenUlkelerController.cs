﻿using System;
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
    public class GidilenUlkelerController : ApiController
    {
        private Westline db = new Westline();

        // GET: api/GidilenUlkeler
        public IQueryable<GidilenUlkeler> GetGidilenUlkelers()
        {
            return db.GidilenUlkelers;
        }

        // GET: api/GidilenUlkeler/5
        [ResponseType(typeof(GidilenUlkeler))]
        public IHttpActionResult GetGidilenUlkeler(int id)
        {
            GidilenUlkeler gidilenUlkeler = db.GidilenUlkelers.Find(id);
            if (gidilenUlkeler == null)
            {
                return NotFound();
            }

            return Ok(gidilenUlkeler);
        }

        // PUT: api/GidilenUlkeler/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGidilenUlkeler(int id, GidilenUlkeler gidilenUlkeler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gidilenUlkeler.Id)
            {
                return BadRequest();
            }

            db.Entry(gidilenUlkeler).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GidilenUlkelerExists(id))
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

        // POST: api/GidilenUlkeler
        [ResponseType(typeof(GidilenUlkeler))]
        public IHttpActionResult PostGidilenUlkeler(GidilenUlkeler gidilenUlkeler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GidilenUlkelers.Add(gidilenUlkeler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gidilenUlkeler.Id }, gidilenUlkeler);
        }

        // DELETE: api/GidilenUlkeler/5
        [ResponseType(typeof(GidilenUlkeler))]
        public IHttpActionResult DeleteGidilenUlkeler(int id)
        {
            GidilenUlkeler gidilenUlkeler = db.GidilenUlkelers.Find(id);
            if (gidilenUlkeler == null)
            {
                return NotFound();
            }

            db.GidilenUlkelers.Remove(gidilenUlkeler);
            db.SaveChanges();

            return Ok(gidilenUlkeler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GidilenUlkelerExists(int id)
        {
            return db.GidilenUlkelers.Count(e => e.Id == id) > 0;
        }
    }
}