using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class Teacher : Person{
        public Guid TeacherId { get; set; }
       
        public Teacher(string firstName, string lastName, DateTime dateOfBirth)
        {
            Firstname = firstName;
            Lastname = lastName;
            DateOfBirth = dateOfBirth;

            TeacherId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Student Id: {TeacherId.ToString()}\n" +
                $"Name: {Firstname} {Lastname}\n" +
                $"Date of birth: {DateOfBirth.ToShortDateString()}";
        }
    }
}
