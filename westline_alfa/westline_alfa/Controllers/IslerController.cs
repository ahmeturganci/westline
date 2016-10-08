using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace westline_alfa.Controllers
{
    public class IslerController : Controller
    {
        helper.helper h = new helper.helper();
        public JsonResult IsleriGetir()
        {
            return h.IsGetir();
        }
    }
}