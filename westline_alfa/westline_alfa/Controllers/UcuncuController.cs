using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class UcuncuController : Controller
    {
        westlineDB db = new westlineDB(); 
        public JsonResult EgitimEkle(string liseAd = "", DateTime? baslangic = null, DateTime? bitis = null, 
            string alan = "",string liseTamAdres = "", string liseAdresIkinciSatir = "", string liseSehir = "", 
            int liseEyalet = -1, string lisePostaKodu = "", int liseUlkeId = -1,
            string universiteAd = "", string sinif = "", string bolum = "", string okulNo="", DateTime? acilis=null,
            DateTime? kapanis = null, string uniTamAdres = "", string uniAdresIkinciSatir = "", string uniSehir = "",
            int uniEyalet = -1, string uniPostaKodu = "", int uniUlkeId = -1)
        {
            Lise l = new Lise();
            l.Ad = liseAd;
            l.Baslangic = baslangic;
            l.Bitis = bitis;
            l.Alan = alan;

            Adre a = new Adre();
            a.TamAdres = liseTamAdres;
            a.AdresSatirIki = liseAdresIkinciSatir;
            a.Sehir = liseSehir;
            a.Eyalet = db.Eyalets.Find(liseEyalet);
            a.PostaKodu = lisePostaKodu;
            a.Ulke = db.Ulkes.Find(liseUlkeId);

            db.Adres.Add(a);
            l.AdresId = a.Id;

            Universite u = new Universite();
            //buraya üniversite id alınacak

            var jsonModel = new
            {
                basari = 1
            };
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
    }
}