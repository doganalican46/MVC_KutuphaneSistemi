using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;

namespace MVC_KutuphaneSistemi.Controllers
{
    public class CezaController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        [Authorize]
        // GET: Ceza
        public ActionResult Index()
        {
            var degerler = db.Cezalar.ToList();
            return View(degerler);
        }
    }
}