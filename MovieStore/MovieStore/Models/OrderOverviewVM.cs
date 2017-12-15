using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models {
    public class OrderOverviewVM {
        public string Fullname { get; set; }

        public int MovieCount { get; set; }
        public int OrderCount { get; set; }

        public int OrderSum { get; set; }

        public OrderOverviewVM()
        {

        }
    }
}