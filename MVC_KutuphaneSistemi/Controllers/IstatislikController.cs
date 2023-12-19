using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class IstatislikController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Istatislik
        public ActionResult Index()
        {
            var uyeler = db.Uyeler.Count();
            ViewBag.uyeSayisi=uyeler;


            var kitaplar = db.Kitaplar.Count();
            ViewBag.kitapSayisi = kitaplar;


            var oduncKitap = db.Kitaplar.Where(x=>x.Durum==false).Count();
            ViewBag.oduncKitapSayisi = oduncKitap;

            var CezaTutari = db.Cezalar.Sum(x => x.Para);
            ViewBag.CezaTutari = CezaTutari;

            
            return View();
        }

        
    }
}