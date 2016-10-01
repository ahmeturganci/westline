using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.Controllers
{
    public class DorduncuController : Controller
    {
        public JsonResult SaveFiles(string description)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                
                    file.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));


                    using (westlineDB dc = new westlineDB())
                    {
                        Belge f = new Belge();
                        f.FotografUrl = fileName;
                        dc.Belges.Add(f);

                        Kisi k = dc.Kisis.Find(Session["id"]);
                        k.Belge = f;

                        dc.SaveChanges();
                        Message = "File uploaded successfully";
                        flag = true;
                    }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }
    }
}