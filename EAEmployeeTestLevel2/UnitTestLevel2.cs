using System;
using EAEmployeeTestLevel2.Pages;
using CSharpAutomationFrameworkLearningLevel2.Base;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTestLevel2
{
    public class Tests 
    {
        string URL = "http://eaapp.somee.com/";
       
        
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Set up");
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl(URL);
        }

        [TearDown]
        public void Teardown()
        {
            DriverContext.Driver.Quit();
        }

        [Test]
        public void Test_Level2()
        {
            Console.WriteLine("*****Test Case Level 2*****");
            LoginPage loginPage = new LoginPage();
            loginPage.ClickLoginLink();
            loginPage.Login("admin", "password");
            EmployeePage employeePage = loginPage.ClickEmployeeList();
            employeePage.Createnew();
        }
    }
}