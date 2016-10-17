using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class BesinciController : Controller
    {
        // GET: Besinci

        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();

        public JsonResult BesinciSayfa(int dogumYeri = -1, string vatandasUlke = "", int vatandasNo = -1, int ikiVatandasNo = -1, string AbdSsn = "", int amerikadaBulunduMu=-1, string amerikadaBulunmaTarih = "", int amerikaBulunduguSure=0, int oncedenAmerikaVizesi = -1, int oncedenAmerikaVizeRet = -1, string oncedenAmerikaVizeRetNedeni = "", int amerikaVatandasGocmenBasvuru=-1, string babaDogumTarihi = "", int babaAmerikadaMi = -1, int askerlikYapti = -1, int sonBesYil = -1, string anneDogumTarihi = "", int anneAmerikadaMi = -1,string amerikaAkrabaBilgi=""){

            if (h.FormKontrol(dogumYeri, vatandasUlke, vatandasNo, ikiVatandasNo, AbdSsn, anneAmerikadaMi, amerikadaBulunduMu))
            {
                Kisi k = db.Kisis.Find(Session["id"]);
                ds160 ds = new ds160();
                ds.AbdSsn = AbdSsn;
                ds.AmerikaAkrabaBilgi = amerikaAkrabaBilgi;
                ds.AmerikaBulunduguSure = amerikaBulunduguSure.ToString();
                ds.AmerikaBulunduguTarih = Convert.ToDateTime(amerikadaBulunmaTarih);
                ds.AmerikadaBulunduMu = amerikadaBulunduMu == 1 ? true : false; ;
                ds.AmerikaVatandasGocmenBasvuru= amerikaVatandasGocmenBasvuru == 1 ? true : false;
                ds.AnneAmerikadaMi= anneAmerikadaMi == 1 ? true : false;
                ds.BabaAmerikadaMi= babaAmerikadaMi == 1 ? true : false;
                ds.AnneDogumTarihi = Convert.ToDateTime(anneDogumTarihi);
                ds.BabaDogumTarihi = Convert.ToDateTime(babaDogumTarihi);
                ds.DogumYeri = dogumYeri;
                ds.VatandasNo = vatandasNo.ToString();
                ds.IkinciUlkeVatandasNo = ikiVatandasNo.ToString();
                ds.OncedenAmerikaVizesiAldı = oncedenAmerikaVizesi == 1 ? true : false;
                ds.OncedenAmerikaVizeRet = oncedenAmerikaVizeRet == 1 ? true : false;
                ds.OncedenAmerikaVizeRetNedeni = oncedenAmerikaVizeRetNedeni;
                ds.AmerikaVatandasGocmenBasvuru = amerikaVatandasGocmenBasvuru == 1 ? true : false;
                //eksik olabilir.
                db.ds160.Add(ds);
                db.SaveChanges();


                var jsonModel = new
                {
                    basari = 1
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jsonModel = new
                {
                    basari = 0
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }

        }
    }
}