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
        //public JsonResult CvEkle()
        //{
        //    helper.helper h = new helper.helper();

        //    return Json(jsonModel, JsonRequestBehavior.AllowGet);

        //}

        public JsonResult elemans(int sayfa, int kisiId)
        {
            return h.ElemanCek(sayfa, kisiId);
        }
    }

}
