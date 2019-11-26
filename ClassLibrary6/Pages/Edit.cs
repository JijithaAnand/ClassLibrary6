using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClassLibrary6
{
    class Edit
    {
        //use common driver here (avoid multiple driver init)
        internal void Editing(IWebDriver driver)
        {
            //using wait
            Utilities.Sync.waitVisiblity(driver, "Xpath", "//*[@id=\"tmsGrid\"]");
            //Populating data from Excel sheet
            Utilities.ExcelLibHelpers.PopulateInCollection(@"C:\Users\Jiji\source\repos\ClassLibrary6\ClassLibrary6\TestData\TestData.xls", "TMPage");
            try
            {
                while (true)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        IWebElement desc = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[3]"));

                        if (code.Text == Utilities.ExcelLibHelpers.ReadData(2, "Code") && desc.Text == Utilities.ExcelLibHelpers.ReadData(2, "Description"))
                        {
                            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[5]/a[1]")).Click();
                            //Read data from the Excel Sheet
                            Utilities.ExcelLibHelpers.PopulateInCollection(@"C:\Users\Jiji\source\repos\ClassLibrary6\ClassLibrary6\TestData\TestData.xls", "DeletePage");
                            driver.FindElement(By.Id("Code")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Code"));

                            driver.FindElement(By.Id("Description")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Description"));

                           
                            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys(Utilities.ExcelLibHelpers.ReadData(2, "Price"));

                            driver.FindElement(By.Id("SaveButton")).Click();

                            //implement assert
                            return;
                        }
                    }
                    driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Go to the next page')]")).Click();
                }
            }
            catch
            {
                Console.WriteLine("Test Failed As Time and Material Gid doesnt load successfully");
                Assert.Fail();
            }
        }
        internal void VerifyEdited(IWebDriver driver)
        {
            //using wait
            Utilities.Sync.waitVisiblity(driver, "Xpath", "//*[@id=\"tmsGrid\"]");
            //Populating data from Excel sheet
            Utilities.ExcelLibHelpers.PopulateInCollection(@"C:\Users\Jiji\source\repos\ClassLibrary6\ClassLibrary6\TestData\TestData.xls", "DeletePage");
            try
            {
                while (true)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        IWebElement desc = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[3]"));
                        //Read data from Excel Sheet
                        if (code.Text == Utilities.ExcelLibHelpers.ReadData(2, "Code") && desc.Text == Utilities.ExcelLibHelpers.ReadData(2, "Description"))
                        {
                            Console.WriteLine("Edited Successfully");
                            Assert.Pass();
                            return;
                        }
                    }
                    driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Go to the next page')]")).Click();

                }
            }
            catch
            {
                Console.WriteLine("Test Failed As Time and Material Gid doesnt load successfully");
                Assert.Fail();

            }
        }
    }
}
