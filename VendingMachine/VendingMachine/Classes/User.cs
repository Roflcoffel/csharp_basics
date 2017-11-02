using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    //kommer nog inte att användas.
    class User {
        public Money PocketMoney { get; set; }
        public List<Product> Stuff { get; set; }

        public User()
        {
            Stuff = new List<Product>();
        }
    }
}
