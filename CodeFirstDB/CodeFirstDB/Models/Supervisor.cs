using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDB.Models {
    public class Supervisor {
        public int Id { get; set; }

        public virtual ICollection<EmpSupJunction> EmpSupJunctions { get; set; }
    }
}