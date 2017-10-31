using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Drink : Product, IPurchable {

        public Drink() {}

        public Drink(string Label, Money Prize)
        {
            this.Label = Label;
            this.Prize = Prize;
        }

        public string Examine()
        {
            throw new NotImplementedException();
        }

        public void Purchase(List<Money> pool, User user)
        {
            //Pool pengar minskar med värdet på item.
            //User får producten.
            //user får ut change när dem inte vill köpa mer.
        }

        public string Use()
        {
            throw new NotImplementedException();
        }
    }
}
