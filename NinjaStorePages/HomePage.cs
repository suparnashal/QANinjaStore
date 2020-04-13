using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using Framework.Extensions;
using System;

namespace NinjaStorePages
{
    public class HomePage
    {
        List<IWebElement> featuredItems => driver.AllByXpath("//h3[.='Featured']/following::div[@class='row']//h4").ToList();
        private IWebDriver driver;
        public HomePage(IWebDriver Driver)
        {
            driver = Driver;
        }

        public bool ValidateTopMenus(string mainMenu, string[] items)
        {
            driver.ByXpath($"//a[.='{mainMenu}']").MouseOver();                      
            List<string> subMenuTexts = GetAllSubMenus(mainMenu);
            return (items.All(x => subMenuTexts.Any(y => (y == x))) &&
                   subMenuTexts.All(x => items.Any(y => (y == x)))
                   ? true:false) ;
        }

        public List<string> GetAllSubMenus(string mainMenu)
        {
            List<IWebElement> subMenus = driver.AllByXpath($"//a[.='{mainMenu}']/following-sibling::div/div/ul/li[*]").ToList();         
            return (subMenus.Select(x => x.Text.Split('(')[0].Trim()).ToList());
        }
        

        public bool Validate_Items_Featured()
        {
            string[] givenFeatured = {"MacBook","iPhone", "Apple Cinema 30\"", "Canon EOS 5D" };

            //List<IWebElement> featuredItems = driver.AllByXpath("//h3[.='Featured']/following::div[@class='row']//h4").ToList();
            return (featuredItems.All(x => givenFeatured.Contains(x.Text)) ? true:false) ;
              
        }

        public bool Validate_DrillDown_FeaturedItems(string itemName)
        {
            IWebElement MacBookElement = driver.ByXpath($"//a[.='{itemName}']");
            MacBookElement.Click();            
            return (driver.ByXpath("//button[.='Add to Cart']").Displayed);            
        }

        public void OpenItem(string mainMenu,string subMenu)
        {


            //a[starts-with(text(),"Mac")]

            //a[.="Desktops"]/following-sibling::div/div/ul/li/a[starts-with(text(),"Mac")]

            //a[.="Desktops"]/following-sibling::div//a[starts-with(text(),"Mac")]

            //a[.="Desktops"]/following-sibling::div//a[starts-with(text(),"Mac")] .. works ok

            driver.ByXpath($"//a[.='{mainMenu}']").MouseOver();
            IWebElement subMenuMac = driver.ByXpath($"//a[.='Desktops']/following-sibling::div//a[starts-with(text(),'{subMenu}')]");
            subMenuMac.Click();

        }
    }
}