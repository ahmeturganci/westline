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

        public JsonResult evrakPasaportEkle()
        {
            var jsonResult = (object)null;
            if (h.VeriEkle(Request.QueryString))
            {
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
                        Sozlesme d;
                        int kulId = Convert.ToInt32(Session["id"]);
                        if (dc.Sozlesmes.Any(x => x.KullaniciId == kulId && x.SozlesmeTur==e))
                        {
                            d = dc.Sozlesmes.FirstOrDefault(x => x.KullaniciId == kulId && x.SozlesmeTur == e);
                            d.Url = fileName;
                        }
                        else
                        {
                            d = new Sozlesme();
                            d.KullaniciId = kulId;
                            d.Url = fileName;
                            d.SozlesmeTur = e;
                            d.Onay = false;
                            dc.Sozlesmes.Add(d);
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