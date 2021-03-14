using System;
using CSharpAutomationFrameworkLearning.Base;
using CSharpAutomationFrameworkLearning.Config;
using EAEmployeeTest.Pages.Level6;
using NUnit.Framework;
using static CSharpAutomationFrameworkLearning.Base.Browser;

namespace EAEmployeeTest
{
    public class TestsWithDifferentBrowsers : Base
    {
        [SetUp]
        public void Setup()
        {
            ConfigReader.SetFrameworkSettings();
            OpenBrowser(BrowserType.Chrome);
            DriverContext.Browser.GoToUrl(Settings.AUT);
        }

        [Test]
        public void HandlingDifferentBrowser()
        {
            Console.WriteLine("*****Test Case Level 6*****");
            CurrentPage = GetInstance<LoginPageLevel6>();
            CurrentPage.As<LoginPageLevel6>().ClickLoginLink();
            CurrentPage.As<LoginPageLevel6>().Login("admin", "password");
            CurrentPage = CurrentPage.As<LoginPageLevel6>().ClickEmployeeList();
            CurrentPage.As<EmployeePageLevel6>().Createnew();
        }

        [TearDown]
        public void Teardown()
        {
            DriverContext.Driver.Quit();
        }
    }
}