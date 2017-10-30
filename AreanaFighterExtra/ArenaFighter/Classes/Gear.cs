using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Classes {
    class Gear {
        public enum Type {Leather, Plate, Steel, Cloth }
        public enum Part {Helmet, Pauldron, Greaves, Gauntlets, Cuirass}

        Array typeValues = Enum.GetValues(typeof(Type));
        Array partValues = Enum.GetValues(typeof(Part));

        public Type type { get; private set; }
        public Part part { get; private set; }

        public int ArmorValue { get; set; }
        public int Prize { get { return ArmorValue / 2; } }

        //Random Gear
        public Gear(Random rnd)
        {
            type = (Type)typeValues.GetValue(rnd.Next(typeValues.Length));
            part = (Part)partValues.GetValue(rnd.Next(partValues.Length));

            ArmorValue = CalcArmorValue(type, part);
        }

        //Specific Gear
        public Gear(Type type, Part part)
        {
            this.type = type;
            this.part = part;

            ArmorValue = CalcArmorValue(type, part);
        }

        public int CalcArmorValue(Type type, Part part)
        {
            int armor = 0;

            switch (type)
            {
                case Type.Leather:
                    armor += 2;
                    break;
                case Type.Plate:
                    armor += 4;
                    break;
                case Type.Steel:
                    armor += 5;
                    break;
                case Type.Cloth:
                    armor += 1;
                    break;
                default:
                    break;
            }

            switch (part)
            {
                case Part.Helmet:
                    armor += 4;
                    break;
                case Part.Pauldron:
                    armor += 2;
                    break;
                case Part.Greaves:
                    armor += 1;
                    break;
                case Part.Gauntlets:
                    armor += 1;
                    break;
                case Part.Cuirass:
                    armor += 3;
                    break;
                default:
                    break;
            }

            return armor;
        }
    }
}
