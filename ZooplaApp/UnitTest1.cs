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
            ReadOnlyCollection<IWebElement> cookieElements = driver.AllByXpath("//button[.='Accept all cookies']");
            cookieElements[1].Click();            
            driver.ByXpath("//input[contains(@id,'search-input-location')]").SendKeys("London");            
            driver.ByXpath("//button[@id='search-submit']").Click();

            //click on 5th property
            ReadOnlyCollection<IWebElement> listOfProperties = driver.AllByXpath("//ul[contains(@class,'listing-results')]/li[@data-listing-id]//a[contains(@class,'text-price')]");
            //need to scroll down before doing the click
            listOfProperties[0].Click();
            //click on the agent's name
            driver.ByXpath("//a[@class='ui-agent__details']").Click();
            
            //need to scroll down before doing the click
            driver.AllByXpath("//ul[contains(@class,'listing-results')]/li[@data-listing-id]")[1].Click();
            ////div[@class="ui-agent__text"]   //a[@class="ui-agent__details"].click

        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}