using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using Framework.Extensions;

namespace NinjaStorePages
{
    public class HomePage
    {
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
    }
}