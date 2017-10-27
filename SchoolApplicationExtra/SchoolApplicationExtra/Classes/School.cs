using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class School {
        public string Name { get; set; }

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Grade> Grades { get; set; }

        public Dictionary<Guid, Course> Courses { get; set; }

        public bool HasCourse(Guid courseId)
        {
            Course course;
            return Courses.TryGetValue(courseId, out course);
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course.CourseId, course);
        }

        public void RemoveCourse(Guid courseId)
        {
            Courses.Remove(courseId);
        }

        public bool IsSchoolEnrolled(Guid studentId)
        {
            return Students.Contains(Students.Find(x => x.StudentId == studentId));
        }

        public bool IsCourseEnrolled(Guid courseId, Guid studentId)
        {
            //Lookup the correct course.
            Course course;
            Courses.TryGetValue(courseId, out course);

            //in the course studentList find a student with id x. (returns student)
            //check if studentList conatins this student. (returns bool)
            return course.StudentList.Contains(course.StudentList.Find(x => x.StudentId == studentId));
        }

        public void EnrollCourse(Guid courseId, Guid studentId)
        {
            if(IsSchoolEnrolled(studentId))
            {
                if(HasCourse(courseId))
                {
                    if(IsCourseEnrolled(courseId, studentId))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        Course course;
                        Courses.TryGetValue(courseId, out course);

                        course.StudentList.Add(Students.Find(x => x.StudentId == studentId));)
                    }
                }
            }
        }

        public void EnrollSchool(Student student)
        {

        }

        public void WithdrawFromSchool(Guid studentId)
        {

        }

        public void WithdrawFromCourse(Guid courseId, Guid studentId)
        {

        }

        public void SetGrade(Grade grade, Guid courseId, Guid studentId)
        {

        }

        public void RemoveGrade(Guid courseId, Guid studentId)
        {

        }

        public void GetGrades(Guid studentId)
        {

        }
    }
}
