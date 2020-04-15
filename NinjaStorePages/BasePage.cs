using Framework.Logging;
using OpenQA.Selenium;
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
                //TakeScreenshot() ;//TODO
            }
        }
    }
}
