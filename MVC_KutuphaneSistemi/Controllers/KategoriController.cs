﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class KategoriController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Kategori
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.Kategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult YeniKategori(Kategoriler k)
        {
            db.Kategoriler.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("KategoriGetir",kategori);
        }
        [Authorize]
        public ActionResult KategoriGuncelle(Kategoriler k)
        {
            var kategori = db.Kategoriler.Find(k.ID);
            kategori.Ad = k.Ad;
            kategori.Durum = k.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}