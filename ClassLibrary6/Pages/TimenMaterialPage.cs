using OpenQA.Selenium;
using System;
using System.Threading;

namespace ClassLibrary6
{
    internal class TimenMaterialPage
    {
       
        //implement exception handling for this class

        internal void clickCreateNewBtn(IWebDriver driver)
        {
            // Click on create new
            driver.FindElement(By.XPath("//a[contains(.,'Create New')]")).Click();

        }

        internal void enterValidInfonSave(IWebDriver driver)
        {
            Utilities.ExcelLibHelpers.PopulateInCollection(@"C:\Users\Jiji\source\repos\ClassLibrary6\ClassLibrary6\TestData\TestData.xls", "TMPage");

            driver.FindElement(By.Id("Code")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2,"Code"));

            driver.FindElement(By.Id("Description")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Description"));

            // assignment to find the price per unit
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Price"));

            driver.FindElement(By.Id("SaveButton")).Click();
        }

        internal void ValidateTM(IWebDriver driver)
        {
            //Thread.Sleep(3000);
            Utilities.Sync.waitVisiblity(driver, "Xpath","//*[@id=\"tmsGrid\"]");
            while (true)
            {
                for (var i = 1; i <= 10; i++)
                {
                    IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                    IWebElement desc = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[3]"));

                    Console.WriteLine(code.Text);
                    if (code.Text == Utilities.ExcelLibHelpers.ReadData(2,"Code") && desc.Text == Utilities.ExcelLibHelpers.ReadData(2, "Description"))
                    {
                        Console.WriteLine("Test Success");
                        return;
                    }
                }
                driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Go to the next page')]")).Click();

            }

        }
    }
}
