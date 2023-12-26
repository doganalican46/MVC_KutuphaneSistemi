using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class AyarController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Ayar
        [Authorize]
        public ActionResult Index()
        {
            var hakkimizda = db.Hakkimizda.ToList();
            return View(hakkimizda);
        }

        [Authorize]
        public ActionResult HakkimizdaGetir(int id)
        {
            var hakkimizda = db.Hakkimizda.Find(id);
            return View("HakkimizdaGetir", hakkimizda);
        }
        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda k)
        {
            var hak = db.Hakkimizda.Find(k.ID);
            hak.Aciklama = k.Aciklama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}