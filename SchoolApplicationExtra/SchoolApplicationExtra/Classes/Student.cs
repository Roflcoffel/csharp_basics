using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class Student : Person{
        public Guid StudentId { get; set; }
        
        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            Firstname = firstName;
            Lastname = lastName;
            DateOfBirth = dateOfBirth;

            StudentId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Student Id: {StudentId.ToString()}\n" +
                $"Name: {Firstname} {Lastname}\n" +
                $"Date of birth: {DateOfBirth.ToShortDateString()}";
        }
    }
}
