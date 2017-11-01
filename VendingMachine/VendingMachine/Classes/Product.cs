using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Product : IPurchable{
        public Money Prize { get; set; }
        public string Label { get; set; }

        public Product() { }

        public Product(string Label, Money Prize)
        {
            this.Prize = Prize;
            this.Label = Label;
        }

        public override string ToString()
        {
            return $"Label: {Label} - {Prize}Kr";
        }

        public string Examine()
        {
            return ToString();
        }

        public void Purchase(List<Money> pool, User user)
        {
            pool.Remove(Prize);
            user.Stuff.Add(this);
        }

        public virtual string Use()
        {
            return $"You eat/drink the {Label}";
        }
    }
}
