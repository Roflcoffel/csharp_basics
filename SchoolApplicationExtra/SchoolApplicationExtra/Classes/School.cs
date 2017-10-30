using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplicationExtra.Classes {
    class School {
        public string Name { get; set; }

        public List<Student> Students { get; }
        public List<Teacher> Teachers { get; }
        public List<Grade> Grades { get; }

        public Dictionary<Guid, Course> Courses { get; }

        public School(string Name)
        {
            this.Name = Name;

            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Grades = new List<Grade>();
            Courses = new Dictionary<Guid, Course>();
        }

        public bool HasCourse(Guid courseId)
        {
            return Courses.TryGetValue(courseId, out Course course);
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
            Courses.TryGetValue(courseId, out Course course);

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
                        Courses.TryGetValue(courseId, out Course course);

                        course.StudentList.Add(
                            Students.Find(x => x.StudentId == studentId)
                        );
                    }
                }
            }
        }

        public void EnrollSchool(Student student)
        {
            if(IsSchoolEnrolled(student.StudentId))
            {
                throw new Exception();
            }
            else
            {
                Students.Add(student);
            }
        }

        public void WithdrawStudentFromSchool(Guid studentId)
        {
            if(!IsSchoolEnrolled(studentId)) {
                throw new Exception();
            }
            else
            {
                Students.Remove(
                    Students.Find(x => x.StudentId == studentId)
                );
            }
        }

        public void WithdrawTeacherFromSchool(Guid teacherId)
        {
            if (!IsSchoolEnrolled(teacherId))
            {
                throw new Exception();
            }
            else
            {
                Teachers.Remove(
                    Teachers.Find(x => x.TeacherId == teacherId)
                );
            }
        }

        public void WithdrawFromCourse(Guid courseId, Guid studentId)
        {
            if(HasCourse(courseId))
            {
                if(IsSchoolEnrolled(studentId))
                {
                    Courses.TryGetValue(courseId, out Course course);

                    course.StudentList.Remove(
                        Students.Find(x => x.StudentId == studentId)
                    );
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public void SetGrade(Grade.Grades grading, Guid courseId, Guid studentId)
        {
            if(HasCourse(courseId))
            {
                if(IsSchoolEnrolled(studentId))
                {
                    Courses.TryGetValue(courseId, out Course course);

                    Grade grade = new Grade
                    {
                        Course = course,
                        Student = course.StudentList.Find(x => x.StudentId == studentId),
                        myGrade = grading
                    };

                    Grades.Add(grade);
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }

        }

        public void RemoveGrade(Guid courseId, Guid studentId)
        {
            Grades.Remove(
                Grades.Find(x => x.Student.StudentId == studentId)
            );
        }

        public List<Grade> GetGrades(Guid studentId)
        {
            return Grades.FindAll(x => x.Student.StudentId == studentId);
        }
    }
}
