using ClassLibrary6.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ClassLibrary6.HookUp
{
    [Binding]
    public class TimeMaterialSteps
    {
        [Given(@"I have logged into TurnUp portal")]
        public void GivenIHaveLoggedIntoTurnUpPortal()
        {

            LoginPage loginPage = new LoginPage();
            loginPage.LoginSuccess(CommonDriver.driver);
        }

        [Given(@"I have navigated to Time and Materal Page")]
        public void GivenIHaveNavigatedToTimeAndMateralPage()
        {
            HomePage home = new HomePage();
            home.ClickAdminstration(CommonDriver.driver);
            home.ClickTimenMaterial(CommonDriver.driver);


        }
        [Then(@"I should be able create a Time and Material Record, and it gets saved successfully\.")]
        public void ThenIShouldBeAbleCreateATimeAndMaterialRecordAndItGetsSavedSuccessfully_()
        {
            TimenMaterialPage tmPage = new TimenMaterialPage();
            tmPage.clickCreateNewBtn(CommonDriver.driver);
            tmPage.enterValidInfonSave(CommonDriver.driver);
            tmPage.ValidateTM(CommonDriver.driver);
        }


        [Then(@"I should be able Edit a Time and Material Record, and data gets updated successfully\.")]
        public void ThenIShouldBeAbleEditATimeAndMaterialRecordAndDataGetsUpdatedSuccessfully_()
        {
            //  HomePage home = new HomePage(driver);
            // home.ClickAdminstration();
            //home.ClickTimenMaterial();

            Edit editPage = new Edit();
            editPage.Editing(CommonDriver.driver);
            editPage.VerifyEdited(CommonDriver.driver);
        }

        [Then(@"I should be able Delete a Time and Material Record, and it gets deleted successfully\.")]
        public void ThenIShouldBeAbleDeleteATimeAndMaterialRecordAndItGetsDeletedSuccessfully_()
        {
            // HomePage home = new HomePage(driver);
            //home.ClickAdminstration();
            //home.ClickTimenMaterial();

            Delete deletePage = new Delete();
            deletePage.Deleting(CommonDriver.driver);
            deletePage.VerifingIfDeleted(CommonDriver.driver);
        }
    }
}
