using Framework.Extensions;
using Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStorePages
{
    public class BasePage
    {
        protected IWebDriver driver; 

        public BasePage(IWebDriver driver1)
        {
            this.driver = driver1;
        }

        public void ReportFail(bool result, string message)
        {
            if (!result)
            {
                TestContextData.AddFail(message);
                TakeScreenshot() ;
            }
        }

        private void TakeScreenshot()
        {
            string path =$@"C:\suparna\GitHubProjects\QANinjaStore\Logs\{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("dd_-MM-yyyy")}.Png";
            driver.TakeScreenshot(path);
            TestContext.AddTestAttachment(path);
        }
    }
}
