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
        public JsonResult CvEkle(string cvHedef = "", string cvCalismaIstek = "", int cvYabanciDil = -1, int cvAskerlik = -1, int cvMedeni = -1, int cvPcBilgi = -1, string cvHobiler = "", string cvRefTel = "", string cvRefAdSoyad = "")
        {
            helper.helper h = new helper.helper();
            if (h.FormKontrol(cvYabanciDil, cvRefAdSoyad, cvRefTel) || Session["id"] != null)
            {

                Kisi k = new Kisi();
                Cv cv = new Cv();

                cv.Askerlik = cvAskerlik == 1 ? true : false;//bunlar hep bilgi

                cv.Hedef = cvHedef;
                cv.Hobiler = cvHobiler;
                cv.CalismakIstenilenIs = cvCalismaIstek;


                db.Cvs.Add(cv);

                Referan r = new Referan();
                r.Adi = cvRefAdSoyad;
                r.Tel = cvRefTel;
                db.Referans.Add(r);
                CvReferan cvRef = new CvReferan();

                cvRef.Cv = cv;
                cvRef.Referan = r;

                db.CvReferans.Add(cvRef);
                db.SaveChanges();

                var jsonModel = new
                {
                    basari = 1,
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
        public JsonResult cvCeken()
        {
            return h.CvCek();
        }
    }

}
