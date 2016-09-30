﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.helper
{
    public class helper : Controller
    {
        westlineDB db = new westlineDB();

        public JsonResult Ulkeler()
        {
            List<Object> jsonModelList = new List<object>();
            foreach (var i in db.Ulkes)
            {
                var jsonModel = new
                {
                    Id = i.Id,
                    Ad = i.Ad
                };
                jsonModelList.Add(jsonModel);
            }
            return Json(jsonModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Eyaletler()
        {
            return Json(db.Eyalets,JsonRequestBehavior.AllowGet);
        }

        public bool FormKontrol(params object[] elemanlar)
        {
            bool kontrol = true;
            foreach (object i in elemanlar)
            {
                if (i is string )
                {
                    if ((string)i == "undefined")
                    {
                        kontrol = false;
                        break;
                    }
                }
                else
                {
                    if((int)i == -1)
                    {
                        kontrol = false;
                        break;
                    }
                }
            }

            return kontrol;
        } 
    }
}