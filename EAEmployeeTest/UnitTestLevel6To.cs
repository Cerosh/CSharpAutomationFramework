using System;
using CSharpAutomationFrameworkLearning.Base;
using EAEmployeeTest.Pages.Level5;
using NUnit.Framework;
using static CSharpAutomationFrameworkLearning.Base.Browser;

namespace EAEmployeeTest
{
    public class TestsWithDifferentBrowsers : Base
    {
        string URL = "http://eaapp.somee.com/";
        [SetUp]
        public void Setup()
        {
            OpenBrowser(BrowserType.Chrome);
            DriverContext.Browser.GoToUrl(URL);
        }

        [Test]
        public void HandlingDifferentBrowser()
        {
            Console.WriteLine("*****Test Case Level 6*****");
            CurrentPage = GetInstance<LoginPageLevel5>();
            CurrentPage.As<LoginPageLevel5>().ClickLoginLink();
            CurrentPage.As<LoginPageLevel5>().Login("admin", "password");
            CurrentPage = CurrentPage.As<LoginPageLevel5>().ClickEmployeeList();
            CurrentPage.As<EmployeePageLevel5>().Createnew();
        }

        [TearDown]
        public void Teardown()
        {
            DriverContext.Driver.Quit();
        }
    }
}