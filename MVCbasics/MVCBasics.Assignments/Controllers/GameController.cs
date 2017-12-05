using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBasics.Assignments.Models;

namespace MVCBasics.Assignments.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            GameData gb = new GameData();

            HttpContext.Session["GameData"] = gb;
            

            return View(gb);
        }

        // POST: Game
        [HttpPost]
        public ActionResult Index(GameData gb)
        {
            string correctGuess = "";
            int myGuess = gb.Guess;

            gb = (GameData)HttpContext.Session["GameData"];
            gb.Guess = myGuess;

            ViewBag.GameMessage = gb.checkGuess();

            if(gb.isCorrect)
            {
                correctGuess = "Correct; new Roll";
                gb.isCorrect = false;
            }
            
            gb.Log.Add(myGuess.ToString() + " : " + correctGuess);
            
            return View(gb);
        }
    }
}