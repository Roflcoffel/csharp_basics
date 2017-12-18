using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models {
    public class OrdersTotalAndSumVM {
        public int Id { get; set; }

        public int TotalOrders { get; set; }
        public int SumOrders { get; set; }

        public OrdersTotalAndSumVM()
        {

        }
    }
}