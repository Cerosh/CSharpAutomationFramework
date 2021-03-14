using System;
using CSharpAutomationFrameworkLearning.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages.Level4
{
    public class EmployeePageLevel4 : BasePage
    {
        IWebElement lnkCreatenew() => _driver.FindElement(By.LinkText("Create New"));
        IWebElement tblEmployeeList() => _driver.FindElement(By.ClassName("table"));

        public CreateEmployeePageLevel4 ClickCreateNew()
        {
            lnkCreatenew().Click();
            return new CreateEmployeePageLevel4();
        }

        public IWebElement GetEmployeeList() { return tblEmployeeList(); }
    }
}
