using Project.CSharpBasic.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CSharpBasic.Browsers
{
    class Chrome : IWebDriver
    {
        public void FindElement()
        {
            Console.WriteLine("Find the UI element in Chrome");
        }

        public void Click()
        {
            Console.WriteLine("Click the element in Chrome");
        }

        public void SendKeys(string keys)
        {
            Console.WriteLine("Send the text Chrome " + keys);
        }
    }
}
