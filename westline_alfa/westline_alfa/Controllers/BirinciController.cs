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
        public JsonResult KisiEkle()
        {
            helper.helper h = new helper.helper();
            int sayac = 0;
            string icerik = "", id = "";
            if (h.FormKontrol(Request.QueryString))
            {
                for (int i = 0; i < Request.QueryString.Count; i++)
                {
                    if (sayac == 0) icerik = Request.QueryString[i];
                    else if (sayac == 1) id = Request.QueryString[i];
                    else
                    {
                        Deger d;
                        int inputId = Convert.ToInt32(id);
                        if (db.Degers.Any(x=>x.KisiId ==1 && x.InputId == inputId))
                        {
                            d = db.Degers.FirstOrDefault(x=> x.KisiId == 1 && x.InputId == inputId);
                            d.Icerik = icerik;
                        }
                        else
                        {
                            d = new Deger();
                            d.InputId = Convert.ToInt32(id);
                            d.Icerik = icerik;
                            d.KisiId = 1;
                            db.Degers.Add(d);
                        }
                        sayac = 0;
                        continue;
                    }
                    sayac++;
                }

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
            
            /*helper.smsapi sms = new helper.smsapi("5399706684","03011995e","ILETI MRKZI");
            if (sms.SendSMS(new string[] { "5350560103" }, "DENEME MESAJI"))
            {
                // Mesaj Gönderildi
            }
            else
            {
                // Mesaj Gönderilemedi
            }*/


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
                bool kontrol = false;
                string icerik = "";
                if(db.Degers.Any(x=>x.InputId == i.Id && x.KisiId == 1))
                {
                    kontrol = true;
                    icerik = db.Degers.FirstOrDefault(x => x.InputId == i.Id && x.KisiId == 1).Icerik;
                }

                if(i.Tur.Id != 4)
                {
                    jsonModel = new
                    {
                        Id = i.Id,
                        Aciklama = i.Aciklama,
                        Placeholder = i.Placeholder,
                        iTur = i.Tur.Ad,
                        Zorunlu = i.Zorunlu == true ? "*" : "",
                        Name = i.Zorunlu == true ? "1" : "0",
                        Max = i.Maxlength != null ? i.Maxlength : 1000,
                        Icerik = kontrol == true ? icerik : ""
                    };
                }
                else
                {
                    List<Object> secenekler = new List<object>();
                    int icerikId = 0;
                    if (kontrol) icerikId = Convert.ToInt32(db.Degers.FirstOrDefault(x => x.KisiId == 1 && x.InputId == i.Id).Icerik);
                    foreach (var j in db.Seceneks.Where(x=>x.InputId==i.Id))
                    {
                        var jsonSecenekModel = new
                        {
                            Id = j.Id,
                            secenek = j.Icerik,
                            Secili = kontrol == true ? icerikId == 0 ? 0 : j.Id == icerikId ? 1 : 0 : 0
                        };
                        secenekler.Add(jsonSecenekModel);
                    }

                    jsonModel = new
                    {
                        Id = i.Id,
                        Aciklama = i.Aciklama,
                        iTur = i.Tur.Ad,
                        Zorunlu = i.Zorunlu == true ? "*" : "",
                        Name = i.Zorunlu == true ? "1" : "0",
                        Secenek = secenekler
                    };
                }
                
                jsonModelList.Add(jsonModel);
            }
            return Json(jsonModelList, JsonRequestBehavior.AllowGet);
        }
    }
}