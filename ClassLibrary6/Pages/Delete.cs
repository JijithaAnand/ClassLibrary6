using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClassLibrary6
{
    class Delete
    {
        internal void Deleting(IWebDriver driver)
        {
            //using wait
            Utilities.Sync.waitVisiblity(driver,"Xpath", "//*[@id=\"tmsGrid\"]");
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

                        // Console.WriteLine(code.Text);
                        //Read data from the Excel Sheet
                        if (code.Text == Utilities.ExcelLibHelpers.ReadData(2, "Code") && desc.Text == Utilities.ExcelLibHelpers.ReadData(2, "Description"))
                        {
                            driver.FindElement(By.XPath("(//a[@class='k-button k-button-icontext k-grid-Delete'][contains(.,'Delete')])[" + i + "]")).Click();
                            
                            driver.SwitchTo().Alert().Accept();
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
        internal void VerifingIfDeleted(IWebDriver driver)
        {
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
                        //Read data from the Excel Sheet
                        if (code.Text != Utilities.ExcelLibHelpers.ReadData(2, "Code") && desc.Text != Utilities.ExcelLibHelpers.ReadData(2, "Description"))
                        {
                            Console.WriteLine("Deleted Successfully");
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
