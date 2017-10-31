using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Machine {
        public List<Money> Pool { get; set; }
        public List<Product> Stock { get; set; }
        public List<Product> Cart { get; set; }

        public Machine()
        {
            Pool = new List<Money>();
            Stock = new List<Product>();
            generateStock();
        }

        //kanske ändras till Product som return typ.
        public void Buy(IPurchable item, User user)
        {
            item.Purchase(Pool, user);
        }

        public void AddMoney(Money coin)
        {
            Pool.Add(coin);
        }

        public override string ToString()
        {
            return "" + Pool.Sum(m => m.ConvertToInt());
        }

        private void generateStock()
        {
            Stock.Add(new Food("Curry Macka", new Money(Money.Values.HUNDRED) ));
            Stock.Add(new Food("Nuddlar", new Money(Money.Values.TWENTY) ));
            Stock.Add(new Food("Matlåda", new Money(Money.Values.FIFTY) ));
            Stock.Add(new Snack("Kexchoklad", new Money(Money.Values.FIVE) ));
            Stock.Add(new Snack("Mars", new Money(Money.Values.FIVE) ));
            Stock.Add(new Snack("Chokladboll", new Money(Money.Values.FIVE) ));
            Stock.Add(new Drink("Cola", new Money(Money.Values.TWENTY) ));
            Stock.Add(new Drink("Sprite", new Money(Money.Values.TWENTY) ));
            Stock.Add(new Drink("Loka", new Money(Money.Values.TWENTY) ));
        }
    }
}
