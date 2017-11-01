using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Snack : Product, IPurchable {

        public Snack() { }

        public Snack(string Label, Money Prize)
        {
            this.Label = Label;
            this.Prize = Prize;
        }
    }
}
