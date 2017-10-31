using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Product {
        public Money Prize { get; set; }
        public string Label { get; set; }

        public Product() { }

        public Product(string Label, Money Prize)
        {
            this.Prize = Prize;
            this.Label = Label;
        }
    }
}
