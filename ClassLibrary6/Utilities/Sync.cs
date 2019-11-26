using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary6.Utilities
{
    class Sync
    {
        //Generic method for explicit wait
        public static void waitVisiblity(IWebDriver driver, string Locator,string value)
        {
            if (Locator == "XPath")
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 2));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
            }
            if (Locator == "Id")
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 2));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(value)));
            }
            if(Locator=="Name")
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 2));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(value)));
            }
        }
    }
}
