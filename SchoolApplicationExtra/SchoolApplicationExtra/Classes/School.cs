﻿using System;
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
            Course course;
            return Courses.TryGetValue(courseId, out course);
        }

        public void AddCourse(Course course)
        {
            if(HasCourse(course.CourseId))
            {
                throw new Exception();
            }
            else
            {
                Courses.Add(course.CourseId, course);
            }

        }

        public void RemoveCourse(Guid courseId)
        {
            Courses.Remove(courseId);
        }

        public bool IsStudentEnrolled(Guid studentId)
        {
            return Students.Contains(Students.Find(x => x.StudentId == studentId));
        }

        public bool IsTeacherEnrolled(Guid teacherId)
        {
            return Teachers.Contains(Teachers.Find(x => x.TeacherId == teacherId));
        }

        public bool IsCourseEnrolled(Guid courseId, Guid studentId)
        {
            return Courses[courseId].StudentList.Contains(
                Courses[courseId].StudentList.Find(
                    x => x.StudentId == studentId
                )
            );
        }

        public void EnrollCourse(Guid courseId, Guid studentId)
        {
            if (IsStudentEnrolled(studentId))
            {
                if (HasCourse(courseId))
                {
                    if (IsCourseEnrolled(courseId, studentId))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        Courses[courseId].StudentList.Add(
                            Students.Find(x => x.StudentId == studentId)
                        );
                    }
                }
            }
        }

        public void EnrollSchool(Student student)
        {
            if (IsStudentEnrolled(student.StudentId))
            {
                throw new Exception();
            }
            else
            {
                Students.Add(student);
            }
        }

        public void WithdrawFromSchool(Guid Id, bool isStudent)
        {
            if (isStudent)
            {
                if (!IsStudentEnrolled(Id))
                {
                    throw new Exception();
                }
                else
                {
                    Students.Remove(
                        Students.Find(x => x.StudentId == Id)
                    );
                }
            }
            else
            {
                if (!IsTeacherEnrolled(Id))
                {
                    throw new Exception();
                }
                else
                {
                    Teachers.Remove(
                        Teachers.Find(x => x.TeacherId == Id)
                    );
                }
            }
            
        }

        public void WithdrawFromCourse(Guid courseId, Guid studentId)
        {
            if(HasCourse(courseId))
            {
                if(IsStudentEnrolled(studentId))
                {
                    Courses[courseId].StudentList.Remove(
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
                if(IsStudentEnrolled(studentId))
                {
                    Grade grade = new Grade
                    {
                        Course = Courses[courseId],
                        Student = Courses[courseId].StudentList.Find(x => x.StudentId == studentId),
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
