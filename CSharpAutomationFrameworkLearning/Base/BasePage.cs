using System;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearning.Base
{
    public abstract class BasePage : Base
    {
        public IWebDriver _driver;

        public BasePage()
        {
            _driver = DriverContext.Driver;
            Console.WriteLine("Inside Base Page");
        }
        
    }
}
