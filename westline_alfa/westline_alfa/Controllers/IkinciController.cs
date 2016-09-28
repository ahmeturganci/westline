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
        public JsonResult KisiDetayEkle(int id = -1,string babaAd = "", string anneAdSoyad = "", int ingilizceSeviye=-1, 
            bool pasaport = false, DateTime? dogumTarih = null, string skype="", 
            string tamAdres="", string adresIkinciSatir = "", string sehir = "", int eyalet = -1,
            string postaKodu = "", int ulkeId = -1, string acilAd = "", string acilSoyad = "",string acilTel = "")
        {
            if (h.FormKontrol(id, babaAd, anneAdSoyad, ingilizceSeviye, tamAdres, sehir, acilAd, acilSoyad, acilTel))
            {
                Kisi k = db.Kisis.Find(id);
                k.BabaAdi = babaAd;
                k.AnneAdi = anneAdSoyad;
                k.IngilizceSeviye = ingilizceSeviye;
                k.Pasaport = pasaport;
                k.DogumTarihi = dogumTarih;
                k.Iletisim.Skype = skype;
                k.Iletisim.Adre.TamAdres = tamAdres;
                k.Iletisim.Adre.AdresSatirIki = adresIkinciSatir;
                k.Iletisim.Adre.Sehir = sehir;

                //find eyalet

                k.Iletisim.Adre.PostaKodu = postaKodu;

                //find Ulke
                AcilDurum a = new AcilDurum();
                a.Ad = acilAd;
                a.Soyad = acilSoyad;
                a.Telefon = acilTel;

                db.AcilDurums.Add(a);

                k.AcilDurum = a;

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
    }
}