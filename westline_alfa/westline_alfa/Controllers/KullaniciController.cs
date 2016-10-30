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
        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();
        public JsonResult GirisYap(string kullaniciAdi, string sifre)
        {
            string s = h.MD5Sifrele(sifre);
            if (db.Kullanicis.Any(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == s))
            {
                Kullanici a = db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre ==s);

                GirisLog g = new GirisLog();
                g.Tarih = DateTime.Now;
                db.GirisLogs.Add(g);

                KullaniciGiri kg = new KullaniciGiri();
                kg.GirisLog = g;
                kg.Kullanici = a;
                db.KullaniciGiris.Add(kg);

                db.SaveChanges();

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
    }
}