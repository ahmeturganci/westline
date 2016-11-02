using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;
using System.Web.Script.Serialization;


namespace westline_alfa.Controllers
{
    public class BirinciController : Controller
    {
        helper.helper h = new helper.helper();
        westlineDB db = new westlineDB();
        public JsonResult KisiEkle()
        {
            var jsonResult = (object)null;
            int kisiId = Convert.ToInt32(Session["id"]);
            if (h.VeriEkle(Request.QueryString, kisiId))
            {
                int kulId = Convert.ToInt32(Session["id"]);
                SayfaDurum s = db.SayfaDurums.FirstOrDefault(x => x.KullaniciId ==  kisiId && x.SayfaId == 11);
                s.Durum = true;
                db.SaveChanges();
                jsonResult = new
                {
                    basari = 1
                };
            }
            else
            {
                jsonResult = new
                {
                    basari = 0
                };
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Kontrol(string kod)
        {
            int id = Convert.ToInt32(Session["id"]);
            if (db.Aktivasyons.Any(x => x.KullaniciId == id && x.Kod == kod))
            {
                Kullanici k = db.Kullanicis.Find(id);
                k.AktivasyonOnay = true;

                db.SaveChanges();
                var jsonModel = new
                {
                    basari = 1
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

        public JsonResult elemans(int sayfa, int kisiId)
        {
            return h.ElemanCek(sayfa, kisiId);
        }

        public JsonResult SayfaDurum(int id)
        {
            if (Session["id"] != null)
            {
                return h.SayfaDurum(id, Convert.ToInt32(Session["id"]));
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

        public JsonResult RenkDurumCek()
        {
            if (Session["id"] != null)
            {
                return h.RenkDurum(Convert.ToInt32(Session["id"]));
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
    }
}