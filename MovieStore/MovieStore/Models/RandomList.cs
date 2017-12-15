using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models {
    public class RandomList {
        public List<int> List { get; set; }

        public RandomList(int min, int max, int count)
        {
            Random rnd = new Random();
            List = new List<int>();

            for (int i = 0; i < count; i++)
            {
                List.Add(rnd.Next(min, max));
            }
        }
    }
}