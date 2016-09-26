using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace westline_alfa.Controllers
{
    public class BirinciController : Controller
    {
        public int KisiEkle(string tc = "", string ad = "", string ortaAd="", string soyad = "", string email = "", string tel = "")
        {
            helper.helper h = new helper.helper();
            if(h.FormKontrol(tc, ad, soyad, email, tel) == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}