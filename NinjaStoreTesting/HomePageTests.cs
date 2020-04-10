using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Configurations;
using OpenQA.Selenium.Interactions;
using NinjaStorePages;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace NinjaStoreTests
{
    [TestFixture]
    public class HomePageTests
    {
        private IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser();
            driver.Navigate().GoToUrl("http://tutorialsninja.com/demo/index.php?route=common/home");
            driver.Manage().Window.Maximize();
        }

        [TestCase("Desktops", new string[2] { "PC", "Mac" },Author ="Suparna",TestName ="C001_Verify_DesktopsMenu")]
        [TestCase("Laptops & Notebooks", new string[2] { "Macs", "Windows" },Author ="Suparna",TestName ="C002_Verify_LaptopsMenu")]
        [TestCase("Components", new string[5] { "Mice and Trackballs", "Monitors","Printers","Scanners","Web Cameras"},Author="Suparna",TestName ="C003_Verify_ComponentsMenu")]               
        public void Test_Menu_WithParameters(string mainMenu,string[] items)
        {
            Assert.That(new HomePage(driver).ValidateTopMenus(mainMenu,items), () => "Menus are incorrect");
        }

        [Test]
        public void C004_Test_FeaturedSection()
        {
            //Arrange
            //Find all items in Featured section
            //Act
            //Click on items in Featured section
            //Asssert
            //Verify the page that opens shows the details for corresponind product
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}