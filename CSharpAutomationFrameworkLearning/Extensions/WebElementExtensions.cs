using System;
using System.Collections.Generic;
using System.Linq;
using CSharpAutomationFrameworkLearning.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationFrameworkLearning.Extensions
{
    public static class WebnElementExtensions
    {
        public static void SelectDDL(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }
        public static void Hover(this IWebElement element)
        {
            Actions action = new Actions(DriverContext.Driver);
            action.MoveToElement(element).Perform();
        }
        public static void HoverAndClick(this IWebElement elementToHover, IWebElement elementToClick)
        {
            Actions action = new Actions(DriverContext.Driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }
        public static string GetText(IWebElement element)
        {
            return element.Text;
        }
        public static string GetSelectedDropDown(IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }
        public static IList<IWebElement> GetSelectedListOptions(IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                String elementString = element.ToString();
                bool b = element.Displayed;
                Console.WriteLine($"{elementString} : is displayed");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(String.Format("Element Not Present exception"));
        }

    }
}
