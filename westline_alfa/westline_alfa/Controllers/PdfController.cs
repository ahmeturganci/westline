using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class PdfController : Controller
    {
        westlineDB db = new westlineDB();
        public ActionResult Index(int id)
        {
            return View(db.Kullanicis.Find(id));
        }
    }
}