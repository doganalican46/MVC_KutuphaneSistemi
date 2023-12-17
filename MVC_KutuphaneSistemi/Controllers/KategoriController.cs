using System;
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
        public ActionResult Index()
        {
            var degerler = db.Kategoriler.ToList();
            return View(degerler);
        }
    }
}