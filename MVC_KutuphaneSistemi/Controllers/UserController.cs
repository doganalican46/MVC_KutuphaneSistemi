using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class UserController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Deneme()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.Uyeler.FirstOrDefault(z => z.Mail == uyemail);
            return View(degerler);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Deneme(Uyeler u)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Uyeler.FirstOrDefault(x=>x.Mail==kullanici);
            uye.Sifre = u.Sifre;
            uye.Ad = u.Ad;
            uye.Soyad = u.Soyad;
            uye.Fotograf = u.Fotograf;
            uye.KullaniciAdi = u.KullaniciAdi;
            uye.OkulAdi = u.OkulAdi;
            uye.Telefon = u.Telefon;

            db.SaveChanges();
            return View();
        }


    }
}