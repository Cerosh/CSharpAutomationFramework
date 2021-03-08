using System;
using CSharpAutomationFrameworkLearning.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages.Level3
{
    public class EmployeePage : BasePage
    {
        public void Createnew() => _driver.FindElement(By.LinkText("Create New")).Click();
        public CreateEmployeePage ClickCreateNew()
        {
            Createnew();
            return new CreateEmployeePage();
        }
    }
}
