using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class CvController : Controller
    {
        helper.helper h = new helper.helper();
        westlineDB db = new westlineDB();
        public JsonResult CvEkle()
        {
            var jsonResult = (object)null;
            int kisiId = Convert.ToInt32(Session["id"]);
            if (h.VeriEkle(Request.QueryString, kisiId))
            {
                int kulId = Convert.ToInt32(Session["id"]);
                SayfaDurum s = db.SayfaDurums.FirstOrDefault(x => x.KullaniciId == kisiId && x.SayfaId == 3);
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

        public JsonResult elemans(int sayfa, int kisiId)
        {
            return h.ElemanCek(sayfa, kisiId);
        }
    }

}
