using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Classes {
    class Shop {
        List<Gear> Gears { get; set; }

        public Shop(Random rnd)
        {
            generateRandomItems(rnd);
        }

        public void generateRandomItems(Random rnd)
        {
            for (int i = 0; i < 10; i++)
            {
                Gears.Add(new Gear(rnd));
            }
        }

        public void DisplayItems()
        {
            Gears.ForEach(
                item => Console.WriteLine(
                    $"{Gears.IndexOf(item)}" +
                    $"Name: {item.type} {item.part}" +
                    $"Armor: {item.ArmorValue}" +
                    $"Prize: {item.Prize}"
                )
            );
        }

        public void BuyItem(Character player)
        {
            Console.WriteLine("input index id of the item you want to buy\n");

            DisplayItems();

            int input = Convert.ToInt32(Console.ReadKey(true));

            foreach (var item in Gears)
            {
                if( input == Gears.IndexOf(item) )
                {
                    if(player.Money > item.Prize)
                    {
                        player.Money -= item.Prize;
                        player.Inventory.Add(item);
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds!");
                    }
                }
                else
                {
                    Console.WriteLine("item do not exists");
                }
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey(true);
        }
    }
}
