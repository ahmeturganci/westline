using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class RandevuController : Controller
    {
        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();

        public JsonResult randevuEkle(string altBir, string altIki)
        {
            var jsonResult = (object)null;
            int kisiId = Convert.ToInt32(Session["id"]);

            Randevu r1 = new Randevu();
            r1.Tarih = altBir;
            db.Randevus.Add(r1);

            Randevu r2 = new Randevu();
            r2.Tarih = altBir;
            db.Randevus.Add(r2);

            db.SaveChanges();

            KullaniciRandevu kr1 = new KullaniciRandevu();
            kr1.KullaniciId = kisiId;
            kr1.RandevuId = r1.Id;
            kr1.Onay = false;
            db.KullaniciRandevus.Add(kr1);

            KullaniciRandevu kr2 = new KullaniciRandevu();
            kr2.KullaniciId = kisiId;
            kr2.RandevuId = r2.Id;
            kr2.Onay = false;
            db.KullaniciRandevus.Add(kr2);

            db.SaveChanges();

            jsonResult = new
            {
                basari = 1
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult elemans(int sayfa, int kisiId)
        {
            return h.ElemanCek(sayfa, kisiId);
        }
    }
}