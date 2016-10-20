﻿using System;
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
        public JsonResult KisiEkle(string tc = "", string ad = "", string ortaAd = "", string soyad = "", string email = "", string tel = "", int kendiIs = -1)
        {
            helper.helper h = new helper.helper();
            if (h.FormKontrol(tc, ad, soyad, email, tel, kendiIs) || Session["id"] != null)
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

                h.AktivasyonEkle(k.Id);

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
                return Json(jsonModel, JsonRequestBehavior.AllowGet); 
            }
        }

        public JsonResult Kontrol(string kod)
        {
            int id = Convert.ToInt32(Session["id"]);
            if (db.Aktivasyons.Any(x => x.KisiId == id && x.Kod == kod))
            {
                var jsonModel = new
                {
                    basari = 1
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet); ;
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

        public JsonResult ElemanCek(int sayfa)
        {
            List<Object> jsonModelList = new List<object>();
            var jsonModel = (object)null;
            foreach (var i in db.Inputs.Where(x => x.Sayfa == sayfa))
            {
                if(i.Tur.Id != 4)
                {
                    jsonModel = new
                    {
                        Aciklama = i.Aciklama,
                        Placeholder = i.Placeholder,
                        iTur = i.Tur.Ad,
                        Zorunlu = i.Zorunlu == true ? "*" : "",
                        Name = i.Zorunlu == true ? "zorunlu" : "",
                        Max = i.Maxlength != null ? i.Maxlength : 1000
                    };
                }
                else
                {
                    List<Object> secenekler = new List<object>();
                    foreach (var j in db.Seceneks.Where(x=>x.InputId==i.Id))
                    {
                        var jsonSecenekModel = new
                        {
                            Id = j.Id,
                            secenek = j.Icerik
                        };
                        secenekler.Add(jsonSecenekModel);
                    }

                    jsonModel = new
                    {
                        Aciklama = i.Aciklama,
                        iTur = i.Tur.Ad,
                        Zorunlu = i.Zorunlu == true ? "*" : "",
                        Name = i.Zorunlu == true ? "zorunlu" : "",
                        Secenek = secenekler
                    };
                }
                
                jsonModelList.Add(jsonModel);
            }
            return Json(jsonModelList, JsonRequestBehavior.AllowGet);
        }
    }
}