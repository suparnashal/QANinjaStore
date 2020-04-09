using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Configurations;
using OpenQA.Selenium.Interactions;
using NinjaStorePages;

namespace NinjaStoreTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            driver.Navigate().GoToUrl("http://tutorialsninja.com/demo/index.php?route=common/home");
            driver.Manage().Window.Maximize();
        }     

        [TestCase("Desktops",new string[2]{"PC","Mac"})]
        [TestCase("Laptops & Notebooks",new string[2] { "Macs", "Windows" })]
        [Test]
        public void C001_Test_Menu_WithParameters(string mainMenu,string[] items)
        {
            Assert.That(new HomePage(driver).ValidateTopMenus(mainMenu,items), () => "Menus are incorrect");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}