using Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStorePages
{
  public class ItemDetailsPage : BasePage
    {
        private IWebElement btnAddToCart => driver.ByXpath("//button/span[.='Add to Cart']") ;
        private IWebElement spanCartTotal => driver.ByXpath("//span[@id='cart-total']");
        private string cartInfo => spanCartTotal.Text;        

        public ItemDetailsPage(IWebDriver Driver):base(Driver)
        {
            
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
            if (cartTotal == price)
                return true;
            else
            {
                ReportFail(false, "Cart Price not updated correctly");
                return false;
            }
        }

        private bool VerifyItemCount(int itemcount)
        {         
            int numOfItems= Int32.Parse(cartInfo.TrimStart().Split(" ")[0]);             
            if (numOfItems == itemcount)
                return true;
            else
            {
                ReportFail(false, "Number of items in cart not updated correctly");
                return false;
            }
        }

       

    }
}
