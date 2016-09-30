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
        public JsonResult KisiDetayEkle(string babaAd = "", string anneAdSoyad = "", int ingilizceSeviye=-1, 
            int pasaport = -1, DateTime? dogumTarih = null, string skype="", 
            string tamAdres="", string adresIkinciSatir = "", int eyalet = -1,
            string postaKodu = "", int ulkeId = -1,
            int adresEyaletId = -1, int adresUlkeId = -1)
        {
            if (h.FormKontrol(babaAd, anneAdSoyad, ingilizceSeviye, tamAdres))
            {
                Kisi k = db.Kisis.Find(Session["id"]);
                k.BabaAdi = babaAd;
                k.AnneAdi = anneAdSoyad;
                k.IngilizceSeviye = ingilizceSeviye;
                k.Pasaport = pasaport == 1 ? true : false;
                k.DogumTarihi = dogumTarih;
                k.Iletisim.Skype = skype;

                k.Iletisim.Adre.TamAdres = tamAdres;
                k.Iletisim.Adre.AdresSatirIki = adresIkinciSatir;
                k.Iletisim.Adre.Eyalet = db.Eyalets.Find(adresEyaletId);
                k.Iletisim.Adre.Ulke = db.Ulkes.Find(adresUlkeId);

                //find eyalet

                k.Iletisim.Adre.PostaKodu = postaKodu;

                

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

        public JsonResult EyaletCek()
        {
            return h.Eyaletler();
        }
    }
}