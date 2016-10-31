using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using westline_alfa.Models;

namespace westline_alfa.helper
{
    public class helper : Controller
    {
        westlineDB db = new westlineDB();

        public bool VeriEkle(NameValueCollection query)
        {
            int sayac = 0;
            string icerik = "", id = "";
            if (FormKontrol(query))
            {
                for (int i = 0; i < query.Count; i++)
                {
                    if (sayac == 0) icerik = query[i];
                    else if (sayac == 1) id = query[i];
                    else
                    {
                        Deger d;
                        int inputId = Convert.ToInt32(id);
                        if (db.Degers.Any(x => x.KisiId == 1 && x.InputId == inputId))
                        {
                            d = db.Degers.FirstOrDefault(x => x.KisiId == 1 && x.InputId == inputId);
                            d.Icerik = icerik;
                        }
                        else
                        {
                            d = new Deger();
                            d.InputId = Convert.ToInt32(id);
                            d.Icerik = icerik;
                            d.KisiId = 1;
                            db.Degers.Add(d);
                        }
                        sayac = 0;
                        continue;
                    }
                    sayac++;
                }

                db.SaveChanges();

                return true;
            }
            else return false;
        }

        int sayac = 0;
        public JsonResult ElemanCek(int sayfa, int kisiId)
        {
            sayac = 0;
            List<Object> jsonModelList = new List<object>();
            var jsonModel = (object)null;
            foreach (var i in db.Inputs.Where(x => x.SayfaId == sayfa))
            {
                bool kontrol = false;
                string icerik = "";
                if (db.Degers.Any(x => x.InputId == i.Id && x.KisiId == kisiId))
                {
                    kontrol = true;
                    icerik = db.Degers.FirstOrDefault(x => x.InputId == i.Id && x.KisiId == kisiId).Icerik;
                }

                if (i.Tur.Id != 4 && i.Tur.Id != 8)
                {
                    jsonModel = new
                    {
                        Id = i.Id,
                        Aciklama = i.Aciklama,
                        Placeholder = i.Placeholder,
                        iTur = i.Tur.Ad,
                        Zorunlu = i.Zorunlu == true ? "*" : "",
                        Name = i.Zorunlu == true ? "1" : "0",
                        Max = i.Maxlength != null ? i.Maxlength : 1000,
                        Icerik = kontrol == true ? icerik : ""
                    };
                }
                else
                {
                    List<Object> secenekler = new List<object>();
                    int icerikId = 0;
                    if (kontrol) icerikId = Convert.ToInt32(db.Degers.FirstOrDefault(x => x.KisiId == kisiId && x.InputId == i.Id).Icerik);
                    foreach (var j in db.Seceneks.Where(x => x.InputId == i.Id))
                    {
                        var jsonSecenekModel = new
                        {
                            Id = j.Id,
                            secenek = j.Icerik,
                            name = "rd" + sayac,
                            Secili = kontrol == true ? icerikId == 0 ? 0 : j.Id == icerikId ? 1 : 0 : 0
                        };
                        secenekler.Add(jsonSecenekModel);
                    }

                    sayac++;

                    jsonModel = new
                    {
                        Id = i.Id,
                        Aciklama = i.Aciklama,
                        iTur = i.Tur.Ad,
                        Zorunlu = i.Zorunlu == true ? "*" : "",
                        Name = i.Zorunlu == true ? "1" : "0",
                        Secenek = secenekler
                    };
                }

                jsonModelList.Add(jsonModel);
            }
            return Json(jsonModelList, JsonRequestBehavior.AllowGet);
        }



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

        public JsonResult Iller(int id)
        {
            List<Object> jsonModelList = new List<object>();
            foreach (var i in db.Ils.Where(x => x.UlkeId == id))
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

        public bool FormKontrol(NameValueCollection elemanlar)
        {
            bool kontrol = true;
            int sayac = 0;
            string icerik = "";
            for (int i = 0; i < elemanlar.Count; i++)
            {
                if (sayac == 0) icerik = elemanlar[i];
                else if (sayac == 2)
                {
                    if (elemanlar[i] == "1" && icerik == "")
                    {
                        kontrol = false;
                        break;
                    }
                    sayac = 0;
                    continue;
                }
                sayac++;
            }

            return kontrol;
        }

        public string AktivasyonEkle(int id)
        {
            Random rnd = new Random();
            string kod = rnd.Next(10000, 99999).ToString();
            Kullanici k = db.Kullanicis.Find(id);

            Aktivasyon a = new Aktivasyon();
            a.Kullanici = k;
            a.Kod = kod;
            a.Tarih = DateTime.Now;
            k.AktivasyonOnay = false;
            k.AdminOnay = false;

            k.Aktivasyons.Add(a);

            db.SaveChanges();
            return kod;
        }

        public JsonResult IsGetir()
        {
            if (db.Degers.FirstOrDefault(x => x.KisiId == 1 && x.InputId == 8).Icerik == "1")
            {
                var jsonModel = new
                {
                    IsBuldu = 1,
                    Aciklama = "İş buldu"
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Object> jsonModelList = new List<object>();
                foreach (var i in db.Islers)
                {
                    var jsonModel = new
                    {
                        IsBuldu = 0,
                        Id = i.Id,
                        isAdi = i.Ad,
                        isAciklama = i.Aciklama
                    };
                    jsonModelList.Add(jsonModel);
                }
                return Json(jsonModelList, JsonRequestBehavior.AllowGet);
            }
        }

        public string MD5Sifrele(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }

        public JsonResult SonGirisCek(int kisiId)
        {
            List<Object> jsonModelList = new List<object>();
            foreach (var i in db.KullaniciGiris.Where(x => x.KullaniciId == kisiId).OrderByDescending(y => y.Id))
            {
                var a = i.GirisLog.Tarih.Value;
                var jsonModel = new
                {
                    Giris = a.Date.Day + "." + a.Date.Month + "." + a.Date.Year + " " + a.Hour + ":" + a.Minute
                };
                jsonModelList.Add(jsonModel);
            }

            return Json(jsonModelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SayfaDurum(int sayfaId, int kullaniciId)
        {//bam   kanka tasarım bittyse salla
            //ben buralaro değiştirim byük ihtimal o zaman atam kayan yeri söyle düzeltim okey ? 
            if (db.SayfaDurums.FirstOrDefault(x => x.KullaniciId == kullaniciId && x.SayfaId == sayfaId).Durum == true)
            {
                var jsonModel = new
                {
                    basari = 1,
                    son = 0
                };
                return Json(jsonModel,JsonRequestBehavior.AllowGet);
            }
            else
            {
                int son = db.SayfaDurums.OrderByDescending(x => x.Id).FirstOrDefault(y => y.KullaniciId == kullaniciId && y.Durum == true).Id;

                var jsonModel = new
                {
                    basari = 0,
                    son = son
                };
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RenkDurum(int id)
        {
            int[] dizi = new int[10];
            int i = 0;
            foreach (var s in db.SayfaDurums.Where(x => x.KullaniciId == id))
            {
                dizi[i] = s.Durum == true ? 2 : 1;
                i++;
            }
            var jsonModal = new
            {
                birincisayfa = dizi[0],
                cv = dizi[1],
                dorduncusayfa = dizi[2],
                ucakbilgi = dizi[3],
                ucuncusayfa = dizi[4],
                randevual = dizi[5],
                ikincisayfa = dizi[6],
                besincisayfa = dizi[7],
                aktivasyon = dizi[8],
                tahsilat = dizi[9]
            };
            return Json(jsonModal, JsonRequestBehavior.AllowGet);
        }
    }
}
