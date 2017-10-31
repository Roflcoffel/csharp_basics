using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Classes {
    class Arena {
        public enum Field { Plain, Hot, Cold, Wet}
        Array values = Enum.GetValues(typeof(Field));

        public Field field { get; set; }

        int BonusValue;
        int PenaltyValue;

        public Arena(Random rnd)
        {
            field = (Field)values.GetValue(rnd.Next(values.Length));
        }

        public void Bonus(List<Gear> gears)
        {
            List<Gear> curatedGears = new List<Gear>();

            switch (field)
            {
                case Field.Plain: //Plate, Steel
                    BonusValue = 2;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Steel ||
                        gear.type == Gear.Type.Plate
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Bonus +{BonusValue} armor for plate and steel");
                        curatedGears.ForEach(gear => gear.ArmorValue += BonusValue);
                    }

                    break;
                case Field.Hot: //Cloth
                    BonusValue = 1;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Cloth
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Bonus +{BonusValue} armor for cloth");
                        curatedGears.ForEach(gear => gear.ArmorValue += BonusValue);
                    }
                    break;
                case Field.Cold: //Cloth Leather
                    BonusValue = 2;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Cloth ||
                        gear.type == Gear.Type.Leather
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Bonus +{BonusValue} armor for cloth and leather");
                        curatedGears.ForEach(gear => gear.ArmorValue += BonusValue);
                    }
                    break;
                case Field.Wet: //Leather, Steel, Plate
                    BonusValue = 1;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Leather ||
                        gear.type == Gear.Type.Steel ||
                        gear.type == Gear.Type.Plate
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Bonus +{BonusValue} armor for leather, steel and plate");
                        curatedGears.ForEach(gear => gear.ArmorValue += BonusValue);
                    }
                    break;
                default:
                    break;
            }

            if (curatedGears.Count == 0)
            {
                Console.WriteLine($"No bonus applied");
            }

            gears.RemoveAll(itema => curatedGears.Exists(itemb => itemb == itema));
            gears.AddRange(curatedGears);
        }

        public void Penalties(List<Gear> gears)
        {
            List<Gear> curatedGears = new List<Gear>();

            switch (field)
            {
                case Field.Plain: //Cloth, Leather
                    PenaltyValue = 1;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Cloth ||
                        gear.type == Gear.Type.Leather
                    ).ToList();
                    
                    if(curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Penalty -{PenaltyValue} armor for cloth and leather");
                        curatedGears.ForEach(gear => gear.ArmorValue -= PenaltyValue);
                    }
                    break;
                case Field.Hot: //Plate, Steel
                    PenaltyValue = 3;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Steel ||
                        gear.type == Gear.Type.Plate
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Penalty -{PenaltyValue} armor for steel and plate");
                        curatedGears.ForEach(gear => gear.ArmorValue -= PenaltyValue);
                    }
                    break;
                case Field.Cold: //Plate, Steel
                    PenaltyValue = 2;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Steel ||
                        gear.type == Gear.Type.Plate
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Penalty -{PenaltyValue} armor for steel and plate");
                        curatedGears.ForEach(gear => gear.ArmorValue -= PenaltyValue);
                    }
                    break;
                case Field.Wet: //Cloth
                    PenaltyValue = 2;
                    curatedGears = gears.Where(
                        gear => gear.type == Gear.Type.Cloth
                    ).ToList();

                    if (curatedGears.Count != 0)
                    {
                        Console.WriteLine($"Penalty -{PenaltyValue} armor for cloth");
                        curatedGears.ForEach(gear => gear.ArmorValue -= PenaltyValue);
                    }
                    break;
                default:
                    break;
            }

            if (curatedGears.Count == 0)
            {
                Console.WriteLine($"No penalty applied");
            }
        }
    }
}
