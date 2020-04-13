using Framework.Configurations;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NinjaStorePages;

namespace NinjaStoreTests
{
  public class ItemDetailsTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            driver.Navigate().GoToUrl("http://tutorialsninja.com/demo/index.php?route=common/home");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void C006_Verify_AddToCart()
        {
            new HomePage(driver).OpenItem("Desktops","Mac");
            Assert.That(new ItemDetailsPage(driver).Validate_AddToCart(1,122),()=>"Add To Cart has failed");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
