using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;

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
            int elapsed = 0, timeout = 1000,pollingInterval=200;
            do
            {
                try
                {
                    IWebElement element = webDriver.FindElement(By.XPath(locator));
                    if (element != null) 
                        return element;

                    elapsed += pollingInterval;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(200);
                    continue;
                }

            } while (elapsed < timeout);
            throw new InvalidSelectorException($"There is no visible element found by {locator}");            
        }

        public static IWebElement NthElementByXPath(this IWebDriver webDriver,string locator,int index)
        {
            int elapsed = 0, timeout = 1000, pollingInterval = 200;
            do
            {
                try
                {
                 ReadOnlyCollection<IWebElement> element = webDriver.FindElements(By.XPath(locator));
                    if (element != null)
                        return element[index];

                    elapsed += pollingInterval;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(200);
                    continue;
                }

            } while (elapsed < timeout);
            throw new InvalidSelectorException($"There is no visible element found by {locator}");
        }
        public static void ScrollDown(this IWebDriver webDriver,IWebElement element)
        {
            Actions action = new Actions(webDriver);
            action.MoveToElement(element).Click();
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Take screenshot
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="saveLocation"></param>
        public static void TakeScreenshot(this IWebDriver webDriver, string saveLocation)
        {
            ITakesScreenshot screenshotDriver = webDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation,ScreenshotImageFormat.Png);
        }
    }
}
