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
            return View(db.Kisis);
        }

        public ActionResult IsEkle()
        {
            return View();
        }

        public ActionResult Randevu()
        {
            return View(db.Kisis);
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
            Kisi k = db.Kisis.Find(Convert.ToInt32(id));
            k.AdminOnay = true;
            db.SaveChanges();
            return RedirectToAction("Index", "YonetimPanel");
        }

        public ActionResult RandevuOnay(string id, string secim)
        {
            Randevu r = db.Randevus.Find(Convert.ToInt32(id));
            r.Onay = true;
            if (secim == "0")
                r.SecilenTarih = r.AlternatifBir;
            else
                r.SecilenTarih = r.AlternatifIki;
            db.SaveChanges();
            return RedirectToAction("Randevu", "YonetimPanel");
        }

    }
}