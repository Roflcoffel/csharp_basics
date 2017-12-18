using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models {
    public class RandomListVM {
        public List<int> RndList {get; set;}
        public int Value { get; set; }

        public RandomListVM()
        {
            RndList = new List<int>();
        }
    }
}