using CSharpAutomationFrameworkLearningLevel2.Base;
using OpenQA.Selenium;

namespace EAEmployeeTestLevel2.Pages
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