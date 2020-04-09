using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Extensions
{
   public static class WebElementExtensions
    {
        /// <summary>
        /// Mouse Over an element using Actions
        /// </summary>
        /// <param name="element"></param>
        public static void MouseOver(this IWebElement element)
        {
            IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

    }
}
