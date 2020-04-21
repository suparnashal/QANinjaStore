using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Configurations;
using OpenQA.Selenium.Interactions;
using NinjaStorePages;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace NinjaStoreTests
{
    [TestFixture, Parallelizable]
    public class HomePageTests : BaseTest
    {        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetBrowser("http://tutorialsninja.com/demo/index.php?route=common/home");           
        }

        [TestCase("Desktops", new string[2] { "PC", "Mac" },Author ="Suparna",TestName ="C001_Verify_DesktopsMenu")]
        [TestCase("Laptops & Notebooks", new string[2] { "Macs", "Windows" },Author ="Suparna",TestName ="C002_Verify_LaptopsMenu")]
        [TestCase("Components", new string[5] { "Mice and Trackballs", "Monitors","Printers","Scanners","Web Cameras"},Author="Suparna",TestName ="C003_Verify_ComponentsMenu")]               
        public void Test_Menu_WithParameters(string mainMenu,string[] items)
        {
            Assert.That(new HomePage(driver).ValidateTopMenus(mainMenu,items), () => "Menus are incorrect");
        }

        [Test]
        public void C004_Verify_Display_FeaturedSection()
        {
           
            Assert.That(new HomePage(driver).Validate_Items_Featured(),()=>"Featured items are not matching");
        }

        
        [Test]
        public void C005_Verify_DrillDown_OnFeaturedItems()
        {           
            Assert.That(new HomePage(driver).Validate_DrillDown_FeaturedItems("MacBook"),()=>"DrillDowns are not opening page");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}