using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class BesinciController : Controller
    {
        // GET: Besinci

        westlineDB db = new westlineDB();
        helper.helper h = new helper.helper();

        public JsonResult BesinciSayfaBildi(string dogumYeri = "", string dogumUlke = "", string vatandasUlke = "", int vatandasNo, int ikiVatandasNo,string AbdSsn="",bool amerikadaBulunduMu, string amerikadaBulunmaTarih="", int amerikaBulunduguSure, bool oncedenAmerikaVizesi,bool oncedenAmerikaVizeRet,string oncedenAmerikaVizeRetNedeni="",bool amerikaVatandasGocmenBasvuru,string babaDogumTarihi="",bool babaAmerikadaMi,bool askerlikYapti,bool sonBesYil,string anneDogumTarihi="", bool anneAmerikadaMi)
        {

            if (h.FormKontrol(dogumYeri,dogumUlke,vatandasUlke,vatandasNo,ikiVatandasNo,AbdSsn,anneAmerikadaMi,amerikadaBulunduMu))
            {
                Kisi k = db.Kisis.Find(Session["id"]);
                //Burayo nasıl yapacam bilmiyom tam :) 
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

        }
}