using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models {
    public class Store {

        public List<Genre> Catalog { get; set; }

        public Store()
        {
            this.Catalog = new List<Genre>();
        }
    }
}