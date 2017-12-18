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

        //Exercise 3
        string names = "Andreas,Peter,Johan,Mattias,Tobias,Lars,Sigurd,Rolf,Nalini,Mikael,Håkan,Tony";
        
        //Creates a list of 20 random numbers between 1 and 100
        RandomList Rnd = new RandomList(1, 100, 20);

        //VM of RandomList; A List with a single value
        RandomListVM VM = new RandomListVM();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        //Exercise 1
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
                             select c).Distinct().ToList();

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

        //Exercise 2
        public ActionResult OrderDetail()
        {
            ViewBag.Message = "All Order details";

  
            return View(db.Orders.ToList());
        }

        public ActionResult PlacedOrderOnDate()
        {
            var query = db.Orders
               .Where(o => o.OrderDate == new DateTime(2015, 1, 1));

            ViewBag.Message = "Customer who placed a order on 2015-01-01";

            return View(query);
        }

        public ActionResult MovieByDate()
        {
            var query = db.Movies
                .OrderBy(m => m.ReleaseYear)
                .ToList();

            ViewBag.Message = "Movies ordered by oldest to newest";

            return View(query);
        }

        public ActionResult AllCustomers()
        {
            ViewBag.Message = "List of all customers";
            return View(db.Customers.ToList());
        }

        //Exercise 3
        public ActionResult NameStartsWith()
        {
            var localquery = names
                .Split(',')
                .Where(n => n.Substring(0, 1) == "M")
                .Take(1)
                .ToList();

            ViewBag.Message = "the first firstname that starts with the letter 'M'";

            return View(localquery);
        }

        public ActionResult FirstLetter()
        {
            var list = names
                .Split(',')
                .Select(n => n.Substring(0, 1))
                .ToList();

            return View(list);
        }

        public ActionResult NamesAlphabetical()
        {
            var localquery = names
                .Split(',')
                .OrderBy(n => n)
                .ToList();

            ViewBag.Message = "Names in alphabetical order";

            return View(localquery);
        }

        public ActionResult Sum()
        {
            VM.RndList = Rnd.List;
            VM.Value = Rnd.List.Sum(n => n);
            return View(VM);
        }

        public ActionResult OddCount()
        {
            VM.RndList = Rnd.List;
            VM.Value = Rnd.List
                .Where(n => n % 2 != 0)
                .ToList()
                .Count();

            return View(VM);
        }
        public ActionResult LargestNumber()
        {
            VM.RndList = Rnd.List;
            VM.Value = Rnd.List.Max(n => n);

            return View(VM);
        }

        //Optional Exercise 1
        public ActionResult OrderOverview()
        {
            var query = (from c in db.Customers
                         join o in db.Orders on c.Id equals o.CustomerId
                         join orows in db.OrderRows on o.Id equals orows.OrderId
                         join m in db.Movies on orows.MovieId equals m.Id
                         group new { c, o.CustomerId, orows.OrderId, orows.MovieId, orows.Price } by new { c.Id, c.Firstname, c.Lastname } into grp
                         select new OrderOverviewVM
                         {
                             Id = grp.Key.Id,
                             Fullname = grp.Key.Firstname + " " + grp.Key.Lastname,
                             MovieCount = grp.Select(x => x.MovieId).Distinct().Count(),
                             OrderCount = grp.Select(x => x.OrderId).Distinct().Count(),
                             OrderSum = (int)grp.Select(x => x.Price).Sum()
                          }).ToList();

        
            return View(query);
        }

        //Optional Exercise 2
        public ActionResult OrdersAndCost()
        {
            var query = (from o in db.Orders
                         join orows in db.OrderRows on o.Id equals orows.OrderId
                         group new { o, orows.OrderId, orows.Price } by 1 into grp
                         select new OrdersTotalAndSumVM
                         {
                             TotalOrders = grp.Select(x => x.o).Distinct().Count(),
                             SumOrders = (int)grp.Select(x => x.Price).Sum()
                         }).ToList(); //SingleOrDefault();

            return View(query);
        }

        //Lecture
        public ActionResult MovieDetails(int? Id)
        {
            return View(db.Movies.Find(Id));
        }
    }
}