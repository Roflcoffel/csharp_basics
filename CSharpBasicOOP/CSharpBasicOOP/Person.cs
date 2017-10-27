using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicOOP {
    class Person {
        public string firstName;
        public string lastName;

        public int age;

        private static int instanceCount;

        public Person() { }

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;

            //1.5 Call IncreaseInstanceCount in the constructor to count person objects.
            IncreaseInstanceCount();
            CurrentInstanceCount();
        }

        public void Speak()
        {
            Console.WriteLine($"Hello my name is {firstName} {lastName}");
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} {age}";
        }

        public static void IncreaseInstanceCount()
        {
            instanceCount++;
        }

        public static void CurrentInstanceCount()
        {
            Console.WriteLine($"Current Instance Count: {instanceCount}");
        }


    }
}
