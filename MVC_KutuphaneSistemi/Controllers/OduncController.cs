using MVC_KutuphaneSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KutuphaneSistemi.Controllers
{
    public class OduncController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.Hareketler.Where(x=>x.Durum==false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Hareketler k)
        {
            db.Hareketler.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OduncAl(int id)
        {
            var OduncAl = db.Hareketler.Find(id);
            return View("OduncAl", OduncAl);
        }

        public ActionResult OduncGuncelle(Hareketler k)
        {
            var iade = db.Hareketler.Find(k.ID);
            iade.UyeninGetirdigiTarih = k.UyeninGetirdigiTarih;
            iade.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}