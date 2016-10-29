using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.helper
{
    public class Yardimci : Controller
    {
        westlineDB db = new westlineDB();

        public JsonResult SozlesmeEkle(int sozlesmeId, int kullaniciId)
        {
            Sozlesme s = new Sozlesme();
            s.SozlesmeTur = sozlesmeId;
            s.KullaniciId = kullaniciId;
            s.Onay = false;
            db.Sozlesmes.Add(s);
            db.SaveChanges();
            var jsonResult = new
            {
                basari = 1
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SozlesmeOnay(int sozlesmeId, int kullaniciId)
        {
            
            if(db.Sozlesmes.Any(x=>x.SozlesmeTur == sozlesmeId && x.KullaniciId == kullaniciId))
            {
                Sozlesme s = db.Sozlesmes.FirstOrDefault(x => x.SozlesmeTur == sozlesmeId && x.KullaniciId == kullaniciId);
                s.Onay = true;
                db.SaveChanges();
                var jsonResult = new
                {
                    basari = 1
                };
                return Json(jsonResult, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var jsonResult = new
                {
                    basari = 0
                };
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Taksitlendir(float ucret, int taksitSayi, int kullaniciId)
        {
            Odeme o = new Odeme();
            o.KullaniciId = kullaniciId;
            db.Odemes.Add(o);

            int dateAyar = 30;
            for (int i = 0; i < taksitSayi; i++)
            {
                Taksit t = new Taksit();
                t.Miktar = ucret / taksitSayi;
                t.SonOdeme = DateTime.Now.AddDays(dateAyar);
                dateAyar += 30;
                t.Odendi = false;
                db.Taksits.Add(t);


                TaksitOdeme taksitOde = new TaksitOdeme();
                taksitOde.OdemeId = o.Id;
                taksitOde.TaksitId = t.Id;
                db.TaksitOdemes.Add(taksitOde);
            }

            db.SaveChanges();
            var jsonResult = new
            {
                basari = 1
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public void TaksitBildirim(int kullaniciId)
        {
            
        }



    }
}