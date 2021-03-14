using System;
using CSharpAutomationFrameworkLearning.Base;
using CSharpAutomationFrameworkLearning.Helpers;
using EAEmployeeTest.Pages.Level4;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest
{
    public class PageNavigationWithCurrentPage : Base
    {
        string URL = "http://eaapp.somee.com/";

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Set up");
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl(URL);
            LogHelper.CreateLogFile();
            LogHelper.Write("Opened the browser !!!");
        }

        [TearDown]
        public void Teardown()
        {
            DriverContext.Driver.Quit();
        }


        [Test]
        public void PageNavigation_WithCurrentPage_Level4()
        {
            Console.WriteLine("*****Test Case Level 4*****");
            LoginPageLevel4 loginPage = new LoginPageLevel4();
            loginPage.ClickLoginLink();
            loginPage.Login("admin", "password");
            CurrentPage = loginPage.ClickEmployeeList();
            var table = ((EmployeePageLevel4)CurrentPage).GetEmployeeList();
            HTMLTableHelper.ReadTable(table);
            HTMLTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Edit");
        }

    }
}