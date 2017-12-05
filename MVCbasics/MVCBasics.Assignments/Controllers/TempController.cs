using MVCBasics.Assignments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBasics.Assignments.Controllers
{
    public class TempController : Controller
    {
        // GET: Temp
        public ActionResult Index()
        {
            return View(new Fever());
        }

        [HttpPost]
        public ActionResult Index(Fever fev)
        {
            ViewBag.FeverMessage = fev.CheckTemp();

            return View(fev);
        }
    }
}