using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;

namespace MVC_KutuphaneSistemi.Controllers
{

    public class KitapController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();

        // GET: Kitap
        public ActionResult Index()
        {
            var kitaplar = db.Kitaplar.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult YeniKitap()
        {
            List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.kategoriler = kategoriler;

            List<SelectListItem> yazarlar = (from i in db.Yazarlar.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad+" "+i.Soyad,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.yazarlar = yazarlar;

            return View();
        }
 

        [HttpPost]
        public ActionResult YeniKitap(Kitaplar y)
        {

            var kategori = db.Kategoriler.Where(k => k.ID == y.Kategoriler.ID).FirstOrDefault();
            var yazar = db.Yazarlar.Where(k => k.ID == y.Yazarlar.ID).FirstOrDefault();
            y.Kategoriler = kategori;
            y.Yazarlar = yazar;

            db.Kitaplar.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var Kitap = db.Kitaplar.Find(id);
            Kitap.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var Kitap = db.Kitaplar.Find(id);
            List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.kategoriler = kategoriler;

            List<SelectListItem> yazarlar = (from i in db.Yazarlar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad + " " + i.Soyad,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.yazarlar = yazarlar;
            return View("KitapGetir", Kitap);
        }

        public ActionResult KitapGuncelle(Kitaplar y)
        {
            var Kitap = db.Kitaplar.Find(y.ID);
            Kitap.Ad = y.Ad;
            Kitap.BasimYili = y.BasimYili;
            Kitap.YayinEvi = y.YayinEvi;
            Kitap.SayfaSayisi = y.SayfaSayisi;
            Kitap.Fotograf = y.Fotograf;
            Kitap.Durum = y.Durum;
            var kategori = db.Kategoriler.Where(k => k.ID == y.Kategoriler.ID).FirstOrDefault();
            var yazar = db.Kategoriler.Where(k => k.ID == y.Yazarlar.ID).FirstOrDefault();

            Kitap.KategoriID = kategori.ID;
            Kitap.YazarID = yazar.ID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}