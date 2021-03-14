using System;
using System.Diagnostics;
using CSharpAutomationFrameworkLearning.Base;
using CSharpAutomationFrameworkLearning.Config;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearning.Extensions
{
    public static class WebDriverExtensions
    {
       internal static void WaitForDocumentLoaded(this IWebDriver driver)
        {
            Console.WriteLine("Waiting For Loading To Complete");
            driver.WaitForCondition(drv =>
            {
                string state = drv.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, Settings.Timeout);
        }
        internal static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                };
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeout)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }
        internal static object ExecuteJs(this IWebDriver driver, String script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
