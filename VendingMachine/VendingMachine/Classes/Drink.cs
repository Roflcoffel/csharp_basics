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

        public override string Use()
        {
            return $"You drink the {Label}";
        }
    }
}
