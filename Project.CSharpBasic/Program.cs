using Project.CSharpBasic.Browsers;
using Project.CSharpBasic.Selenium;
using Project.CSharpBasic.ExtensionMethods;//driver.SendKeysWithSpcChar("", "");
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.CSharpBasic.Delegates;
using Project.CSharpBasic.Features;

namespace Project.CSharpBasic
{
    enum Browser
    {
        Chrome,
        Firefox,
        IE,
        Edge,
        Safari,
        Opera,
        Vivaldi
    }

    class Program
    {
        //static Program p = new Program();

        static void Main(string[] args)
        {
            ThrowsExpression_Expression_Bodied_Members();
            OutValues();
            Tuples_DeconstructionOfTuples();
            SwitchCase();
            DelegateExample();
            LINQ_SelectMany();
            LINQ_SelectProjections();
            LINQ_SelectWhere();
            ExtensionMethod();
            InterfaceForSelenium();//Interface
            Console.WriteLine(GetBrowserName(Browser.Chrome));//Interface
            GenericCollectionsWithCustomClass();
            GenericCollections();
            NonGenericCollections();
            ArrayExample();
            Looping();
            Conditional();
            Methods();
            TypesVar();
            Casting();
            NewMethod2();
            NewMethod1();
            Start();
            Console.Read();
        }

        private static void ThrowsExpression_Expression_Bodied_Members()
        {
            Student s = new Student("Mehmet");
            //s.Name = "Mehmet";
            Console.WriteLine($"Name of Student is : {s.GetStudentName()}");
            Console.WriteLine();
            s.PrintName();
            Console.WriteLine();
        }

        private static void OutValues()
        {
            HelperClass helperClass = new HelperClass();
            string name, grade;
            int age;
            helperClass.GetStudentsDetails(out name, out age, out grade);
            //helperClass.GetStudentsDetails(out string name, out int age, out string grade);
            Console.WriteLine($"From OutValues... The Student with {name} & Age {age} & Grade {grade}");
            Console.WriteLine();
        }

        private static void Tuples_DeconstructionOfTuples()
        {
            HelperClass helperClass = new HelperClass();
            var studentInfo = helperClass.ReturnStudentInfo();
            Console.WriteLine($"From Tuples... The Student with {studentInfo.name} & Age {studentInfo.age} & Grade {studentInfo.grade}");

            (string StudentName, int StudentAge, string StudentGrade) = helperClass.ReturnStudentInfo();
            if (StudentName.Contains("M"))
                Console.WriteLine($"From DeconstructionOfTuples... The Student with {StudentName} & Age {StudentAge} & Grade {StudentGrade}");
            Console.WriteLine();
        }

        private static void SwitchCase()
        {
            HelperClass helperClass = new HelperClass();
            helperClass.GetStudentInfoWithGrade(helperClass.student.First());
            helperClass.GetStudentInfoWithGrade(helperClass.student.Where(x => x.Grade == "Second").First());
        }

        private static void DelegateExample()
        {
            Printer p = DelegateTry.PrintValue1;
            p("Test Mesaj from Delegate");

            Printer p2 = delegate (string values)
            {
                Console.WriteLine($"The value printed in line : {values}");
            };
            p2("Hi");


            Printer p3 = (values) =>
            {
                Console.WriteLine($"The value printed from Lambda Expression : {values}");
            };
            p3("Hi");

            Func<string, string> p4 = delegate (string values)
             {
                 return values;
             };
            Console.WriteLine($"The value from Func delegate is this : {p4("Hi")}");

            Action<string> p5 = delegate (string values)
            {
                Console.WriteLine($"The value from Action delegate is this : {values}");
            };
            p5("Hi");

            Action<string> p6 = values =>
            {
                Console.WriteLine($"The value from Action Lambda is this : {values}");
            };
            p6("Hi");
            Console.WriteLine();
        }

        private static void LINQ_SelectMany()
        {
            List<User> users = new List<User>();
            users.Add(new User
            {
                UserId = 1,
                Name = "Mehmet1",
                Age = 30,
                Email = "test1@example.com",
                Phone = 5061800008,
                Address = new List<Address>()
                {
                    new Address
                    {
                        Street = "Test Street4",
                        Country = "Turkey",
                        FlatName = "Memo Tower9"
                    }
                }
            });
            users.Add(new User
            {
                UserId = 2,
                Name = "Mehmet2",
                Age = 40,
                Email = "test2@example.com",
                Phone = 5061800080,
                Address = new List<Address>()
                {
                    new Address
                    {
                        Street = "Test Street2",
                        Country = "ABD",
                        FlatName = "Memo Tower7"
                    },
                    new Address
                    {
                        Street = "Deneme Street2",
                        Country = "Turkey",
                        FlatName = "Memo Tower7"
                    }
                }
            });
            users.Add(new User
            {
                UserId = 3,
                Name = "Mehmet3",
                Age = 50,
                Email = "test3@example.com",
                Phone = 5061800800,
                Address = new List<Address>()
                {
                    new Address
                    {
                        Street = "Test Street1",
                        Country = "US",
                        FlatName = "Memo Tower6"
                    }
                }
            });

            //var userslist = from user in users
            //                select new
            //                {
            //                    FirstName = user.Name,
            //                    PhoneNumber = user.Phone,
            //                    Address = address
            //                };

            var userslist = from user in users
                            from address in user.Address
                            select new
                            {
                                FirstName = user.Name,
                                PhoneNumber = user.Phone,
                                Address = address
                            };
            var addresses = users.Where(x => x.Age == 40).SelectMany(x => x.Address);
            foreach (var item in userslist)
            {
                //foreach (var item2 in item.Address)
                //{
                //Console.WriteLine("User {0} has Phone number {1} with Country {2}", item.FirstName, item.PhoneNumber, item2.Country);
                Console.WriteLine("User {0} has Phone number {1} with Country {2}", item.FirstName, item.PhoneNumber, item.Address.Country);
                //}
            }
            Console.WriteLine();
        }

        private static void LINQ_SelectProjections()
        {
            List<User> users = new List<User>();
            users.Add(new User { UserId = 1, Name = "Mehmet1", Age = 30, Email = "test1@example.com", Phone = 5061800008 });
            users.Add(new User { UserId = 2, Name = "Mehmet2", Age = 40, Email = "test2@example.com", Phone = 5061800080 });
            users.Add(new User { UserId = 3, Name = "Mehmet3", Age = 50, Email = "test3@example.com", Phone = 5061800800 });

            var userslist = from user in users
                            select new
                            {
                                FirstName = user.Name,
                                PhoneNumber = user.Phone
                            };

            foreach (var item in userslist)
            {
                Console.WriteLine("User {0} has Phone number {1}", item.FirstName, item.PhoneNumber);
            }
            Console.WriteLine();
        }

        private static void LINQ_SelectWhere()
        {
            List<User> users = new List<User>();
            users.Add(new User { UserId = 1, Name = "Mehmet1", Age = 30, Email = "test1@example.com", Phone = 5061800008 });
            users.Add(new User { UserId = 2, Name = "Mehmet2", Age = 40, Email = "test2@example.com", Phone = 5061800080 });
            users.Add(new User { UserId = 3, Name = "Mehmet3", Age = 50, Email = "test3@example.com", Phone = 5061800800 });

            var userslist = from user in users
                            select user;

            var userslist1 = users.Select(x => x);
            var userslist2 = users.Select(x => x.Name);

            foreach (var item in userslist1)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item);
            }

            var userslist3 = from user in users
                             where user.Age == 40
                             select user;
            var userslist4 = users.Where(x => x.Age == 40).Select(x => x).ToList();

            foreach (var item in userslist3)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void ExtensionMethod()
        {
            IWebDriver driver = new Firefox();
            driver.SendKeysWithSpcChar("S", "Ş");
            Console.WriteLine();
        }

        private static void InterfaceForSelenium()//Interface for Selenium
        {
            IWebDriver driver = new Chrome();
            driver.FindElement();
            Console.WriteLine();
        }

        public static string GetBrowserName(Browser browser)//Enums
        {
            if (browser == Browser.Chrome)
                return "Chrome has opened";
            if (browser == Browser.Firefox)
                return "Firefox has opened";
            else
                return "Browser does not support";
        }

        public static void GenericCollectionsWithCustomClass()//Generic Collections with Custem Types
        {
            //List<User> users = new List<User>()
            //{
            //    new User {
            //        UserId = 1,
            //        Name = "Mehmet1",
            //        Age = 25,
            //        Email = "test1@example.com",
            //        Phone = 5061800008
            //    },
            //    new User { UserId = 2, Name = "Mehmet2", Age = 35, Email = "test2@example.com", Phone = 5061800080 },
            //    new User { UserId = 3, Name = "Mehmet3", Age = 45, Email = "test3@example.com", Phone = 5061800800 }
            //};

            List<User> users = new List<User>();
            users.Add(new User { UserId = 1, Name = "Mehmet1", Age = 30, Email = "test1@example.com", Phone = 5061800008 });
            users.Add(new User { UserId = 2, Name = "Mehmet2", Age = 40, Email = "test2@example.com", Phone = 5061800080 });
            users.Add(new User { UserId = 3, Name = "Mehmet3", Age = 50, Email = "test3@example.com", Phone = 5061800800 });

            foreach (var user in users)
            {
                Console.WriteLine("The User {0} with Age {1} has Email {2} and Phone {3}",
                    user.Name, user.Age, user.Email, user.Phone);
            }
            Console.WriteLine();
        }

        public class User
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public Int64 Phone { get; set; }
            public List<Address> Address { get; set; }
        }

        public class Address
        {
            public string FlatName { get; set; }
            public string Street { get; set; }
            public string Country { get; set; }
        }

        public static void GenericCollections()//Generic Collections
        {
            string[] user1 = new string[] { "Mehmet1", "25", "m1@mmn.com", "1234" };
            string[] user2 = new string[] { "Mehmet2", "35", "m2@mnm.com", "1244" };
            string[] user3 = new string[] { "Mehmet3", "45", "m3@nmm.com", "1444" };

            Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
            dict.Add(1, user1);
            dict.Add(2, user2);
            dict.Add(3, user3);

            foreach (var value in dict)
            {
                string[] usersInfo = value.Value;
                foreach (var user in usersInfo)
                {
                    Console.WriteLine(user);
                }
            }
            Console.WriteLine();
        }

        public static void NonGenericCollections()//Non Generic Collection
        {
            Hashtable table = new Hashtable();
            table.Add("UserName", "Mehmet");
            table.Add("Password", "Mehmet123");
            table.Add("Button", "Submit");

            Console.WriteLine("The UserName is : " + table["UserName"]);
            Console.WriteLine("The Password is : " + table["Password"]);
            Console.WriteLine("The Button is : " + table["Button"]);

            Console.WriteLine();

            foreach (var item in table.Keys)
            {
                Console.WriteLine("The value for " + item + " is : " + table[item]);
            }
            Console.WriteLine();
        }

        private static void ArrayExample()//Arrays
        {
            int[] testcaseid = new int[] { 101, 102, 103, 104 };
            for (int i = 0; i < testcaseid.Length; i++)
            {
                Console.WriteLine(testcaseid[i]);
            }

            string[] testcasename = new string[] { "UserForm", "Login", "Hover" };
            foreach (var item in testcasename)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void Looping()//Looping statement
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The number of is i : " + i);
            }
            Console.WriteLine();

            bool elementNotVisible = true;
            int mockNoOdSeconds = 0;
            while (elementNotVisible)
            {
                Console.WriteLine("No of seconds waiting " + mockNoOdSeconds);
                if (mockNoOdSeconds == 4)
                    elementNotVisible = false;
                mockNoOdSeconds++;
            }
            Console.WriteLine();
        }

        private static void Conditional()//Conditional statement
        {

            /*
             * State 
             * PASSED, FAILED, Inconclusive
             */

            string testCaseState2 = "Inconclusive";
            if (testCaseState2 == "PASSED")
                Console.WriteLine("testCaseState PASSED");
            else if (testCaseState2 == "FAILED")
                Console.WriteLine("testCaseState FAILED");
            else if (testCaseState2 == "Inconclusive")
                Console.WriteLine("testCaseState Inconclusive");

            testCaseState2 = "Inconclusives";
            switch (testCaseState2)
            {
                case "PASSED":
                    {
                        Console.WriteLine("testCaseState PASSED");
                        break;
                    }
                case "FAILED":
                    {
                        Console.WriteLine("testCaseState FAILED");
                        break;
                    }
                case "Inconclusive":
                    {
                        Console.WriteLine("testCaseState Inconclusive");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("testCaseState is not the one you sent");
                        break;
                    }
            }

            bool testCaseState = true;
            if (testCaseState)
            {
                Console.WriteLine("testCaseState PASSED");
            }
            else
            {
                Console.WriteLine("testCaseState FAILED");
            }
            Console.WriteLine();
        }

        private static void Methods()//Methods
        {
            TestClass1 testClass1 = new TestClass1();
            testClass1.Add(10, 20);
            int result = testClass1.Add2(10, 20);
            Console.WriteLine(result + 10);
            testClass1.Add();
            Console.WriteLine();
        }

        private static void TypesVar()//Types Var
        {
            var incomeTax = 23234.234d;
            Console.WriteLine(incomeTax.GetType().Name);

            var loginPage = new LoginPage();
            loginPage.ClickButton();
            Console.WriteLine();
        }

        private static void Casting()//Casting
        {
            Int16 salary = 32767;
            int salary2 = salary;
            Console.WriteLine(salary2);

            double incomeTax = 23234.234d;
            Console.WriteLine((int)incomeTax);

            object loginPage = new LoginPage();
            Console.WriteLine(((LoginPage)loginPage).UserName);
            //((UserListPage)loginPage).ClickButton();
            Console.WriteLine();
        }

        public class LoginPage
        {
            public string UserName { get; set; }

            public void ClickButton()
            {

            }
        }

        public class UserListPage
        {
            public string ListofUsers { get; set; }

            public void ClickButton()
            {

            }
        }

        private static void NewMethod2()//Types
        {
            TestClass1 class1 = new TestClass1();
            Int16 salary = 32767; // pls add +1
            int salary2 = 32768;
            Int64 salary3 = 32768;
            Console.WriteLine(salary);
            Console.WriteLine(salary2);
            Console.WriteLine(salary3);
            String name = "Mehmet Erdoğdu";
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.ToLower());

            bool testcase = true;
            Console.WriteLine(testcase);
            Console.WriteLine();
        }

        private static void NewMethod1()//Classes and Objects
        {
            TestClass1 class1 = new TestClass1();
            class1.TestCase1("PASSED");
            class1.TestCase2("FAILED");
            class1.SetValue(20);
            class1.GetValue();
            class1.SetValue(50);

            TestClass1 class2 = new TestClass1();
            class2.SetValue(30);
            class2.GetValue();

            class1.GetValue();
            Console.WriteLine();
        }

        private static void Start()
        {
            Console.Title = "Project CSharpBasic";
            Console.WriteLine("Project CSharpBasic");
            Console.Write("Hello Word");
            Console.WriteLine();
        }
    }
}
