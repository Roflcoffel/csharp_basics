using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class HomeController : Controller {
        MovieDBEntities db = new MovieDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult TopFive()
        {
            var mov = (from m in db.Movies select m).Take(5).ToList();

            ViewBag.Message = "Shows 5 movies";

            return View(mov);
        }

        public ActionResult BeforeDate()
        {
            var mov = (from m in db.Movies
                      where m.ReleaseYear.Year < 2010
                      select m).ToList();

            ViewBag.Message = "All movies released before 2010";

            return View(mov);
        }

        public ActionResult CustomerBought()
        {
            var customers = (from c in db.Customers
                             join o in db.Orders on c.Id equals o.CustomerId
                             join orows in db.OrderRows on o.Id equals orows.OrderId
                             join m in db.Movies on orows.MovieId equals m.Id
                             where m.Title == "Pulp Fiction"
                             select c).ToList();

            ViewBag.Message = "Customers that bought Pulp Fiction";

            return View(customers);
        }

        public ActionResult OrderByPrice()
        {
            var movies = (from m in db.Movies
                          orderby m.Price descending
                          select m).ToList();

            ViewBag.Message = "Movies sorted by price";

            return View(movies);
        }

        public ActionResult OrderDetail()
        {
            var query = db.Customers
                   .Join(db.Orders,
                   c => c.Id,
                   o => o.CustomerId,
                   (c, o) => new {Customer = c, Order = o});
            return View();
        }

        public ActionResult CustomerPlacedOrderOnDate()
        {
            return View();
        }

        public ActionResult MovieDetails(int? Id)
        {
            var movie = db.Movies.Find(Id);
            return View(movie);
        }

        public ActionResult AllCustomers()
        {
            return View();
        }

        public ActionResult NameStartsWith()
        {
            return View();
        }

        public ActionResult ByFirstLetter()
        {
            return View();
        }

        public ActionResult NamesAlphabetical()
        {
            return View();
        }
    }
}