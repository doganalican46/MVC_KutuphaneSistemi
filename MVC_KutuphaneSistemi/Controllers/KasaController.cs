﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KutuphaneSistemi.Controllers
{
    public class KasaController : Controller
    {
        // GET: Kasa
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}