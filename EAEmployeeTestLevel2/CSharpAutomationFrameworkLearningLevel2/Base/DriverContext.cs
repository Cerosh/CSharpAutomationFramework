using System;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearningLevel2.Base
{
    public static class DriverContext
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value;
        }
    }
}
