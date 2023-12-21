using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
using MVC_KutuphaneSistemi.Models.Siniflar;

namespace MVC_KutuphaneSistemi.Controllers
{
    public class VitrinController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Vitrin

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Kitaplar.ToList();
            cs.Deger2 = db.Hakkimizda.ToList();
            //var degerler = db.Kitaplar.ToList();
            return View(cs);
        }

        
        [HttpPost]
        public ActionResult Index(Iletisim i)
        {
            db.Iletisim.Add(i);
            i.Tarih = DateTime.Now; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}