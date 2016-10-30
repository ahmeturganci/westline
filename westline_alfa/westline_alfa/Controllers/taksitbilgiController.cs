using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace westline_alfa.Controllers
{
    public class taksitbilgiController : Controller
    {
        helper.Yardimci y = new helper.Yardimci();
        public JsonResult TaksitCek(int Id)
        {
            return y.TaksitGetir(Id);
        }
    }
}