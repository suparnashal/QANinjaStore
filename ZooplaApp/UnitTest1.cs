using Framework.Configurations;
using Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using ZooplaApp.Pages;


namespace ZooplaApp
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetChromeBrowser("https://www.zoopla.co.uk/");
        }

        [Test]
        public void SeleniumChallenge_Test1()
        {                
            HomePage homepage = new HomePage(driver);
            homepage.SearchProperties("London"); //tried other values like Bristol, Oxfordshire
            PropertyListingPage propListing = new PropertyListingPage(driver);
            propListing.OpenProperty(3);
            string agentName = new PropertyDetailsPage(driver).GetAgentForProperty();            
            new AgentPage(driver).OpenAgentProperty();     
            string verifyAgentName = new PropertyDetailsPage(driver).GetAgentForProperty(); 
            Assert.That(agentName==verifyAgentName);  
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}