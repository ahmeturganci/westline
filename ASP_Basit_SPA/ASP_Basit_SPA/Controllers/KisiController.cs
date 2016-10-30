using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Basit_SPA.Controllers
{
    public class KisiController : Controller
    {
        Westline db = new Westline();
        // GET: Kisi
        public ActionResult Index()
        {
            return View();
        }

        public int Post(string ad, string email)
        {
            Kisi k = new Kisi();
            k.Ad = ad;

            Iletisim i = new Iletisim();
            i.Email = email;

            db.Iletisims.Add(i);

            k.IletisimId = i.Id;

            db.Kisis.Add(k);
            db.SaveChanges();

            return k.Id;
        }
    }
}