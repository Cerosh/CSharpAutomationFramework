using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace EAEmployeeTest2.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;

        public void OpenLoginWindow() => _driver.FindElement(By.LinkText("Login")).Click();
        public void EnterUserName(String username) => _driver.FindElement(By.Id("UserName")).SendKeys(username);
        public void EnterPassword(String password) => _driver.FindElement(By.Id("Password")).SendKeys(password);
        public void ClickLogin() => _driver.FindElement(By.CssSelector("input.btn")).Submit();
    }

}
