using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary6
{
    internal class LoginPage
    {
        internal void LoginSuccess(IWebDriver driver)
        {
            Utilities.ExcelLibHelpers.PopulateInCollection(@"C:\Users\Jiji\source\repos\ClassLibrary6\ClassLibrary6\TestData\TestData.xls", "LoginPage");
            //open the google page
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            //send username
            driver.FindElement(By.Id("UserName")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Username"));
            //send password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Password"));
            //click on submit button
            IWebElement loginBtn = driver.FindElement(By.XPath("//input[@type='submit']"));
            loginBtn.Click();

            //Consider building conditional assertions
            Assert.Pass();
        }
    }
}
