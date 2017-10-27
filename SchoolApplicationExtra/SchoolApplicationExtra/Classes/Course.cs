using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class Course {
        public Guid CourseId { get; set; }
        public string Name { get; set; }

        public Teacher Teacher { get; set; }
        public List<Student> StudentList { get; }

        public Course(string Name, Teacher Teacher)
        {
            this.Name = Name;
            this.Teacher = Teacher;

            CourseId = Guid.NewGuid();
            StudentList = new List<Student>();
        }
    }
}
