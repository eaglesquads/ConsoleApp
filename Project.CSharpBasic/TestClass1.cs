using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CSharpBasic
{
    class TestClass1
    {

        public int Add2(int num1, int num2)
        {
            return num1 + num2;
        }

        public void Add()
        {
            Console.WriteLine("This is empty Add method");
        }

        public void Add(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine("This is empty Add method with two parameters {0}", num1 + num2);
            Console.WriteLine("This is empty Add method with two parameters : " + num1 + num2);
            Console.WriteLine("This is empty Add method with two parameters : " + result);
        }

        private int i = 0;

        public void SetValue(int value)
        {
            i = value;
        }

        public void GetValue()
        {
            Console.WriteLine("The value of i is : " + i);
        }

        public void TestCase1(string result)
        {
            Console.WriteLine("TestCase1 running " + result);
        }

        public void TestCase2(string result)
        {
            Console.WriteLine("TestCase2 running " + result);
        }
    }
}
