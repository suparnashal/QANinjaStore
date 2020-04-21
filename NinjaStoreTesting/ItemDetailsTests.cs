using Framework.Configurations;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NinjaStorePages;
using Framework.Logging;

namespace NinjaStoreTests
{
    [TestFixture,Parallelizable]
  public class ItemDetailsTests : BaseTest
    {   

        [OneTimeSetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser("http://tutorialsninja.com/demo/index.php?route=common/home");           
        }

        [TestCase(1,122,Author ="Suparna",TestName = "C007_Verify_AddToCart")]
        [TestCase(2,123, Author = "Suparna", TestName = "C008_Verify_AddToCart")]
        public void C006_Verify_AddToCart(int numOfItems, int cartPrice)
        {
            new HomePage(driver).OpenItem("Desktops","Mac");
            Assert.That(new ItemDetailsPage(driver).Validate_AddToCart(numOfItems, cartPrice),()=>"Add To Cart has failed");
        }       

        [OneTimeTearDown]
        public void Cleanup()
        {
           
            driver.Quit();
        }
    }
}
