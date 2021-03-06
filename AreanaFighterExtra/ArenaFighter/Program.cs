﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaFighter.Classes;

//Optional
//TODO: shop half working.
//TODO: apply bonus and penalty in a better way.
namespace ArenaFighter {
    class Program {

        static List<Battle> BattleLog = new List<Battle>();

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;

            bool run = true;
            Random rnd = new Random();

            Shop shop = new Shop(rnd);

            Console.WriteLine("Choose a name for your fighter: ");

            Character player = new Character(
                Console.ReadLine(), 
                rnd.Next(1, 15), 
                rnd.Next(1, 15)
            );


            List<Character> opponents = 
                player.GenerateCharacters(
                    20, //Number of opponents
                    new List<string>() {"Rolf","Adam","Andreas","Ulrik","Olaf","Ragnar","Andrea","Mikael","Lars","Sigurd"}
                );

            while(run)
            {
                Console.WriteLine($"Your fighter:\n{player}\n");
                player.DisplayInventory();
                Console.WriteLine("\n\nChoose an action: ");
                Console.WriteLine("C - Challange a new enemy");
                Console.WriteLine("X - Retire your fighter");
                Console.WriteLine("L - Battle Log");
                Console.WriteLine("S - Shop");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.S:
                        shop.BuyItem(player);
                        break;
                    case ConsoleKey.L:
                        ShowLog();
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        Character opponent = opponents[rnd.Next(0, opponents.Count)];
                        Console.WriteLine($"--Player stats--{player}\n");
                        player.DisplayInventory();
                        Console.WriteLine($"\n--Opponent--{opponent}");
                        Console.WriteLine("\nChoose an action: ");
                        Console.WriteLine("F - Fight");
                        Console.WriteLine("X - Run Away!");
                   
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.F:
                            Arena arena = new Arena(rnd);
                            Console.WriteLine($"\n\nThe selected arena is: {arena.field}");

                            arena.Bonus(player.Inventory);
                            arena.Penalties(player.Inventory);
                            
                            Battle newBattle = new Battle(player, opponent);
                            BattleLog.Add(newBattle);
                            newBattle.Fight();
                            break;
                        default:
                            break;
                    }
                    if (player.IsDead)
                    {
                        run = false;
                        Console.WriteLine("You are dead!");
                        Console.ReadKey();
                    }
                    if (opponent.IsDead)
                    {
                        player.Money += 5 + (opponent.Strength/2);
                        opponents.Remove(opponent);
                    }
                    if (opponents.Count == 0)
                    {
                        Console.WriteLine("You have slain all the challengers");
                        run = false;
                        Console.ReadKey(true);
                    }
                    break;
                case ConsoleKey.X:
                    run = false;
                    break;
                default:
                    break;
                }

                Console.Clear();
            }

            Console.WriteLine("Your fighter have retired!");

            player.Score = (BattleLog.Count-1)*10;
            
            if(!player.IsDead)
            {
                player.Score += 10;
            }

            Console.WriteLine($"Your score was {player.Score}\n");
            ShowLog();

            Console.ReadKey(true);

        }

        public static void ShowLog()
        {
            foreach (var battle in BattleLog)
            {
                Console.WriteLine($"\nBattle {BattleLog.IndexOf(battle)}\n");

                foreach (var round in battle.BattleLog)
                {
                    Console.WriteLine(round);
                }
            }
        }
    }
}
