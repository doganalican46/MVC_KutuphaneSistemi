using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class IletisimController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Iletisim
        [Authorize]
        public ActionResult Index()
        {
            var iletisim = db.Iletisim.ToList();
            return View(iletisim);
        }
    }
}