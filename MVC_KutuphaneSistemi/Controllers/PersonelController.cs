using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class PersonelController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var personeller = db.Personeller.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniPersonel(Personeller k)
        {
            db.Personeller.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var Personel = db.Personeller.Find(id);
            Personel.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var Personel = db.Personeller.Find(id);
            return View("PersonelGetir", Personel);
        }

        public ActionResult PersonelGuncelle(Personeller k)
        {
            var Personel = db.Personeller.Find(k.ID);
            Personel.Ad = k.Ad;
            Personel.Soyad = k.Soyad;
            Personel.Durum = k.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public class PersonelDetayViewModel
        {
            public Personeller Personel { get; set; }
            public List<Hareketler> Hareketler { get; set; }
        }

        public ActionResult PersonelDetay(int id)
        {
            var personel = db.Personeller.Find(id);
            var hareketler = db.Hareketler.Where(h => h.PersonelID == personel.ID).ToList();

            ViewBag.personeladsoyad = personel.Ad + " " + personel.Soyad;
            //ViewBag.personelfotograf = personel.Fotograf;
            return View("PersonelDetay", hareketler);
        }


    }
}