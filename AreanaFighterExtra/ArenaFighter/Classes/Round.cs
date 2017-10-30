using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Classes {
    class Round {
        public int PlayerRoll { get; set; }
        public int OpponentRoll { get; set; }

        public Character Winner { get; set; }
        public Character Loser { get; set; }

        public int DamageDone { get; set; }

        public bool IsDraw { get; set; }
        public bool IsFinal { get; set; } //Används bara i test

        public Round()
        {
            PlayerRoll = 0;
            OpponentRoll = 0;
        }

        public override string ToString()
        {
            return IsDraw ? $"The round was a draw" : $"The winner was {Winner.Name} and did {DamageDone} damage;";
        }
    }
}
