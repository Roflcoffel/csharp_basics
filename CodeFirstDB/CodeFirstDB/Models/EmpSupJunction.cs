using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDB.Models {
    public class EmpSupJunction {
        public int Id { get; set; }

        public int SupervisorId { get; set; }
        public int EmployeeId { get; set; }

        public int Since_Year { get; set; }
        public int Until_Year { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Supervisor Supervisor { get; set; }
    }
}