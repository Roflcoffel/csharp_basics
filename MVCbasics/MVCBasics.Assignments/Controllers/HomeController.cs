using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCbasics.Assignments.Controllers
{
    public class HomeController : Controller
    {
        // Home / Index
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Layout and view assignment";
            ViewBag.List = new List<string>() {"Testing","razor","in","a", "list"};


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
            ViewBag.Message = "Here are my contact information";

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