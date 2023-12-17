using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;

namespace MVC_KutuphaneSistemi.Controllers
{

    public class KitapController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();

        // GET: Kitap
        public ActionResult Index()
        {
            return View();
        }
    }
}