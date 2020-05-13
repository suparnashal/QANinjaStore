using Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooplaApp.Pages
{
  public class PropertyDetailsPage
    {
        public IWebDriver driver; 
        public PropertyDetailsPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public string GetAgentForProperty()
        {
            string agentName = driver.ByXpath("//div[contains(@class,'ui-agent__text')]/h4").Text;
            driver.ByXpath("//a[@class='ui-agent__details']").Click();
            return agentName;
        }
    }
}
