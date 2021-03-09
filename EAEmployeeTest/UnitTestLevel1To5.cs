using System;
using CSharpAutomationFrameworkLearning.Base;
using EAEmployeeTest.Pages;
using EAEmployeeTest.Pages.Level3;
using EAEmployeeTest.Pages.Level5;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest
{
    public class Tests : Base
    {
        string URL = "http://eaapp.somee.com/";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Set up");
            DriverContext.Driver = new ChromeDriver();
            //_driver = new ChromeDriver();
            _driver = DriverContext.Driver;
            _driver.Navigate().GoToUrl(URL);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            DriverContext.Driver.Quit();
        }

        [Test]
        public void Test_Level0()
        {
            Console.WriteLine("*****Test Case Level 0*****");
            _driver.FindElement(By.LinkText("Login")).Click();
            _driver.FindElement(By.Id("UserName")).SendKeys("admin");
            _driver.FindElement(By.Id("Password")).SendKeys("password");
            _driver.FindElement(By.CssSelector("input.btn")).Submit();
        }
        [Test]
        /*Page Object model is an object design pattern in Selenium, where web pages are represented as 
         * classes, and the various elements on the page are defined as variables on the class. 
         * All possible user interactions can then be implemented as methods on the class:*/
        public void POMTest_Level1()
        {
            Console.WriteLine("*****Test Case Level 1*****");
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.OpenLoginWindow();
            loginPage.EnterUserName("admin");
            loginPage.EnterPassword("password");
            loginPage.ClickLogin();
        }
        [Test]
        /*Abstract class: is a restricted class that cannot be used to create objects(to access it, 
         * it must be inherited from another class). Abstract method: can only be used in an abstract class, 
         * and it does not have a body.The body is provided by the derived class (inherited from).*/
        public void AbstractBasePage_Level2()
        {
            Console.WriteLine("*****Test Case Level 2*****");
            LoginPageWithAbstractBasePage loginPage = new LoginPageWithAbstractBasePage(_driver);
            loginPage.OpenLoginWindow();
            loginPage.EnterUserName("admin");
            loginPage.EnterPassword("password");
            loginPage.ClickLogin();
        }
        
        [Test]
        public void PageNavigation_WithCurrentPage_Level4()
        {
            Console.WriteLine("*****Test Case Level 4*****");
            LoginPageLevel3 loginPage = new LoginPageLevel3();
            loginPage.ClickLoginLink();
            loginPage.Login("admin", "password");
            CurrentPage = loginPage.ClickEmployeeList();
            ((EmployeePage)CurrentPage).Createnew();
        }
        [Test]
        public void PageNavigation_WithGenerics_Level5()
        {
            Console.WriteLine("*****Test Case Level 5*****");
            CurrentPage = GetInstance<LoginPageLevel5>();
            CurrentPage.As<LoginPageLevel5>().ClickLoginLink();
            CurrentPage.As<LoginPageLevel5>().Login("admin", "password");
            CurrentPage = CurrentPage.As<LoginPageLevel5>().ClickEmployeeList();
            CurrentPage.As<EmployeePageLevel5>().Createnew();
        }

    }
}