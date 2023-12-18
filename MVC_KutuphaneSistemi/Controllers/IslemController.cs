using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class IslemController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Islem
        public ActionResult Index()
        {
            var degerler = db.Hareketler.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
    }
}