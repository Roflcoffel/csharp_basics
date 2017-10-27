using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicOOP {
    class Sale {
        public string productName;
        public double soldFor; //in dollar

        public Client client;
        public DateTime TransactionDate { get; set; }

        public Sale(string productName, double soldFor, Client client)
        {
            this.productName = productName;
            this.soldFor = soldFor;
            this.client = client;

            TransactionDate = DateTime.Now;
        }
    }
}
