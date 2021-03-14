using System;
using CSharpAutomationFrameworkLearning.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages.Level4
{
    public class LoginPageLevel4 : BasePageLevel3
    {
        void OpenLoginWindow() => _driver.FindElement(By.LinkText("Login")).Click();
        void EnterUserName(String username) => _driver.FindElement(By.Id("UserName")).SendKeys(username);
        void EnterPassword(String password) => _driver.FindElement(By.Id("Password")).SendKeys(password);
        void ClickLogin() => _driver.FindElement(By.CssSelector("input.btn")).Submit();
        void GetEmployeeList() => _driver.FindElement(By.LinkText("Employee List")).Click();

        public void Login(string userName, string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickLogin();
        }

        public void ClickLoginLink()
        {
            OpenLoginWindow();
        }

        public EmployeePageLevel4 ClickEmployeeList()
        {
            GetEmployeeList();
            return new EmployeePageLevel4();
        }
    }
}
