using System;
using System.Linq;
using System.Web.Http;

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
        public ds160 Getds160(int id)
        {
            return db.ds160.FirstOrDefault(x => x.Id == id);
        }

        // PUT: api/ds160/5
        public void Putds160(int id, int dogumYerId,int dogumUlkeId,int vatandasUlkeId,
            string ikinciUlkeVatandasNo,string abdSsn, bool amerikaBulunma,DateTime amerikaBulunmaTarih,
            string amerikaBulunduguSure,bool oAmerikaVize, DateTime oAmerikaVizeTarih,
            string oAmerikaVizeNo,bool oAmerikaRet,string oAmerikaRetNeden,
            bool amerikaVatandasGocmenBasvur,DateTime babaDogum,bool babaAmerikadami, 
            DateTime anneDogum, bool anneAmerikadami,string amerikaAkrabaBilgi,int pasportId,
            bool sonBesYilYurdDisiGittimi,bool askerlik,bool tutuklanmaSicil, int pasId)
        {
            ds160 ds = db.ds160.FirstOrDefault(x => x.Id == id);
            ds.DogumYeri = dogumYerId;
            ds.DogumUlke = dogumUlkeId;
            ds.VatandasUlke = vatandasUlkeId;
            ds.IkinciUlkeVatandasNo = ikinciUlkeVatandasNo;
            ds.AbdSsn = abdSsn;
            ds.AmerikadaBulunduMu = amerikaBulunma;
            ds.AmerikaBulunduguTarih = amerikaBulunmaTarih;
            ds.AmerikaBulunduguSure = amerikaBulunduguSure;
            ds.OncedenAmerikaVizesiAldı = oAmerikaVize;
            ds.OncedenAmerikaVizesiTarih = oAmerikaVizeTarih;
            ds.OncedenAmerikaVizeNo = oAmerikaVizeNo;
            ds.OncedenAmerikaVizeRet = oAmerikaRet;
            ds.OncedenAmerikaVizeRetNedeni = oAmerikaRetNeden;
            ds.AmerikaVatandasGocmenBasvuru = amerikaVatandasGocmenBasvur;
            ds.BabaDogumTarihi = babaDogum;
            ds.BabaAmerikadaMi = babaAmerikadami;
            ds.AnneDogumTarihi = anneDogum;
            ds.AnneAmerikadaMi = anneAmerikadami;
            ds.PasaportId = pasportId;
            ds.SonBesYilYurtdisiGitti = sonBesYilYurdDisiGittimi;
            ds.AskerlikYapti = askerlik;
            ds.TutuklanmaSicil = tutuklanmaSicil;
            ds.Pasaport.Id = pasId;
            
            db.SaveChanges();
        }

        // POST: api/ds160
        public int Postds160(int dogumYerId, int dogumUlkeId, int vatandasUlkeId,
            string ikinciUlkeVatandasNo, string abdSsn, bool amerikaBulunma, DateTime amerikaBulunmaTarih,
            string amerikaBulunduguSure, bool oAmerikaVize, DateTime oAmerikaVizeTarih,
            string oAmerikaVizeNo, bool oAmerikaRet, string oAmerikaRetNeden,
            bool amerikaVatandasGocmenBasvur, DateTime babaDogum, bool babaAmerikadami,
            DateTime anneDogum, bool anneAmerikadami, string amerikaAkrabaBilgi, int pasportId,
            bool sonBesYilYurdDisiGittimi, bool askerlik, bool tutuklanmaSicil, int pasId)
        {
            ds160 ds = new ds160();
            ds.DogumYeri = dogumYerId;
            ds.DogumUlke = dogumUlkeId;
            ds.VatandasUlke = vatandasUlkeId;
            ds.IkinciUlkeVatandasNo = ikinciUlkeVatandasNo;
            ds.AbdSsn = abdSsn;
            ds.AmerikadaBulunduMu = amerikaBulunma;
            ds.AmerikaBulunduguTarih = amerikaBulunmaTarih;
            ds.AmerikaBulunduguSure = amerikaBulunduguSure;
            ds.OncedenAmerikaVizesiAldı = oAmerikaVize;
            ds.OncedenAmerikaVizesiTarih = oAmerikaVizeTarih;
            ds.OncedenAmerikaVizeNo = oAmerikaVizeNo;
            ds.OncedenAmerikaVizeRet = oAmerikaRet;
            ds.OncedenAmerikaVizeRetNedeni = oAmerikaRetNeden;
            ds.AmerikaVatandasGocmenBasvuru = amerikaVatandasGocmenBasvur;
            ds.BabaDogumTarihi = babaDogum;
            ds.BabaAmerikadaMi = babaAmerikadami;
            ds.AnneDogumTarihi = anneDogum;
            ds.AnneAmerikadaMi = anneAmerikadami;
            ds.PasaportId = pasportId;
            ds.SonBesYilYurtdisiGitti = sonBesYilYurdDisiGittimi;
            ds.AskerlikYapti = askerlik;
            ds.TutuklanmaSicil = tutuklanmaSicil;
            ds.Pasaport.Id = pasId;

            db.ds160.Add(ds);
            db.SaveChanges();

            return ds.Id;
        }

        // DELETE: api/ds160/5
        public void Deleteds160(int id)
        {
            ds160 ds = db.ds160.FirstOrDefault(x=>x.Id==id);
           
            db.ds160.Remove(ds);
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

        private bool ds160Exists(int id)
        {
            return db.ds160.Count(e => e.Id == id) > 0;
        }
    }
}