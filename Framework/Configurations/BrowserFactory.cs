using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Configurations
{
   public abstract class BrowserFactory
    {
        public static IWebDriver GetChromeBrowser(string url)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");            
            //options.AddArgument("--headless"); enable this option to run chrome in headless mode
            IWebDriver driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);            
            return driver;
        }
      
    }
}
