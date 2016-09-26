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
        westlineDB db = new westlineDB();
        public JsonResult KisiEkle(string tc = "", string ad = "", string ortaAd="", string soyad = "", string email = "", string tel = "")
        {
            helper.helper h = new helper.helper();
            if(h.FormKontrol(tc, ad, soyad, email, tel))
            {
                Kisi k = new Kisi();
                k.TcKimlikNo = tc;
                k.Ad = ad;
                k.OrtaAd = ortaAd;
                k.Soyad = soyad;
                

                Iletisim i = new Iletisim();
                i.Email = email;
                i.Telefon = tel;

                db.Iletisims.Add(i);

                k.Iletisim = i;
                db.Kisis.Add(k);
                db.SaveChanges();

                var jsonModel = new
                {
                    success = 1,
                    id = k.Id,
                    ad = k.Ad,
                    ortaAd = k.OrtaAd,
                    soyad = k.Soyad,
                    mail = i.Email,
                    telefon = i.Telefon
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jsonModel = new
                {
                    success = 0
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
            }
        }
    }
}