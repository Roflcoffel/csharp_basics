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

        public string Examine()
        {
            return "";
        }

        public void Purchase(List<Money> pool, User user)
        {
            throw new NotImplementedException();
        }

        public string Use()
        {
            throw new NotImplementedException();
        }
    }
}
