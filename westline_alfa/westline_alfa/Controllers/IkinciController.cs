using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class IkinciController : Controller
    {
        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();

        // GET: Ikinci
        public JsonResult KisiDetayEkle(string babaAd = "", string anneAdSoyad = "", int ingilizceSeviye = -1,
            int pasaport = -1, string dogumTarih = "", string skype = "",
            string tamAdres = "", string adresIkinciSatir = "", int eyalet = -1,
            string postaKodu = "",
            int adresEyaletId = -1, string acilAd = "", string acilSoyad = "", string acilTel = "")
        {
            if (h.FormKontrol(babaAd, anneAdSoyad, ingilizceSeviye, tamAdres, pasaport, dogumTarih, tamAdres, eyalet, postaKodu,
                adresEyaletId, acilAd, acilSoyad, acilTel))
            {
                Kisi k = db.Kisis.Find(Session["id"]);
                k.BabaAdi = babaAd;
                k.AnneAdi = anneAdSoyad;
                k.IngilizceSeviye = db.IngilizceSeviyes.Find(ingilizceSeviye);
                k.Pasaport = pasaport == 1 ? true : false;
                //k.DogumTarihi = Convert.ToDateTime(dogumTarih) ;
                k.Iletisim.Skype = skype;

                Adre a = new Adre();
                a.TamAdres = tamAdres;
                a.AdresSatirIki = adresIkinciSatir;
                a.Il = db.Ils.Find(adresEyaletId);
                a.PostaKodu = postaKodu;

                AcilDurum ac = new AcilDurum();
                ac.Ad = acilAd;
                ac.Soyad = acilSoyad;
                ac.Telefon = acilTel;
                db.AcilDurums.Add(ac);

                db.Adres.Add(a);
                k.Iletisim.Adre = a;


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

        public JsonResult UlkeCek()
        {
            return h.Ulkeler();
        }

        public JsonResult EyaletCek(int id)
        {
            return h.Iller(id);
        }

        public JsonResult IngilizceCek()
        {
            return h.IngilizceSeviyeler();
        }
    }
}