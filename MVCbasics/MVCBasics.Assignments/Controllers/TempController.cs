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
            return View(new Temp());
        }

        [HttpPost]
        public ActionResult Index(Temp temp)
        {
            ViewBag.FeverMessage = Fever.Check(temp);

            return View(temp);
        }
    }
}