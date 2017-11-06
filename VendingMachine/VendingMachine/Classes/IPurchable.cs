using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    interface IPurchable {
        string Purchase(List<Money> l, User u);
        string Examine();
        string Use();
    }
}
