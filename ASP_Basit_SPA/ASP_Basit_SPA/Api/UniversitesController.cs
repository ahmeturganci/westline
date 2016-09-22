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
        public Universite GetUniversite(int id)
        {
            return db.Universites.FirstOrDefault(x => x.Id == id);
        }
        // PUT: api/Universites/5
        public void PutUniversite(int id, string ad,int sinif, string bolum, string okulNo, DateTime acilisT, DateTime kapanisT, string tel, int adresId)
        {
           Universite u = db.Universites.FirstOrDefault(x => x.Id == id);
            u.Ad = ad;
            u.Sinif = sinif;
            u.Bolum = bolum;
            u.OkulNo = okulNo;
            u.AcilisTarihi = acilisT;
            u.KapanisTarihi = kapanisT;
            u.Tel = tel;
            u.Adre.Id = adresId;

            db.Universites.Add(u);
            db.SaveChanges();
        }
        // POST: api/Universites
        public int  PostUniversite(string ad, int sinif, string bolum, string okulNo, DateTime acilisT, DateTime kapanisT, string tel, int adresId)
        { Universite u = new Universite();
            u.Ad = ad;
            u.Sinif = sinif;
            u.Bolum = bolum;
            u.OkulNo = okulNo;
            u.AcilisTarihi = acilisT;
            u.KapanisTarihi = kapanisT;
            u.Tel = tel;
            u.Adre.Id = adresId;

            db.Universites.Add(u);
            db.SaveChanges();

            return u.Id;
        }
        // DELETE: api/Universites/5
        public void DeleteUniversite(int id)
        {
            Universite uni= db.Universites.FirstOrDefault(x => x.Id == id);
            db.Iletisims.Remove(uni);
            db.SaveChanges();
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