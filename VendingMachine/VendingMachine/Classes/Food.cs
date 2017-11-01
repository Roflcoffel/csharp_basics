using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Food : Product, IPurchable {

        public Food() { }

        public Food(string Label, Money Prize)
        {
            this.Label = Label;
            this.Prize = Prize;
        }

        public override string Use()
        {
            return $"You eat the {Label}";
        }
    }
}
