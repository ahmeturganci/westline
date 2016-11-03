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

        public ActionResult OgrenciDetay(int id)
        {
            return View(db.Kullanicis.Find(id));
        }

        public ActionResult TaksitveOnay(float ucret, int taksitSayi, int kullaniciId)
        {
            y.Taksitlendir(ucret,taksitSayi,kullaniciId);
            return RedirectToAction("Index", "YonetimPanel");
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


        [HttpPost]
        public JsonResult SozlesmeOnay( int sozlesmeId)
        {
            return y.SozlesmeOnay(sozlesmeId,Convert.ToInt32(Session["id"]));
        }

        [HttpPost]
        public ActionResult UploadWat(int id)
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
            return RedirectToAction("OgrenciDetay/"+id, "YonetimPanel");
        }

        [HttpPost]
        public ActionResult UploadDs(int id)
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

        [HttpPost]
        public ActionResult UploadSevis(int id)
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
            return RedirectToAction("OgrenciDetay/"+id, "YonetimPanel");
        }

        public JsonResult InputEkle(string metin, string metinplace, int tur, int zorunludurum, int sayfanum)
        {
            return y.InputEkle(metin, metinplace, tur, zorunludurum, sayfanum);
        }



        public ActionResult RandevuOnay(string kulid, string btnid)
        {
            int kulId = Convert.ToInt32(kulid);
            int btnId = Convert.ToInt32(btnid);
            Kullanici k = db.Kullanicis.Find(kulId);
            if(btnId != 0)
            {   
                KullaniciRandevu kr = db.KullaniciRandevus.FirstOrDefault(x => x.KullaniciId == kulId && x.RandevuId == btnId);
                kr.Onay = true;
                db.SaveChanges();
                y.MailGonder(k.Degers.FirstOrDefault(x=>x.InputId==5).Icerik, "Randevunuz Onaylandı!", "Randevunuz onaylanmıştır. Gideceğiniz tarih: " + kr.Randevu.Tarih);
                helper.smsapi sms = new helper.smsapi("5399706684", "03011995e", "ILETI MRKZI");
                sms.SendSMS(new string[] { k.Degers.FirstOrDefault(x=>x.InputId==6).Icerik }," Randevunuz onaylanmıştır.Gideceğiniz tarih: " + kr.Randevu.Tarih);
                db.SayfaDurums.FirstOrDefault(x => x.KullaniciId == kulId && x.SayfaId == btnId).Durum = true;
                db.SaveChanges();
            }
            else
            {
                foreach (var item in db.KullaniciRandevus.Where(x=>x.KullaniciId==kulId))
                {
                    db.KullaniciRandevus.Remove(item);
                }
                db.SaveChanges();
                y.MailGonder(k.Degers.FirstOrDefault(x => x.InputId == 5).Icerik, "Randevunuz Reddedildi!", "Randevunuz reddedilmiştir. Lütfen yeniden seçim yapınız");
                helper.smsapi sms = new helper.smsapi("5399706684", "03011995e", "ILETI MRKZI");
                sms.SendSMS(new string[] { k.Degers.FirstOrDefault(x => x.InputId == 6).Icerik }, "Randevunuz reddedilmiştir. Lütfen yeniden seçim yapınız");
            }
            
            return RedirectToAction("OgrenciDetay/" + kulId, "YonetimPanel");
        }
    }
}