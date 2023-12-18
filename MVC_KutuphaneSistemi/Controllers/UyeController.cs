using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;

namespace MVC_KutuphaneSistemi.Controllers
{
    public class UyeController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();

        // GET: Uyeler
        public ActionResult Index()
        {
            var Uyeler = db.Uyeler.ToList();
            return View(Uyeler);
        }

        [HttpGet]
        public ActionResult YeniUye()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniUye(Uyeler k)
        {
            db.Uyeler.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var Uye = db.Uyeler.Find(id);
            Uye.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var Uye = db.Uyeler.Find(id);
            return View("UyeGetir", Uye);
        }

        public ActionResult UyeGuncelle(Uyeler k)
        {
            var Uye = db.Uyeler.Find(k.ID);
            Uye.Ad = k.Ad;
            Uye.Soyad = k.Soyad;
            Uye.Mail = k.Mail;
            Uye.Telefon= k.Telefon;
            Uye.OkulAdi = k.OkulAdi;
            Uye.KullaniciAdi = k.KullaniciAdi;
            Uye.Fotograf= k.Fotograf;
            Uye.Durum = k.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}