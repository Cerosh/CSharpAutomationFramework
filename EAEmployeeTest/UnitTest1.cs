using System;
using EAEmployeeTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest
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
        public void Test_Level0()
        {
            Login();
        }
        public void Login()
        {
            _driver.FindElement(By.LinkText("Login")).Click();
            _driver.FindElement(By.Id("UserName")).SendKeys("admin");
            _driver.FindElement(By.Id("Password")).SendKeys("password");
            _driver.FindElement(By.CssSelector("input.btn")).Submit();

        }
        [Test]
        public void POMTest_Level1()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.OpenLoginWindow();
            loginPage.EnterUserName("admin");
            loginPage.EnterPassword("password");
            loginPage.ClickLogin();
        }
    }
}