using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicOOP {
    class Employee : Person {
        public int Salary { get; set; }
        public List<Sale> sales = new List<Sale>();

        public Employee(string firstName, string lastName, int age, int salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;

            this.Salary = salary;
        }

        public override string ToString()
        {
            return "This is the Employee class!";
        }

        public void AddSale(Sale sales)
        {
            this.sales.Add(sales);
        }

        public int GetNumberOfSales()
        {
            return sales.Count;
        }

        public double GetSalesTotal()
        {
            return sales.Sum(sale => sale.soldFor);
        }

        public double GetAverageSale()
        {
            return sales.Average(sale => sale.soldFor);
        }

        public void GetSaleStatistics()
        {
            Console.WriteLine($"\n\nFollowing is statistics for {firstName} {lastName}!");
            Console.WriteLine("Number of sales: " + GetNumberOfSales());
            Console.WriteLine("Sales total: $" + GetSalesTotal());
            Console.WriteLine("Average sale: $" + GetAverageSale());
        }
    }
}
