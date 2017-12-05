using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Assignments.Models {
    public class GameData {

        [Required(ErrorMessage = " A number is required")]
        public int Guess { get; set; }

        public int RndNumber { get; set; }
        public List<string> Log { get; set; }

        public bool isCorrect { get; set; }

        private Random rnd = new Random();

        public GameData()
        {
            RndNumber = rnd.Next(1, 10);
            Log = new List<string>();
            isCorrect = false;
        }

        public string checkGuess()
        {
            if (Guess < RndNumber)
            {
                return "The random number is larger";
            }

            if (Guess == RndNumber)
            {
                RndNumber = rnd.Next(1, 10);
                isCorrect = true;
                return "Congratulation! that's correct";
            }

            isCorrect = false;
            return "the random number is smaller";
        }
    }
}