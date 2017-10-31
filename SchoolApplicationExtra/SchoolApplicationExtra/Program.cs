using SchoolApplicationExtra.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: gör en menu för när man ska skriva in id;
namespace SchoolApplicationExtra {
    class Program {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            School school = new School("Gripen");

            int answer;

            do
            {
                answer = MainMenu(school);
            } while (answer != 5);
           
        }

        public static void DisplayTeachers(List<Teacher> Teachers)
        {
            
            Teachers.ForEach(
                x => Console.WriteLine(
                    $"{Teachers.IndexOf(x)}. Teacher: {x.Firstname} {x.Lastname} - Id: {x.TeacherId} - Date Of Birth {x.DateOfBirth.ToShortDateString()}"
                )

            );

            Console.WriteLine();
        }

        public static void DisplayStudents(List<Student> Students)
        {
            Students.ForEach(
                x => Console.WriteLine(
                    $"{Students.IndexOf(x)}. Student: {x.Firstname} {x.Lastname} - Id: {x.StudentId} - Date of Birth {x.DateOfBirth.ToShortDateString()}"
                )
            );

            Console.WriteLine();
        }

        public static void DisplayGrades(List<Grade> Grades)
        {
            Grades.ForEach(
                x => Console.WriteLine(
                    $"{Grades.IndexOf(x)}. Grade: {x.Student}\nCourse: {x.Course.Name} - Grading: {x.myGrade}"
                )
            );

            Console.WriteLine();
        }

        public static void DisplayCourses(Dictionary<Guid,Course> Courses)
        {
            foreach (var x in Courses.Select((entry, index) => new { entry, index }))
            {
                Console.WriteLine($"{x.index}. Course: {x.entry.Value.Name} - Id {x.entry.Key} - Teacher: {x.entry.Value.Teacher}");
            }

            //foreach (KeyValuePair<Guid,Course> entry in Courses)
            //{
            //    Console.WriteLine($"Course: {entry.Value.Name} - Id {entry.Key} - Teacher: {entry.Value.Teacher}");
            //}

            Console.WriteLine();
        }

        public static void AddStudent(School school)
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

            Console.WriteLine("\nStudent added to school\n");
        }

        public static void AddTeacher(School school)
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

            Console.WriteLine("\nTeacher added to school\n");
        }

        public static void AddCourse(School school)
        {
            Console.WriteLine("Add a course\n");
            Console.Write("input a course name: ");
            string name = Console.ReadLine();

            AddTeacher(school);

            Course course = new Course(name, school.Teachers.Last());

            school.AddCourse(course);

            Console.WriteLine("\nCourse added to school\n");
        }

        public static void WithdrawStudent(School school)
        {
            Console.WriteLine("input student id to withdraw them: ");
            DisplayStudents(school.Students);
            Guid id = Guid.Parse(Console.ReadLine());

            school.WithdrawStudentFromSchool(id);

            Console.WriteLine("\nStudent withdrew from the school\n");
        }

        public static void WithdrawTeacher(School school)
        {
            Console.WriteLine("input teacher id to withdraw them: ");
            DisplayTeachers(school.Teachers);
            Guid id = Guid.Parse(Console.ReadLine());

            school.WithdrawTeacherFromSchool(id);

            Console.WriteLine("\nTeacher withdrew from the school\n");
        }

        public static void RemoveCourse(School school)
        {
            Console.WriteLine("input course id to remove it: ");
            DisplayCourses(school.Courses);
            Guid id = Guid.Parse(Console.ReadLine());

            school.RemoveCourse(id);

            Console.WriteLine("\nCourse removed from the school\n");
        }

        public static void SetGrade(School school) {
            Console.Write("input course id: ");
            DisplayCourses(school.Courses);
            Guid courseId = Guid.Parse(Console.ReadLine());

            Console.Write("input student id: ");
            DisplayStudents(school.Students);
            Guid studentId = Guid.Parse(Console.ReadLine());

            Console.Write("input grade from (F-A): ");
            Grade.Grades grade = (Grade.Grades) Enum.Parse(typeof(Grade.Grades), Console.ReadLine());

            school.SetGrade(grade, courseId, studentId);

            Console.WriteLine("\nGrade set on student in specified course\n");
        }

        public static void RemoveGrade(School school)
        {
            Console.Write("input course id: ");
            DisplayCourses(school.Courses);
            Guid courseId = Guid.Parse(Console.ReadLine());

            Console.Write("input student id: ");
            DisplayStudents(school.Students);
            Guid studentId = Guid.Parse(Console.ReadLine());

            school.RemoveGrade(courseId, studentId);

            Console.WriteLine("\nGrade removed from student in specified course\n");
        }

        public static void ShowGrade(School school)
        {
            Console.WriteLine("input student id: ");
            DisplayStudents(school.Students);
            Guid studentId = Guid.Parse(Console.ReadLine());

            school.GetGrades(studentId).ForEach(x => Console.WriteLine("Course: " + x.Course + " - Grade: " + x.myGrade));
        }

        public static int MainMenu(School school)
        {
            Console.WriteLine("1. Display teacher/students/courses");
            Console.WriteLine("2. Add teacher/student/course");
            Console.WriteLine("3. Withdraw student/teacher/course");
            Console.WriteLine("4. Show/Remove/Set grades");
            Console.WriteLine("\n5. Exit program");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if(input == 5)
            {
                return input;
            }
            
            SubMenu(input,  school);

            return 0;
        }

        public static void SubMenu(int num, School school)
        {
            int input;

            switch (num)
            {
                case 1:
                    Console.WriteLine("1. Display Teachers");
                    Console.WriteLine("2. Display Students");
                    Console.WriteLine("3. Display Courses");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    DisplayMenu(input,  school);
                    break;
                case 2:
                    Console.WriteLine("1. Add Teacher");
                    Console.WriteLine("2. Add Student");
                    Console.WriteLine("3. Add Course");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    AddMenu(input,  school);
                    break;
                case 3:
                    Console.WriteLine("1. Withdraw Teacher");
                    Console.WriteLine("2. Withdraw Student");
                    Console.WriteLine("3. Remove Course");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    WithdrawMenu(input,  school);
                    break;
                case 4:
                    Console.WriteLine("1. Show Grades");
                    Console.WriteLine("2. Remove Grade");
                    Console.WriteLine("3. Set Grade");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    GradeMenu(input,  school);
                    break;
                default:
                    break;
            }
        }

        public static void DisplayMenu(int num, School school)
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

        public static void AddMenu(int num, School school)
        {
            switch (num)
            {
                case 1:
                    AddTeacher( school);
                    break;
                case 2:
                    AddStudent( school);
                    break;
                case 3:
                    AddCourse( school);
                    break;
                default:
                    break;
            }
        }

        public static void WithdrawMenu(int num, School school)
        {
            switch (num)
            {
                case 1:
                    WithdrawTeacher( school);
                    break;
                case 2:
                    WithdrawStudent( school);
                    break;
                case 3:
                    RemoveCourse( school);
                    break;
                default:
                    break;
            }
        }

        public static void GradeMenu(int num, School school)
        {
            switch (num)
            {
                case 1:
                    ShowGrade( school);
                    break;
                case 2:
                    RemoveGrade( school);
                    break;
                case 3:
                    SetGrade( school);
                    break;
                default:
                    break;
            }
        }
    }
}
