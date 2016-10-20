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
        public JsonResult Ekle(string altBir = "", string altIki = "")
        {
          
                Randevu r = new Randevu();
                r.AlternatifBir = Convert.ToDateTime(altBir);
                r.AlternatifIki = Convert.ToDateTime(altIki);
                r.Onay = false;
                r.Kisi = db.Kisis.Find(Session["id"]);

                var jsonModel = new
                {
                    basari = 1
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);

        }
    }
}