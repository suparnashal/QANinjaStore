using Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooplaApp.Pages
{
   public class AgentPage
    {
        public IWebDriver driver;

        public AgentPage(IWebDriver _driver)
        {
            driver = _driver; 
        }

        public void OpenAgentProperty()
        {
            driver.waitForPageToLoad("(//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'listing-results-price')])[1]");
            driver.ScrollDown(driver.ByXpath("(//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'listing-results-price')])[1]"));
        }
    }
}
