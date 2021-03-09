using System;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearning.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;
        public Browser(IWebDriver Driver) => _driver = Driver;
        public BrowserType Type { get; set; }
        public enum BrowserType
        {
            InternetExplorer,
            FireFox,
            Chrome
        }
        public void GoToUrl(String url) => DriverContext.Driver.Url = url;
    }
}
