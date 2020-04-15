using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Configurations
{
   public abstract class BrowserFactory
    {
        public static IWebDriver GetBrowser()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            IWebDriver driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://tutorialsninja.com/demo/index.php?route=common/home");            
            return driver;
        }
    }
}
