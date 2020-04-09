using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Framework.Extensions
{
  public static class WebDriverExtensions
    {
        /// <summary>
        /// Get all elements by XPath
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> AllByXpath(this IWebDriver webDriver,string locator)
        {
            return(webDriver.FindElements(By.XPath(locator)));
        }

        /// <summary>
        /// Get element by XPath
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IWebElement ByXpath(this IWebDriver webDriver, string locator)
        {
            return (webDriver.FindElement(By.XPath(locator)));
        }
    }
}
