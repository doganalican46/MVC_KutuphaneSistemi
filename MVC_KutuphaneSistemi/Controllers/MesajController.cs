using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class MesajController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Mesaj
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x=>x.Alici==uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        [Authorize]
        public ActionResult Gonderilen()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }


        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var uyemail = (string)Session["Mail"].ToString();
            m.Gonderen = uyemail.ToString();
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(m);
            db.SaveChanges();
            return RedirectToAction("Gonderilen","Mesaj");
        }

  
    }
}