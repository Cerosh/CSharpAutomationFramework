using System;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearning.Base
{
    public abstract class BasePageLevel3
    {
        public IWebDriver _driver;
        public BasePageLevel3()
        {
            _driver = DriverContext.Driver;
        }

    }
}
