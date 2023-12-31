﻿using System;
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
        [Authorize]
        // GET: Kitap
        public ActionResult Index()
        {
            var kitaplar = db.Kitaplar.ToList();
            return View(kitaplar);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniKitap()
        {
            List<SelectListItem> kategoriler = (from i in db.Kategoriler.Where(k => k.Durum == true).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.kategoriler = kategoriler;

            List<SelectListItem> yazarlar = (from i in db.Yazarlar.Where(y => y.Durum == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad + " " + i.Soyad,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.yazarlar = yazarlar;


            return View();
        }

        [Authorize]
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




        [Authorize]
        public ActionResult KitapSil(int id)
        {
            var Kitap = db.Kitaplar.Find(id);
            Kitap.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        [Authorize]
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
        [Authorize]
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

        [Authorize]
        public ActionResult KitapDetay(int id)
        {
            var kitap = db.Kitaplar.Find(id);
            var hareketler = db.Hareketler.Where(h => h.KitapID == kitap.ID).ToList();

            ViewBag.kitapad = kitap.Ad;
            ViewBag.kitapfotograf = kitap.Fotograf;
            ViewBag.sayfasayisi = kitap.SayfaSayisi;
            ViewBag.yayinevi = kitap.YayinEvi;
            ViewBag.KitapID = kitap.ID;
            var okunmaSayisi = db.Hareketler.Count(h => h.KitapID == kitap.ID);
            ViewBag.okunmaSayisi = okunmaSayisi;


            return View("KitapDetay", hareketler);
        }
    }
}