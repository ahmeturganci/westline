using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class BirinciController : Controller
    {
        westlineDB db = new westlineDB();
        public int KisiEkle(string tc = "", string ad = "", string ortaAd="", string soyad = "", string email = "", string tel = "")
        {
            helper.helper h = new helper.helper();
            if(h.FormKontrol(tc, ad, soyad, email, tel))
            {
                Kisi k = new Kisi();
                k.TcKimlikNo = tc;
                k.Ad = ad;
                k.OrtaAd = ortaAd;
                k.Soyad = soyad;
                

                Iletisim i = new Iletisim();
                
            }
            else
            {
                return 0;
            }
        }
    }
}