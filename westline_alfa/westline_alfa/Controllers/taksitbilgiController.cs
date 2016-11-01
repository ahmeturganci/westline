using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class taksitbilgiController : Controller
    {
        westlineDB db = new westlineDB();
        helper.Yardimci y = new helper.Yardimci();
        public JsonResult TaksitCek(int Id)
        {
            return y.TaksitGetir(Id);
        }

        public JsonResult taksitOnay()
        {
            int id = Convert.ToInt32(Session["id"]);
            SayfaDurum s = db.SayfaDurums.FirstOrDefault(x => x.KullaniciId == id && x.SayfaId == 1010);
            s.Durum = true;
            db.SaveChanges();
            var jsonModel = new
            {
                basari = 1
            };
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
    }
}