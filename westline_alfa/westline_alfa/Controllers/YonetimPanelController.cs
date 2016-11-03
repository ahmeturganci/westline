using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class YonetimPanelController : Controller
    {
        westlineDB db = new westlineDB();
        helper.Yardimci y = new helper.Yardimci();
        // GET: YonetimPanel
        public ActionResult Index()
        {
            if (Session["adminId"] != null)
            {
                return View(db.Kullanicis);

            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult KullaniciDosya()
        {
            if (Session["adminId"] != null)
            {
                return View(db.Kullanicis);
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult IsEkle()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult profilInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult CvInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult RandevuAlInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult IslerInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult BirinciSayfaInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult IkinciSayfaInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult UcuncuSayfaInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult DorduncuSayfaInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult BesinciSayfaInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult UcakBilgiInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult AktivasyonInput()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        public ActionResult Randevu()
        {
            if (Session["adminId"] != null)
            {
                return View(db.Kullanicis);
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult OgrenciListele()
        {
            if (Session["adminId"] != null)
            {
                return View(db.Kullanicis);
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult OgrenciDetay(int id)
        {
            if (Session["adminId"] != null)
            {
                return View(db.Kullanicis.Find(id));
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult TaksitveOnay(float ucret, int taksitSayi, int kullaniciId)
        {
            if (Session["adminId"] != null)
            {
                y.Taksitlendir(ucret, taksitSayi, kullaniciId);
            return RedirectToAction("Index", "YonetimPanel");
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public ActionResult Is(string ad, string aciklama)
        {
            if (Session["adminId"] != null)
            {
                Isler i = new Isler();
            i.Ad = ad;
            i.Aciklama = aciklama;
            db.Islers.Add(i);
            db.SaveChanges();
            return RedirectToAction("IsEkle", "YonetimPanel");
            }
            else
                return RedirectToAction("Index", "Giris");
        }


        public ActionResult RandevuOnay(string id, string secim)
        {
            if (Session["adminId"] != null)
            {
                int Id = Convert.ToInt32(id);
            int Secim = Convert.ToInt32(secim);
            Deger d = db.Degers.FirstOrDefault(x => x.Id == Secim && x.KisiId == Id);
            d.Onay = true;

            Kullanici k = db.Kullanicis.Find(Id);
            k.RandevuOnay = true;

            db.SaveChanges();
            return RedirectToAction("Randevu", "YonetimPanel");
            }
            else
                return RedirectToAction("Index", "Giris");
        }
        [HttpPost]
        public JsonResult SozlesmeOnay(int sozlesmeId)
        {
            if (Session["adminId"] != null)
            {
                return y.SozlesmeOnay(sozlesmeId, Convert.ToInt32(Session["id"]));
            }
            else
                return Json("No access",JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadWat(int id)
        {
            if (Session["adminId"] != null)
            {
                if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0 && file.ContentType == "application/pdf")
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                    Sozlesme s = new Sozlesme();
                    s.SozlesmeTur = 1;
                    s.Url = fileName;
                    s.KullaniciId = id;
                    s.Onay = true;

                    db.Sozlesmes.Add(s);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("OgrenciDetay/" + id, "YonetimPanel");
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        [HttpPost]
        public ActionResult UploadDs(int id)
        {
            if (Session["adminId"] != null)
            {
                if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0 && file.ContentType == "application/pdf")
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                    Sozlesme s = new Sozlesme();
                    s.SozlesmeTur = 2;
                    s.Url = fileName;
                    s.KullaniciId = id;
                    s.Onay = true;

                    db.Sozlesmes.Add(s);

                    db.SayfaDurums.FirstOrDefault(x => x.SayfaId == 9 && x.KullaniciId == id).Durum = true;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("OgrenciDetay/" + id, "YonetimPanel");
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        [HttpPost]
        public ActionResult UploadSevis(int id)
        {
            if (Session["adminId"] != null)
            {
                if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0 && file.ContentType == "application/pdf")
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("OgrenciDetay/1", "YonetimPanel");
            }
            else
                return RedirectToAction("Index", "Giris");
        }

        public JsonResult InputEkle(string metin, string metinplace, int tur, int zorunludurum, int sayfanum)
        {
            if (Session["adminId"] != null)
            {
                return y.InputEkle(metin, metinplace, tur, zorunludurum, sayfanum);
            }
            else
                return Json("No access", JsonRequestBehavior.AllowGet);

        }
    }
}