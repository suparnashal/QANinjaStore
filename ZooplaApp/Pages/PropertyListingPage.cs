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
            driver.ScrollDown(driver.NthElementByXPath("//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'text-price')]", index));
        }

    }
}
