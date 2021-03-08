using System;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearningLevel2.Base
{
    public abstract class BasePage
    {
        public IWebDriver _driver;
        public BasePage()

        {
            _driver = DriverContext.Driver;
            Console.WriteLine("Inside The Base Page");
        }

    }
}
