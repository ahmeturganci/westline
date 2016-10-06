﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class PasaportController : Controller
    {
        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();
        public JsonResult PasaportEkle(string no = "", int ulke = -1, string ilce = "", string baslangicTarih = "", string bitisTarih = "", int calindiMi = -1, string ucretKarsilayan = "", string akrabalikIliski = "", string ucretKarsilayanTel = "")
        {
            if(h.FormKontrol(no,ulke,ilce,baslangicTarih,bitisTarih,calindiMi,ucretKarsilayan,akrabalikIliski) || Session["id"] != null)
            {
                Pasaport p = new Pasaport();
                p.No = no;
                p.AldigiUlke = ulke;
                p.AldigiSehir = ilce;
                //baslangic ve bitis
                p.PasaportKayipCalinti = calindiMi == 1 ? true : false;
                p.PasaportUcretKisi = ucretKarsilayan;
                p.PasaportUcretKisiAkraba = akrabalikIliski;
                p.PasaportUcretKisiAkrabaNo = ucretKarsilayanTel;
                db.Pasaports.Add(p);

                Kisi k = db.Kisis.Find(Session["id"]);
                k.ds160.Pasaport = p;
                var jsonModel = new
                {
                    basari = 1
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }
            else{
                var jsonModel = new
                {
                    basari = 0
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }
        }
    }
}