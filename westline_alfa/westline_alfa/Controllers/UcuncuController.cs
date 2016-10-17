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
        public JsonResult EgitimEkle(string liseAd = "", string baslangic = "", string bitis = "",
            string alan = "", string liseTamAdres = "", string liseAdresIkinciSatir = "", int liseEyalet = -1,
            string lisePostaKodu = "",
            string universiteAd = "", int sinif = -1, string bolum = "", string okulNo = "", string acilis = "",
            string kapanis = "", string uniTel = "", string uniTamAdres = "", string uniAdresIkinciSatir = "",
            int uniEyalet = -1, string uniPostaKodu = "")
        {
            helper.helper h = new helper.helper();
            if (h.FormKontrol(liseAd, baslangic, bitis, alan, liseTamAdres, liseEyalet, lisePostaKodu, universiteAd, sinif,
                bolum, okulNo, acilis, kapanis, uniTel, uniTamAdres, uniEyalet, uniPostaKodu) || Session["id"] != null)
            {

                Lise l = new Lise();
                l.Ad = liseAd;
                l.Baslangic = Convert.ToDateTime(baslangic);
                l.Bitis = Convert.ToDateTime(bitis);
                l.Alan = alan;

                Adre a = new Adre();
                a.TamAdres = liseTamAdres;
                a.AdresSatirIki = liseAdresIkinciSatir;
                a.Il = db.Ils.Find(liseEyalet);
                a.PostaKodu = lisePostaKodu;

                db.Adres.Add(a);
                l.Adre = a;

                Universite u = new Universite();
                u.Ad = universiteAd;
                u.Sinif = sinif;
                u.Bolum = bolum;
                u.OkulNo = okulNo;
                u.AcilisTarihi = Convert.ToDateTime(acilis);
                u.KapanisTarihi = Convert.ToDateTime(kapanis);
                u.Tel = uniTel;

                Adre uniA = new Adre();
                uniA.TamAdres = uniTamAdres;
                uniA.AdresSatirIki = uniAdresIkinciSatir;
                uniA.Il = db.Ils.Find(uniEyalet);
                uniA.PostaKodu = uniPostaKodu;

                db.Adres.Add(uniA);
                u.Adre = uniA;

                db.Lises.Add(l);
                db.Universites.Add(u);

                Kisi k = db.Kisis.Find(Session["id"]);
                k.Lise = l;
                k.Universite = u;

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