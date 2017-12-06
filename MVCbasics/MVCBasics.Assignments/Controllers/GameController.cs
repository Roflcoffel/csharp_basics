using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBasics.Assignments.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVCBasics.Assignments.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            Guesser gb = new Guesser();

            //new session when you reload
            HttpContext.Session["GameData"] = gb;

            //Load highscore
            ViewBag.HighScore = HttpContext.Session["HighScore"];

            return View(gb);
        }

        // POST: Game
        [HttpPost]
        public ActionResult Index(Guesser gb)
        {
            //gb = GameData
            string correctGuess = "";

            //Put the posted guess in a temp var.
            int newGuess = gb.Guess;
            
            //Load the previous session
            gb = (Guesser)HttpContext.Session["GameData"];
            gb.Guess = newGuess;

            ViewBag.GameMessage = gb.checkGuess();

            if(gb.isCorrect)
            {
                correctGuess = "Correct; new Roll";
                gb.isCorrect = false;
            }
            else
            {
                gb.Counter++;
            }

            ViewBag.HighScore = Load.HighScore(gb, HttpContext.Session);

            if(Load.newHighScore)
            {
                ViewBag.NewHigh = "New Highscore!!";
            }

            ViewBag.Counter = gb.Counter;
            ViewBag.Score = gb.Score;

            gb.Log.Add(gb.Guess.ToString() + " : " + correctGuess);
            
            return View(gb);
        }
    }
}