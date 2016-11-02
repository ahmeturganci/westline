using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class WatController : Controller
    {
        helper.helper h = new helper.helper();
        public JsonResult BilgiCek()
        {
            return h.ElemanCek(13, Convert.ToInt32(Session["id"]));
        }
    }
}