using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kayit()
        {
            return View();
        }

        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();
        public JsonResult GirisYap(string kullaniciAdi, string sifre)
        {
            string s = h.MD5Sifrele(sifre);
            if (db.Kullanicis.Any(x => (x.KullaniciAdi == kullaniciAdi || x.Degers.FirstOrDefault(y=>y.InputId==5).Icerik == kullaniciAdi) && x.Sifre == s))
            {
                Kullanici a = db.Kullanicis.FirstOrDefault(x => (x.KullaniciAdi == kullaniciAdi || x.Degers.FirstOrDefault(y => y.InputId == 5).Icerik == kullaniciAdi) && x.Sifre ==s);

                GirisLog g = new GirisLog();
                g.Tarih = DateTime.Now;
                db.GirisLogs.Add(g);

                KullaniciGiri kg = new KullaniciGiri();
                kg.GirisLog = g;
                kg.Kullanici = a;
                db.KullaniciGiris.Add(kg);

                db.SaveChanges();

                Session["id"] = a.Id;
                var jsonModel = new
                {
                    basari = 1,
                    id = a.Id
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
            }
            else
            {
                var jsonModel = new
                {
                    basari = 0
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
            }
        }

        public JsonResult SessionGetir()
        {
            if (Session["id"] != null)
            {
                var jsonModel = new
                {
                    basari = 1,
                    id = Session["id"]
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
            }
            else
            {
                var jsonModel = new
                {
                    basari = 0,
                    id = 0
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
            }
        }

        public JsonResult KayitOl(string kullaniciAdi, string sifre, string mail, string tel)
        {
            if(db.Kullanicis.Any(x=>x.KullaniciAdi == kullaniciAdi) == false)
            {
                Kullanici k = new Kullanici();
                k.KullaniciAdi = kullaniciAdi;
                k.Sifre = h.MD5Sifrele(sifre);
                k.AktivasyonOnay = false;
                k.AdminOnay = false;

                db.Kullanicis.Add(k);

                db.SaveChanges();

                GirisLog g = new GirisLog();
                g.Tarih = DateTime.Now;
                db.GirisLogs.Add(g);

                KullaniciGiri kg = new KullaniciGiri();
                kg.GirisLog = g;
                kg.Kullanici = k;
                db.KullaniciGiris.Add(kg);

                Deger d = new Deger();
                d.Icerik = mail;
                d.InputId = 5;
                d.KisiId = k.Id;
                db.Degers.Add(d);


                Deger d2 = new Deger();
                d2.Icerik = tel;
                d2.InputId = 6;
                d2.KisiId = k.Id;
                db.Degers.Add(d2);


                foreach (var i in db.Sayfas)
                {
                    if (i.Id == 10)
                    {
                        SayfaDurum s = new SayfaDurum();
                        s.KullaniciId = k.Id;
                        s.SayfaId = i.Id;
                        s.Durum = true;
                        db.SayfaDurums.Add(s);

                    }
                    else
                    {
                        SayfaDurum s = new SayfaDurum();
                        s.KullaniciId = k.Id;
                        s.SayfaId = i.Id;
                        s.Durum = false;
                        db.SayfaDurums.Add(s);


                    }
                }

                db.SaveChanges();

                Session["id"] = k.Id;
                helper.smsapi sms = new helper.smsapi("5303728029","ilme00","WestLine");
                if (sms.SendSMS(new string[] { tel }, h.AktivasyonEkle(k.Id)))
                {
                    var jsonModel = new
                    {
                        basari = 1,
                        id = k.Id
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
            else
            {
                var jsonModel = new
                {
                    basari = 0
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
            }
           
        }
    }
}