using Framework.Configurations;
using Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace HeroKuppApp
{
    public class Tests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser("http://the-internet.herokuapp.com/");
        }

        [Test]
        public void Test_Basic_Auth_Way1()
        {            
            Thread.Sleep(100);
            driver.Navigate().GoToUrl("http://admin:admin@the-internet.herokuapp.com/basic_auth");
            if (driver.ByXpath("//p[contains(text(),'Congrat')]").Displayed)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Test_ForBroken_Images()
        {
          
        }
        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}