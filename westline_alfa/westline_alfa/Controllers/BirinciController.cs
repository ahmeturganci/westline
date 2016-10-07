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
        public JsonResult KisiEkle(string tc = "", string ad = "", string ortaAd="", string soyad = "", string email = "", string tel = "", int kendiIs = -1)
        {
            helper.helper h = new helper.helper();
            if(h.FormKontrol(tc, ad, soyad, email, tel, kendiIs) || Session["id"] != null)
            {
                Kisi k = new Kisi();
                k.TcKimlikNo = tc;
                k.Ad = ad;
                k.OrtaAd = ortaAd;
                k.Soyad = soyad;
                k.kendiIsBuldu = kendiIs == 0 ? false : true;

                Iletisim i = new Iletisim();
                i.Email = email;
                i.Telefon = tel;

                db.Iletisims.Add(i);

                k.Iletisim = i;
                db.Kisis.Add(k);
                db.SaveChanges();

                Session["id"] = k.Id;
                var jsonModel = new
                {
                    basari = 1,
                    id = k.Id,
                    ad = k.Ad,
                    ortaAd = k.OrtaAd,
                    soyad = k.Soyad,
                    mail = i.Email,
                    telefon = i.Telefon
                };
                /*helper.smsapi sms = new helper.smsapi("5399706684","03011995e","ILETI MRKZI");
                if (sms.SendSMS(new string[] { "5350560103" }, "DENEME MESAJI"))
                {
                    // Mesaj Gönderildi
                }
                else
                {
                    // Mesaj Gönderilemedi
                }*/
               
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
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