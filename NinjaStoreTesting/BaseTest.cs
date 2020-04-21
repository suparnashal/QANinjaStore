using Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStoreTests
{
  public abstract class BaseTest
    {
        protected IWebDriver driver;

        [TearDown]
        public void TearDownPerTest()
        {
            TestContext.WriteLine(TestContextData.GetAllTestContextMessages());
        }

    }
}
