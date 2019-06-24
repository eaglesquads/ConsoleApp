using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CSharpBasic.Features
{
    public class HelperClass
    {
        public List<Student> student = null;
        public HelperClass()
        {
            var s = new List<Student>
            {
                new Student()
                {
                    Name="Mehmet",
                    Age=25,
                    Grade="First",
                    Gender="Male"
                },
                new Student()
                {
                    Name="Ayşe",
                    Age=35,
                    Grade="Second",
                    Gender="Female"
                },
                new Student()
                {
                    Name="Kazım",
                    Age=45,
                    Grade="Third",
                    Gender="Male"
                },
            };
            student = s;
        }

        public void GetStudentInfoWithGrade(Student student)
        {
            switch (student)
            {
                case Student s when (s.Grade == "First" && s.Name.Contains("M")):
                    Console.WriteLine($"Student With Name {s.Name} is with Age {s.Age}");
                    break;
                case Student s when (s.Grade == "Second"):
                    Console.WriteLine($"Student With Name {s.Name} is with Age {s.Age}");
                    break;
                default:
                    break;
            }
        }

        public (string name, int age, string grade) ReturnStudentInfo()
        {
            return ("Mehmet", 25, "A");
        }

        public void GetStudentsDetails(out string name, out int age, out string grade)
        {
            name = "Mehmet";
            age = 25;
            grade = "A";
        }

    }

    public class Student
    {
        public Student()
        {

        }
        public Student(string name) => Name = name;

        private int _salary;

        //public int Salary
        //{
        //    get { return _salary; }
        //    set { _salary = value; }
        //}

        public int Salary
        {
            get => _salary;
            set => _salary = value;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
        public string Gender { get; set; }

        public string GetStudentName()
        {
            return Name;
            //return Name ?? throw new TypeInitializationException("Project.Student.Name", new Exception("Name has to be initialized before calling it"));
        }

        //public void PrintName()
        //{
        //    Console.WriteLine($"The name of Student is {Name}");
        //}

        public void PrintName() => Console.WriteLine($"From Class... The name of Student is {Name}");
    }
}
