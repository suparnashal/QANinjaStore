using Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooplaApp.Pages
{
   public class PropertyListingPage
    {        
        public IWebDriver driver; 
        public PropertyListingPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void OpenProperty(int index)
        {
            driver.waitForPageToLoad("(//div[contains(@class,'listing-results-wrapper')]//img)[3]");
            driver.waitForPageToLoad($"(//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'text-price')])[{index}]");            
            driver.ScrollDown(driver.ByXpath($"(//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'text-price')])[{index}]"));
        }

    }
}
