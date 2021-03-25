using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Configurations;
using OpenQA.Selenium.Interactions;
using NinjaStorePages;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using OpenQA.Selenium.Chrome;
using Framework.Extensions;
using System.Drawing;
using OpenQA.Selenium.Internal;
using System.Threading;

namespace NinjaStoreTests.SampleTests
{
    [TestFixture]
    public class SeleniumSamples
    {
        private IWebDriver driver;    

        [Test]
        // This test works ok
        public void Test_DragAndDrop()
        {
            driver = BrowserFactory.GetChromeBrowser("https://dhtmlx.com/docs/products/dhtmlxTree/");
            int count = driver.FindElements(By.TagName("iframe")).Count;
            driver.SwitchTo().Frame(0);   //switch to first frame
            Thread.Sleep(2000);                                          
            driver.SwitchTo().Frame(0);   //switch the first frame inside the previous frame so index is 0
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("content");
            Thread.Sleep(2000);
            IWebElement src = driver.ByXpath("//span[.='Thrillers']");    

            IWebElement myLibrary = driver.ByXpath("//ul[@class='dhx_widget dhx_list ']");

            int countOfOptions1 = driver.FindElements(By.XPath("//ul[@class='dhx_widget dhx_list ']/li")).Count;

            Actions action = new Actions(driver);
            action.ClickAndHold(src).MoveToElement(myLibrary).Release().Build().Perform();
            
            int countOfOptions2 = driver.FindElements(By.XPath("//ul[@class='dhx_widget dhx_list ']/li")).Count;
            Assert.AreEqual(countOfOptions1 + 1, countOfOptions2) ;
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }

    }
}
