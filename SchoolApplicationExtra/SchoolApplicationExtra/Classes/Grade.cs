using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class Grade {
        public Guid GradeId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

        public DateTime DateAcquired { get; set; }

        public Grades myGrade { get; set; }
        public enum Grades { A, B, C, D, E, F };
        

        public override string ToString()
        {
            string temp = "";

            switch (myGrade)
            {
                case Grades.A:
                    temp = "Grade: A - Amazinlgy Done!";
                    break;
                case Grades.B:
                    temp = "Grade: B - Well Done!";
                    break;
                case Grades.C:
                    temp = "Grade: C - Good Job!";
                    break;
                case Grades.D:
                    temp = "Grade: D - Good Job!";
                    break;
                case Grades.E:
                    temp = "Grade: E - You Passed!";
                    break;
                case Grades.F:
                    temp = "Grade: F - You Failed!";
                    break;
                default:
                    break;
            }

            return temp;
        }

    }
}
