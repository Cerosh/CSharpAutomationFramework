using System;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearning.Base
{
    public abstract class AbstractBasePage
    {
        private IWebDriver _driver;
        public AbstractBasePage(IWebDriver Driver)
        {
            _driver = Driver;
        }
    }
}
