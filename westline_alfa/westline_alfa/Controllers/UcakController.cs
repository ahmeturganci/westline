using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class UcakController : Controller
    {
        helper.helper h = new helper.helper();
        westlineDB db = new westlineDB();
        public JsonResult Ekle(string agidisTarih = "", string bgidisTarih = "", string agidisSehir = "", string bgidisSehir = "", string ahavaKod = "", string bhavaKod = "", string avarisSehir = "", string bvarisSehir = "", string avarisKod = "", string bvarisKod = "", string aucusKod = "", string bucusKod = "", string akalkisSaat = "", string bkalkisSaat = "", string avarisSaat = "", string bvarisSaat = "", int agunDegisim = -1, int bgunDegisim = -1)
        {
            if (h.FormKontrol(agidisTarih, bgidisTarih, agidisSehir, bgidisSehir, ahavaKod, bhavaKod, avarisSehir, bvarisSehir, avarisKod, bvarisKod, aucusKod, bucusKod, akalkisSaat, bkalkisSaat, avarisSaat, bvarisSaat, agunDegisim, bgunDegisim))
            {
                Kisi k = db.Kisis.Find(Session["id"]);

                //TimeSpan Kalkistime = TimeSpan.Parse(akalkisSaat);
                //TimeSpan Varistime = TimeSpan.Parse(akalkisSaat);
                Ucu gidis = new Ucu()
                {
                    GidisTarih = Convert.ToDateTime(agidisTarih),
                    GidisSehir = agidisSehir,
                    GidisHavaalaniKod = ahavaKod,
                    VarisSehir = avarisSehir,
                    VarisHavaalaniKod = avarisKod,
                    UcusKod = aucusKod,
                    //KalkisSaat = Kalkistime,
                    //VarisSaat = Varistime,
                    GunDegisim = agunDegisim == 0 ? false : true
                };

                db.Ucus.Add(gidis);

                KisiUcu GidisUcus = new KisiUcu()
                {
                    Kisi = k,
                    Ucu = gidis,
                    isDonus = false
                };

                db.KisiUcus.Add(GidisUcus);

                //TimeSpan DKalkistime = TimeSpan.Parse(bkalkisSaat);
                //TimeSpan DVaristime = TimeSpan.Parse(bkalkisSaat);
                Ucu donus = new Ucu()
                {
                    GidisTarih = Convert.ToDateTime(agidisTarih),
                    GidisSehir = bgidisSehir,
                    GidisHavaalaniKod = bhavaKod,
                    VarisSehir = bvarisSehir,
                    VarisHavaalaniKod = bvarisKod,
                    UcusKod = bucusKod,
                    //KalkisSaat = DKalkistime,
                    //VarisSaat = DVaristime,
                    GunDegisim = bgunDegisim == 0 ? false : true
                };

                db.Ucus.Add(donus);

                KisiUcu DonusUcus = new KisiUcu()
                {
                    Kisi = k,
                    Ucu = donus,
                    isDonus = false
                };

                db.KisiUcus.Add(DonusUcus);

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
        }
    }
}