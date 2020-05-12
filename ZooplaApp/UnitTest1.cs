using Framework.Configurations;
using Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;


namespace ZooplaApp
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser("https://www.zoopla.co.uk/");
        }

        [Test]
        public void SeleniumChallenge_Test1()
        {                    
            driver.NthElementByXPath("//button[.='Accept all cookies']", 1).Click();
            driver.ByXpath("//input[contains(@id,'search-input-location')]").SendKeys("London\n");                        
            
            driver.ScrollDown(driver.NthElementByXPath("//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'text-price')]", 3));
            string agentName = driver.ByXpath("//div[contains(@class,'ui-agent__text')]/h4").Text;
            driver.ByXpath("//a[@class='ui-agent__details']").Click();
            
            driver.ScrollDown(driver.NthElementByXPath("//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'listing-results-price')]", 1));            
            string verifyAgentName = driver.ByXpath("//div[contains(@class,'ui-agent__text')]/h4").Text;

            Assert.That(agentName==verifyAgentName);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}