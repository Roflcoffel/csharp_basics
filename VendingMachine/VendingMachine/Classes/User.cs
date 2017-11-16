using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class User {
        public List<Money> PocketMoney { get; set; }
        public List<Product> Stuff { get; set; }

        public User()
        {
            PocketMoney = new List<Money>();
            Stuff = new List<Product>();
        }

        public string UseProduct(int location)
        {
            if(Stuff[location] != null)
            {
                return Stuff[location].Use();
            }
            else
            {
                return "Found nothing";
            }
        }
    }
}
