using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Classes {
    class Character {
        public List<Gear> Inventory { get; set; }

        private string name;
        public string Name { get { return name; } set { } }

        private int health;
        public int Health { get { return health + Inventory.Sum(x => x.ArmorValue); } set { health = value; } }

        public int Score { get; set; }
        //this value will be added with the roll to see if you win the round.
        //if you win the round you will damage the enemy with your damage value.
        public int Strength { get; set; }
        public int Money { get; set; }
        
        public int Damage { get { return (Strength / 3) + 1; } }
        public bool IsDead { get { return (health <= 0); }}

        public Character() { }

        public Character(string name, int Strength, int Health)
        {
            Inventory = new List<Gear>();
            this.name = name;
            this.health = Health;
            this.Strength = Strength;
        }

        public List<Character> GenerateCharacters(int count, List<string> names)
        {
            Random rnd = new Random();
            List<Character> charList = new List<Character>();
            for (int i = 0; i < count; i++)
            {
                charList.Add(
                    new Character(
                        names[rnd.Next(0,names.Count)], 
                        rnd.Next(1,10), 
                        rnd.Next(1,10)
                    )
                );
            }

            return charList;
        }

        public override string ToString()
        {
            return $"\nName: {Name}\n" +
                $"Strength: {Strength}\n" +
                $"Damage: {Damage}\n" +
                $"Health: {Health}({Inventory.Sum(x => x.ArmorValue)})\n" +
                $"Money: {Money}";
        }

        public void DisplayInventory()
        {
            Console.WriteLine("--Inventory--");
            if( Inventory.Count != 0)
            {
                Inventory.ForEach(
                    item => Console.WriteLine($"{item.type} {item.part}")
                );
            }
            else
            {
                Console.WriteLine("Empty");
            }
        }

    }
}
