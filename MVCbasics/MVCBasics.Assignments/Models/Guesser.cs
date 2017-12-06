using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Assignments.Models {
    public class Guesser {

        [Required(ErrorMessage = "A number is required")]
        [Range(1,10, ErrorMessage = "Valid range is 1 to 10")]
        public int Guess { get; set; }

        public int RndNumber { get; set; }
        public List<string> Log { get; set; }

        //increments when the user guess incorrectly
        //reset when correct
        public int Counter { get; set; } = 0;

        //increments when the user guess correctly.
        public int Score { get; set; } = 0;

        public bool isCorrect { get; set; }

        private Random rnd = new Random();

        public Guesser()
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
                Counter = 0;
                Score++;
                return "Congratulation! that's correct";
            }

            isCorrect = false;
            return "the random number is smaller";
        }
    }
}