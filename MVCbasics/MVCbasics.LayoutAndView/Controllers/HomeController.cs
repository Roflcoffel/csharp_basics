using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCbasics.LayoutAndView.Controllers
{
    public class HomeController : Controller
    {
        // Home / Index
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the index view";

            return View();
        }

        // Home / About
        public ActionResult About()
        {
            ViewBag.Message = "Here is a short introduction page";

            return View();
        }

        // Home / Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Here are my contacts";

            return View();
        }

        // Home / Projects
        public ActionResult Projects()
        {
            ViewBag.Message = "Here are some projects";
            return View();
        }
    }
}