using System;
using CSharpAutomationFrameworkLearningLevel2.Base;
using OpenQA.Selenium;

namespace EAEmployeeTestLevel2.Pages
{
    public class LoginPage : BasePage
    {

        public void OpenLoginWindow() => _driver.FindElement(By.LinkText("Login")).Click();
        public void EnterUserName(String username) => _driver.FindElement(By.Id("UserName")).SendKeys(username);
        public void EnterPassword(String password) => _driver.FindElement(By.Id("Password")).SendKeys(password);
        public void ClickLogin() => _driver.FindElement(By.CssSelector("input.btn")).Submit();
        public void GetEmployeeList() => _driver.FindElement(By.LinkText("Employee List")).Click();

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

        public EmployeePage ClickEmployeeList()
        {
            GetEmployeeList();
            return new EmployeePage();
        }
    }
}
