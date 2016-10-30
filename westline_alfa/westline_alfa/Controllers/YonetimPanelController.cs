using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class YonetimPanelController : Controller
    {
        westlineDB db = new westlineDB();
        // GET: YonetimPanel
        public ActionResult Index()
        {
            return View(db.Kullanicis);
        }

        public ActionResult KullaniciDosya()
        {
            return View(db.Kullanicis);
        }
            public ActionResult IsEkle()
        {
            return View();
        }

        public ActionResult profilInput()
        {
            return View();
        }
        public ActionResult CvInput()
        {
            return View();
        }
        public ActionResult RandevuAlInput()
        {
            return View();
        }
        public ActionResult IslerInput()
        {
            return View();
        }
        public ActionResult BirinciSayfaInput()
        {
            return View();
        }
        public ActionResult IkinciSayfaInput()
        {
            return View();
        }
        public ActionResult UcuncuSayfaInput()
        {
            return View();
        }
        public ActionResult DorduncuSayfaInput()
        {
            return View();
        }
        public ActionResult BesinciSayfaInput()
        {
            return View();
        }
        public ActionResult UcakBilgiInput()
        {
            return View();
        }
        public ActionResult AktivasyonInput()
        {
            return View();
        }
        public ActionResult Randevu()
        {
            return View(db.Kullanicis);
        }

        public ActionResult OgrenciListele()
        {
            return View(db.Kullanicis);
        }

        public ActionResult Is(string ad, string aciklama)
        {
            Isler i = new Isler();
            i.Ad = ad;
            i.Aciklama = aciklama;
            db.Islers.Add(i);
            db.SaveChanges();
            return RedirectToAction("IsEkle", "YonetimPanel");
        }

        public ActionResult OnayVer(string id)
        {
            int Id = Convert.ToInt32(id);
            Kullanici k = db.Kullanicis.Find(Id);
            k.AdminOnay = true;
            db.SaveChanges();
            return RedirectToAction("Index", "YonetimPanel");
        }

        public ActionResult RandevuOnay(string id, string secim)
        {
            int Id = Convert.ToInt32(id);
            int Secim = Convert.ToInt32(secim);
            Deger d = db.Degers.FirstOrDefault(x=>x.Id == Secim && x.KisiId == Id);
            d.Onay = true;

            Kullanici k = db.Kullanicis.Find(Id);
            k.RandevuOnay = true;

            db.SaveChanges();
            return RedirectToAction("Randevu", "YonetimPanel");
        }

    }
}