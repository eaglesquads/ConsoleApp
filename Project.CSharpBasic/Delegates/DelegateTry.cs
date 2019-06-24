﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CSharpBasic.Delegates
{

    delegate void Printer(string printValue);

    public class DelegateTry
    {
        public static void PrintValue(string values)
        {
            Console.WriteLine($"The value is : {values}");
        }

        public static void PrintValue1(string values)
        {
            Console.WriteLine($"The value is from PrintValue 1 : {values}");
        }
    }
}
