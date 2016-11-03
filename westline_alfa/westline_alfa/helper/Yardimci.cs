using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.helper
{
    public class Yardimci : Controller
    {
        westlineDB db = new westlineDB();

        SmtpClient smtp;
        public Yardimci()
        {
            smtp = new SmtpClient();
            smtp.Host = "smtp.yandex.ru";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("okan.deneme", "123456789b");
        }

        public JsonResult SozlesmeEkle(int sozlesmeId, int kullaniciId)
        {
            Sozlesme s = new Sozlesme();
            s.SozlesmeTur = sozlesmeId;
            s.KullaniciId = kullaniciId;
            s.Onay = false;
            db.Sozlesmes.Add(s);
            db.SaveChanges();
            var jsonResult = new
            {
                basari = 1
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SozlesmeOnay(int sozlesmeId, int kullaniciId)
        {

            if (db.Sozlesmes.Any(x => x.Id == sozlesmeId && x.KullaniciId == kullaniciId))
            {
                Sozlesme s = db.Sozlesmes.FirstOrDefault(x => x.Id == sozlesmeId && x.KullaniciId == kullaniciId);
                s.Onay = true;
                if(s.SozlesmeTur==1)
                {
                    var sayfa = db.SayfaDurums.FirstOrDefault(a => a.KullaniciId == kullaniciId && a.SayfaId == 7);
                    sayfa.Durum = true;
                }
                
                db.SaveChanges();

                var sonuc = MailGonder(s.Kullanici.Degers.Where(a => a.InputId == 5).Select(a => a.Icerik).FirstOrDefault(), "Westline", "Wat Onaylandı.Lütfen forma devam ediniz.");
                smsapi sms = new smsapi("5399706684", "03011995e", "ILETI MRKZI");
                var sonuc2 = sms.SendSMS(new string[] { s.Kullanici.Degers.Where(a => a.InputId == 6).Select(a => a.Icerik).FirstOrDefault() }, "Wat Onaylandı.Lüfen forma devam ediniz.");
                
                var jsonResult = new
                {
                    basari = 1
                };
                return Json(jsonResult, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var jsonResult = new
                {
                    basari = 0
                };
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Taksitlendir(float ucret, int taksitSayi, int kullaniciId)
        {

            int dateAyar = 30;
            for (int i = 0; i < taksitSayi; i++)
            {
                Taksit t = new Taksit();
                t.Miktar = ucret / taksitSayi;
                t.SonOdeme = DateTime.Now.AddDays(dateAyar);
                dateAyar += 30;
                t.Odendi = false;
                db.Taksits.Add(t);

                db.SaveChanges();

                TaksitOdeme taksitOde = new TaksitOdeme();
                taksitOde.TaksitId = t.Id;
                taksitOde.KullaniciId = kullaniciId;
                db.TaksitOdemes.Add(taksitOde);
            }

            Kullanici k = db.Kullanicis.Find(kullaniciId);
            k.AdminOnay = true;


            SayfaDurum s = db.SayfaDurums.FirstOrDefault(x => x.KullaniciId == kullaniciId && x.SayfaId == 1);
            s.Durum = true;


            db.SaveChanges();
            var jsonResult = new
            {
                basari = 1
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public void TaksitBildirim(int kullaniciId)
        {

        }

        public JsonResult TaksitGetir(int Id)
        {
            List<Object> jsonModelList = new List<object>();
            foreach (var i in db.TaksitOdemes.Where(x => x.KullaniciId == Id).OrderByDescending(y => y.Id))
            {
                var a = i.Taksit.SonOdeme.Value;
                var jsonModel = new
                {
                    Miktar = i.Taksit.Miktar,
                    SonOdeme = a.Day + "." + a.Month + "." + a.Year,
                    Odendi = i.Taksit.Odendi == true ? 1 : 0
                };
                jsonModelList.Add(jsonModel);
            }

            return Json(jsonModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InputSil(int inputId)
        {
            Input i = db.Inputs.FirstOrDefault(x=>x.Id == inputId);
            db.Inputs.Remove(i);
            db.SaveChanges();
            var jsonModel = new {
                basari = 1
            };

            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InputEkle(string aciklama, string placeholder, int turId, int zorunlu, int sayfaId)
        {
            Input i = new Input();
            i.Aciklama = aciklama;
            i.Placeholder = placeholder;
            i.TurId = turId;
            i.Zorunlu = zorunlu == 0 ? false : true;
            i.SayfaId = sayfaId;
            db.Inputs.Add(i);
            db.SaveChanges();
            var jsonModel = new
            {
                basari = 1
            };
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
        public bool MailGonder(string gonderilecekMail, string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("okan.deneme@yandex.com.tr", "Okan Test");
            ePosta.To.Add(gonderilecekMail);
            ePosta.Subject = konu;
            ePosta.Body = icerik;
            try
            {
                smtp.Send(ePosta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}