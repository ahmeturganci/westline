using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult Index()
        {
            return View();
        }

        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();
        public JsonResult GirisYap(string kullaniciAdi, string sifre)
        {
            string s = h.MD5Sifrele(sifre);
            if (db.Admins.Any(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == s))
            {
                Admin a = db.Admins.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == s);
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