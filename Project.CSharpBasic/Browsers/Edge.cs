using Project.CSharpBasic.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CSharpBasic.Browsers
{
    class Edge : IWebDriver
    {
        public void FindElement()
        {
            Console.WriteLine("Find the UI element in Edge");
        }

        public void Click()
        {
            Console.WriteLine("Click the element in Edge");
        }

        public void SendKeys(string keys)
        {
            Console.WriteLine("Send the text Edge " + keys);
        }
    }
}
