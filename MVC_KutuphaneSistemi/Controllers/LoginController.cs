using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class LoginController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Login
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Uyeler u)
        {
            var bilgiler = db.Uyeler.FirstOrDefault(x => x.Mail == u.Mail && x.Sifre == u.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);

                //TempData["ID"] = bilgiler.ID.ToString();
                //TempData["Ad"]=bilgiler.Ad.ToString();
                //TempData["Soyad"] = bilgiler.Soyad.ToString();
                //TempData["KullaniciAd"] = bilgiler.KullaniciAdi.ToString();
                Session["Mail"] = bilgiler.Mail.ToString();
                //TempData["Sifre"] = bilgiler.Sifre.ToString();
                //TempData["Okul"] = bilgiler.OkulAdi.ToString();

                return RedirectToAction("Deneme","User");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Uyeler u)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.Uyeler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}