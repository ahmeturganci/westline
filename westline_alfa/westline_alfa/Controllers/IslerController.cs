using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class IslerController : Controller
    {
        helper.helper h = new helper.helper();
        westlineDB db = new westlineDB();
        public JsonResult IsleriGetir()
        {
            return h.IsGetir();
        }

        public JsonResult IsEkle()
        {
            NameValueCollection query = Request.QueryString;
            for (int i = 0; i < query.Count; i++)
            {
                KullaniciI k = new KullaniciI();
                k.IsId = Convert.ToInt32(query[i]);
                k.KullaniciId = 1;
                db.KullaniciIs.Add(k);
            }

            db.SaveChanges();
            var jsonResult = new
            {
                basari = 1
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}