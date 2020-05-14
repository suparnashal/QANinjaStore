using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(200);
                    continue;
                }
                finally
                {
                    elapsed += pollingInterval;
                }

            } while (elapsed < timeout);
            throw new InvalidSelectorException($"There is no visible element found by {locator}");            
        }        

        /// <summary>
        /// Waits for element indicated by the locator to be displayes
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="locator"></param>
        public static void waitForPageToLoad(this IWebDriver webDriver,string locator)
        {            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(2000));
            wait.Until(drv=>drv.FindElement(By.XPath(locator)).Displayed) ;
        }

        /// <summary>
        /// Scrolls down to the element and clicks it
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        public static void ScrollDown(this IWebDriver webDriver,IWebElement element)
        {
            Actions action = new Actions(webDriver);            
            action.MoveToElement(element).Click();
            action.SendKeys(Keys.PageDown).Perform();            
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
