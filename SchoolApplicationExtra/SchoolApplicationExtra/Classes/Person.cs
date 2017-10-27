using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class Person {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person() { }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            Firstname = firstName;
            Lastname = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int GetAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;

            if (DateTime.Now.Day <= DateOfBirth.Day)
            {
                if (DateTime.Now.Month <= DateOfBirth.Month)
                {
                    age--;
                }
            }

            return age;
        }
    }
}
