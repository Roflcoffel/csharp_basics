using SchoolApplicationExtra.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra {
    class Program {
        static void Main(string[] args)
        {
            Student student = new Student(
                "Andreas", 
                "Johansson", 
                Convert.ToDateTime("1993-10-15") 
            );

            Console.WriteLine(student.ToString());

            Console.ReadLine();
        }
    }
}
