using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;

namespace MVC_KutuphaneSistemi.Controllers
{

    public class YazarController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();

        // GET: Yazar
        public ActionResult Index()
        {
            var degerler = db.Yazarlar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniYazar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYazar(Yazarlar y)
        {
            db.Yazarlar.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.Yazarlar.Find(id);
            yazar.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.Yazarlar.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(Yazarlar y)
        {
            var yazar = db.Yazarlar.Find(y.ID);
            yazar.Ad = y.Ad;
            yazar.Soyad = y.Soyad;
            yazar.Detay = y.Detay;
            yazar.Durum = y.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarDetay(int id)
        {
            var yazar = db.Yazarlar.Find(id);
            var kitaplari = db.Kitaplar.Where(h => h.YazarID == yazar.ID).ToList();

            ViewBag.yazarad = yazar.Ad;
            ViewBag.yazarsoyad = yazar.Soyad;
            ViewBag.YazarID = yazar.ID;



            return View("YazarDetay", kitaplari);
        }
    }
}