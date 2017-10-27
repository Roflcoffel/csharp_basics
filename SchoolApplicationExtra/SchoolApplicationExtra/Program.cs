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
            Console.ForegroundColor = ConsoleColor.White;

            School school = new School("Gripen");

            string answer;

            do
            {
                MainMenu(ref school);

                Console.WriteLine("Exit program? (yes/no) ");
                answer = Console.ReadLine();
            } while (answer == "no");
           
        }

        public static void DisplayTeachers(List<Teacher> Teachers)
        {
            Teachers.ForEach(
                x => Console.WriteLine(
                    $"Teacher: {x.Firstname} {x.Lastname} - Id: {x.TeacherId} - Date Of Birth {x.DateOfBirth.ToShortDateString()}"
                )

            );

            Console.WriteLine();
        }

        public static void DisplayStudents(List<Student> Students)
        {
            Students.ForEach(
                x => Console.WriteLine(
                    $"Student: {x.Firstname} {x.Lastname} - Id: {x.StudentId} - Date of Birth {x.DateOfBirth.ToShortDateString()}"
                )
            );

            Console.WriteLine();
        }

        public static void DisplayGrades(List<Grade> Grades)
        {
            Grades.ForEach(
                x => Console.WriteLine(
                    $"Grade: {x.Student}\nCourse: {x.Course.Name} - Grading: {x.myGrade}"
                )
            );

            Console.WriteLine();
        }

        public static void DisplayCourses(Dictionary<Guid,Course> Courses)
        {
            foreach (KeyValuePair<Guid,Course> entry in Courses)
            {
                Console.WriteLine($"Course: {entry.Value.Name} - Id {entry.Key} - Teacher: {entry.Value.Teacher}");
            }

            Console.WriteLine();
        }

        public static void AddStudent(ref School school)
        {
            Console.WriteLine("Add a student\n");
            Console.Write("input a firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("input a lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("input a date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Student student = new Student(firstName, lastName, dateOfBirth);

            school.EnrollSchool(student);
        }

        public static void AddTeacher(ref School school)
        {
            Console.WriteLine("Add a teacher\n");
            Console.Write("input a firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("input a lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("input a date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Teacher teacher = new Teacher(firstName, lastName, dateOfBirth);

            school.Teachers.Add(teacher);
        }

        public static void AddCourse(ref School school)
        {
            Console.WriteLine("Add a course\n");
            Console.Write("input a course name: ");
            string name = Console.ReadLine();

            AddTeacher(ref school);

            Course course = new Course(name, school.Teachers.Last());

            school.AddCourse(course);
        }

        public static void WithdrawStudent(ref School school)
        {
            Console.Write("input student id to withdraw them: ");
            DisplayStudents(school.Students);
            Guid id = Guid.Parse(Console.ReadLine());

            school.WithdrawStudentFromSchool(id);
            
        }

        public static void WithdrawTeacher(ref School school)
        {
            Console.Write("input teacher id to withdraw them: ");
            DisplayTeachers(school.Teachers);
            Guid id = Guid.Parse(Console.ReadLine());

            school.WithdrawTeacherFromSchool(id);

        }

        public static void RemoveCourse(ref School school)
        {
            Console.Write("input course id to remove it: ");
            DisplayCourses(school.Courses);
            Guid id = Guid.Parse(Console.ReadLine());

            school.RemoveCourse(id);
        }

        public static void MainMenu(ref School school)
        {
            Console.WriteLine("1. Display teacher/students/courses");
            Console.WriteLine("2. Add teacher/student/course");
            Console.WriteLine("3. Withdraw student/teacher/course");
            Console.WriteLine("4. Show/Remove/Set grades");
            int input = Convert.ToInt32(Console.ReadLine());

            SubMenu(input, ref school);
        }

        public static void SubMenu(int num, ref School school)
        {
            int input;

            switch (num)
            {
                case 1:
                    Console.WriteLine("1. Display Teachers");
                    Console.WriteLine("2. Display Students");
                    Console.WriteLine("3. Display Courses");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("1. Add Teacher");
                    Console.WriteLine("2. Add Student");
                    Console.WriteLine("3. Add Course");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("1. Withdraw Teacher");
                    Console.WriteLine("2. Withdraw Student");
                    Console.WriteLine("3. Remove Course");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("1. Show Grades");
                    Console.WriteLine("2. Remove Grade");
                    Console.WriteLine("3. Set Grade");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    break;
            }
        }

        public static void DisplayMenu(int num, ref School school)
        {
            switch (num)
            {
                case 1:
                    DisplayTeachers(school.Teachers);
                    break;
                case 2:
                    DisplayStudents(school.Students);
                    break;
                case 3:
                    DisplayCourses(school.Courses);
                    break;
                default:
                    break;
            }
        }

        public static void AddMenu(int num, ref School school)
        {
            switch (num)
            {
                case 1:
                    AddTeacher(ref school);
                    break;
                case 2:
                    AddStudent(ref school);
                    break;
                case 3:
                    AddCourse(ref school);
                    break;
                default:
                    break;
            }
        }

        public static void WithdrawMenu(int num, ref School school)
        {
            switch (num)
            {
                case 1:
                    WithdrawTeacher(ref school);
                    break;
                case 2:
                    WithdrawStudent(ref school);
                    break;
                case 3:
                    RemoveCourse(ref school);
                    break;
                default:
                    break;
            }
        }

        public static void GradeMenu(int num, ref School school)
        {
            switch (num)
            {
                case 1:
                    //showGrade(),
                    break;
                case 2:
                    //removeGrade();
                    break;
                case 3:
                    //setGrade();
                    break;
                default:
                    break;
            }
        }
    }
}
