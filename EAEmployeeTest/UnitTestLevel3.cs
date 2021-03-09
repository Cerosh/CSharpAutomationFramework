using System;
using CSharpAutomationFrameworkLearning.Base;
using CSharpAutomationFrameworkLearning.Helpers;
using EAEmployeeTest.Pages.Level3;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest
{
    public class PageNavigationWithDriverContext : Base
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
        public void PageNavigation_Level3()
        {
            Console.WriteLine("*****Test Case Level 3*****");
           
            LoginPageLevel3 loginPage = new LoginPageLevel3();
            loginPage.ClickLoginLink();
            loginPage.Login("admin", "password");
            LogHelper.Write("Entered the user credentials");
            EmployeePage employeePage = loginPage.ClickEmployeeList();
            employeePage.Createnew();
        }
    }
}