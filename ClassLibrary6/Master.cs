using ClassLibrary6.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ClassLibrary6
{
    class Master
    {
        class Program
        {
         
            //good to have comments

            [SetUp]
            public void BeforeEachTest()
            {
                // Initiating the driver
                CommonDriver.driver = new ChromeDriver();
                LoginPage loginPage = new LoginPage();
                loginPage.LoginSuccess(CommonDriver.driver);
            }

            [TearDown]
            public void AfterEachTest()
            {
                CommonDriver.driver.Quit();
            }

            [Test]
            public void createTMnVerify()
            {
                HomePage home = new HomePage();
                home.ClickAdminstration(CommonDriver.driver);
                home.ClickTimenMaterial(CommonDriver.driver);

                TimenMaterialPage tmPage = new TimenMaterialPage();
                tmPage.clickCreateNewBtn(CommonDriver.driver);
                tmPage.enterValidInfonSave(CommonDriver.driver);
                tmPage.ValidateTM(CommonDriver.driver);

            }

            [Test]
            public void Edit()
            {
                HomePage home = new HomePage();
                home.ClickAdminstration(CommonDriver.driver);
                home.ClickTimenMaterial(CommonDriver.driver);

                Edit editPage = new Edit();
                editPage.Editing(CommonDriver.driver);
                editPage.VerifyEdited(CommonDriver.driver);
            }

            [Test]
            public void Delete()
            {
                HomePage home = new HomePage();
                home.ClickAdminstration(CommonDriver.driver);
                home.ClickTimenMaterial(CommonDriver.driver);

                Delete deletePage = new Delete();
                deletePage.Deleting(CommonDriver.driver);
                deletePage.VerifingIfDeleted(CommonDriver.driver);

            }
        }
    }
}