using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class IkinciController : Controller
    {
        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();
        
        public JsonResult ekBilgiEkle()
        {
            var jsonResult = (object)null;
            if (h.VeriEkle(Request.QueryString))
            {
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

        public JsonResult UlkeCek()
        {
            return h.Ulkeler();
        }

        public JsonResult EyaletCek(int id)
        {
            return h.Iller(id);
        }

        
    }
}