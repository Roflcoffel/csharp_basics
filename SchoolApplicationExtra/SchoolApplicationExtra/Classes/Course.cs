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
        public List<Student> StudentList { get; set; }
    }
}
