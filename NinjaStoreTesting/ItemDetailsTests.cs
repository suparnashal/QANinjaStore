﻿using Framework.Configurations;
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
            driver = BrowserFactory.GetBrowser();           
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
