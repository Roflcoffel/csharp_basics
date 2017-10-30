using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Classes {
    class Battle {
        public Character Player { get; set; }
        public Character Opponent { get; set; }
        public Round LastRound { get { return BattleLog[BattleLog.Count - 1]; } }

        public List<Round> BattleLog { get; set; }
        public bool IsFinished { get; set; } //Används bara i test

        public Battle()
        {

        }

        public Battle(Character Player, Character Opponent)
        {
            this.Player = Player;
            this.Opponent = Opponent;
            this.BattleLog = new List<Round>();
        }

        public void Fight()
        {
            while (!Player.IsDead && !Opponent.IsDead)
            {
                Console.WriteLine("Press any key to strike!");
                Console.ReadKey(true);
                FightRound();
            }

            if (Opponent.IsDead)
            {
                Console.WriteLine("You have slain your opponent!");
            }
            else
            {
                Console.WriteLine("You have died!");
            }

            Console.WriteLine("Press any key to proceed...");
            Console.ReadKey();
            Console.Clear();
        }

        public void FightRound(bool RollDice = true)
        {
            Round round = new Round();
            Random die = new Random();

            round.PlayerRoll = 0;
            round.OpponentRoll = 0;

            if (RollDice)
            {
                round.PlayerRoll = die.Next(1, 7);
                round.OpponentRoll = die.Next(1, 7);
            }

            int playerTotal = round.PlayerRoll + Player.Strength;
            int opponentTotal = round.OpponentRoll + Opponent.Strength;

            Console.WriteLine($"\nYou rolled: {round.PlayerRoll}\nOpponet Rolled: {round.OpponentRoll}\nYour total vs opponent total: {playerTotal} versus {opponentTotal}");

            if (playerTotal > opponentTotal) //Player wins
            {
                round.Winner = Player;
                round.Loser = Opponent;

                Console.WriteLine($"\n{Player.Name} strike {Opponent.Name}, you win the round");
            }
            else if(opponentTotal > playerTotal) //Opponent wins
            {
                round.Winner = Opponent;
                round.Loser = Player;

                Console.WriteLine($"\n{Opponent.Name} strike {Player.Name}, you lose the round");
            }
            else //Draw
            {
                round.IsDraw = true;

                Console.WriteLine("\nNone of you found an opportunity to strike, round is a draw");
            }

            if(!round.IsDraw)
            {
                round.Loser.Health -= round.Winner.Damage;
                round.DamageDone = round.Winner.Damage;
                if(round.Loser.IsDead)
                {
                    round.IsFinal = true;
                    IsFinished = true;
                }
            }

            BattleLog.Add(round);
        }
    }
}
