using System;
using EAEmployeeTest2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest2
{
    public class Tests
    {
        string URL = "http://eaapp.somee.com/";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Set up");
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(URL);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }

        
        [Test]
        public void POMTest_Level2()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.OpenLoginWindow();
            loginPage.EnterUserName("admin");
            loginPage.EnterPassword("password");
            loginPage.ClickLogin();
        }
    }
}