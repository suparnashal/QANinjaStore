using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Configurations;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NinjaStoreTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            driver.Navigate().GoToUrl("http://tutorialsninja.com/demo/index.php?route=common/home");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void C001_Test_Desktops_Menu()
        {
            IWebElement desktopMenu = driver.FindElement(By.XPath("//a[.='Desktops']"));
            Actions action = new Actions(driver);
            action.MoveToElement(desktopMenu).Perform();

            IWebElement PCMenuItem = driver.FindElement(By.XPath("//a[contains(text(),'PC')]"));
            IWebElement MacMenuItem = driver.FindElement(By.XPath("//a[contains(text(),'Mac')]"));

            Assert.Multiple(() =>
                {
                    Assert.IsTrue(PCMenuItem.Displayed);
                    Assert.IsTrue(MacMenuItem.Displayed);
                }
            );
        }

        [TestCase("Desktops",new string[2]{"PC", "Mac"})]
        //[TestCase("Components","Monitors")]
        [Test]
        public void C002_Test_Menu_WithParameters(string mainMenu,string[] items)
        {
            IWebElement desktopMenu = driver.FindElement(By.XPath($"//a[.='{mainMenu}']"));
            Actions action = new Actions(driver);
            action.MoveToElement(desktopMenu).Perform();

            List<IWebElement> subMenus = driver.FindElements(By.XPath($"//a[.='{mainMenu}']/following-sibling::div/div/ul/li[*]")).ToList();
            //need to split on first space
            List<string> subMenuTexts = subMenus.Select(x => x.Text).ToList();

            Assert.IsTrue(items.Any(x => subMenuTexts.Any(y => (y == x)))) ;           
            
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}