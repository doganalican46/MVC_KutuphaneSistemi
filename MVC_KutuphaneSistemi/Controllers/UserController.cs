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
    }
}