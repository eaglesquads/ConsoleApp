using Project.CSharpBasic.Selenium;

namespace Project.CSharpBasic.ExtensionMethods
{
    public static class WebDriverExtension
    {
        public static void SendKeysWithSpcChar(this IWebDriver driver, string keys, string splChar)
        {
            driver.SendKeys(keys);
            driver.SendKeys(splChar);
        }
    }
}
