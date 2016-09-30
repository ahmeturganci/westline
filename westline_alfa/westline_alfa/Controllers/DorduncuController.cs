using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace westline_alfa.Controllers
{
    public class DorduncuController : Controller
    {
        public JsonResult Upload(int uID)
        {
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    var fileName = Path.GetFileName(file.FileName);
                    string strMappath = Server.MapPath("~/App_Data/" + uID + "/");
                    if (!Directory.Exists(strMappath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(strMappath);
                    }
                    var path = Path.Combine(strMappath, "1.zip");
                    file.SaveAs(path);
                }
                return Json("ftp://user:sifre@site.com/1.zip");
            }
            catch (Exception ex)
            {
                return Json("-" + ex.Message);
            }
        }

    }
}