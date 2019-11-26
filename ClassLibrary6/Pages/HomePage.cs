using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ClassLibrary6
{
    internal class HomePage
    {
        internal void ClickAdminstration(IWebDriver driver)
        {
            try
            {
                //Adminstration link
                var admLnk = driver.FindElement(By.XPath("//a[contains(.,'Administration')]"));
                //var a = 0;
                admLnk.Click();
                Assert.Pass();
            }
            catch
            {
                Console.WriteLine("Test Failed Aa Administration dropdown doesnt exist");
                Assert.Fail();
            }
        }

        internal void ClickTimenMaterial(IWebDriver driver)
        {

            //Click on Time n materials in drop down
            driver.FindElement(By.XPath("//a[contains(.,'Time & Materials')]")).Click();
        }
    }
}