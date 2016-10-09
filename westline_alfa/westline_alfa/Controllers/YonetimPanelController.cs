using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class YonetimPanelController : Controller
    {
        westlineDB db = new westlineDB();
        // GET: YonetimPanel
        public ActionResult Index()
        {
            return View(db.Kisis);
        }

        public ActionResult OnayVer(string id)
        {
            Kisi k = db.Kisis.Find(Convert.ToInt32(id));
            k.AdminOnay = true;
            db.SaveChanges();
            return RedirectToAction("Index", "YonetimPanel");
        }

    }
}