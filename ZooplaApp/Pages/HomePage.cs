using Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooplaApp.Pages
{
  public class HomePage
    {
        public IWebDriver  driver { get; set; }
        private IWebElement btnAcceptCookies => driver.NthElementByXPath("//button[.='Accept all cookies']", 1);
        public IWebElement btnSearchCity => driver.ByXpath("//input[contains(@id,'search-input-location')]");
        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void SearchProperties(string city)
        {
            btnAcceptCookies.Click();
            btnSearchCity.SendKeys($"{city}\n");            
        }
    }
}
