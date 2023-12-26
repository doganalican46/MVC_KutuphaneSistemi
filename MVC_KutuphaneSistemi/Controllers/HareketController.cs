using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KutuphaneSistemi.Models.Entity;
namespace MVC_KutuphaneSistemi.Controllers
{
    public class HareketController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: Hareket
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        
    }
}