using Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStorePages
{
  public class ItemDetailsPage
    {
        private IWebElement btnAddToCart => driver.ByXpath("//button/span[.='Add to Cart']") ;
        private IWebElement spanCartTotal => driver.ByXpath("//span[@id='cart-total']");
        private string cartInfo => spanCartTotal.Text;
        private IWebDriver driver;

        public ItemDetailsPage(IWebDriver Driver)
        {
            driver = Driver;
        }

        public bool Validate_AddToCart(int numOfItems,double cart_total)
        {
            btnAddToCart.Click();         
            return (VerifyItemCount(numOfItems) && VerifyCartPriceUpdated(cart_total)
                   ? true : false);
        }

        private bool VerifyCartPriceUpdated(double price)
        {            
            double cartTotal = Double.Parse(cartInfo.Substring(cartInfo.IndexOf('$')+1));
            return ((cartTotal == price) ? true : false);            
        }

        private bool VerifyItemCount(int itemcount)
        {         
            int numOfItems= Int32.Parse(cartInfo.TrimStart().Split(" ")[0]); 
            return ((numOfItems == 1) ? true : false);            
        }

       

    }
}
