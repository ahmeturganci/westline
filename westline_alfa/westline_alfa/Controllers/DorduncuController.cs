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
        helper.helper h = new helper.helper();
        westlineDB db = new westlineDB();
        public JsonResult evrakPasaportEkle()
        {
            var jsonResult = (object)null;
            int kisiId = Convert.ToInt32(Session["id"]);
            if (h.VeriEkle(Request.QueryString, kisiId))
            {
                int kulId = Convert.ToInt32(Session["id"]);
                SayfaDurum s = db.SayfaDurums.FirstOrDefault(x => x.KullaniciId == kisiId && x.SayfaId == 1011);
                s.Durum = true;
                db.SaveChanges();
                jsonResult = new
                {
                    basari = 1
                };
            }
            else
            {
                jsonResult = new
                {
                    basari = 0
                };
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult elemans(int sayfa, int kisiId)
        {
            return h.ElemanCek(sayfa, kisiId);
        }

        public JsonResult SaveFiles(string description,int e)
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
                try
                {

                    file.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));


                    using (westlineDB dc = new westlineDB())
                    {
                        Deger d;
                        if (dc.Degers.Any(x => x.KisiId == 1 && x.InputId == e))
                        {
                            d = dc.Degers.FirstOrDefault(x => x.KisiId == 1 && x.InputId == e);
                            d.Icerik = fileName;
                        }
                        else
                        {
                            d = new Deger();
                            d.InputId = e;
                            d.Icerik = fileName;
                            d.KisiId = 1;
                            dc.Degers.Add(d);
                        }

                        dc.SaveChanges();
                        Message = fileName;
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Message = "0";
                }
            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }

        // yeni eklenen upload (evrakSayfa olay)

        [HttpPost]
        public void upload(System.Web.HttpPostedFileBase aFile)
        {
            string file = aFile.FileName;
            string path = Server.MapPath("../Upload//");
            aFile.SaveAs(path + Guid.NewGuid() + "." + file.Split('.')[1]);
        }
    }
}