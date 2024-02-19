using NUnit.Framework;
using RazorEngine;
using SpecFlowProject.Hooks;
using SpecFlowProject.Model;
using SpecFlowProject.Steps;
using SpecFlowProject.Steps.LanguageSteps;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        ActionOnLanguageComponentSteps ActionOnLanguageStepsObj;
        ProfileLanguageOverviewComponentSteps ProfileLanguageOverviewStepsObj;

        public LanguageFeatureStepDefinitions()
        {
            ActionOnLanguageStepsObj = new ActionOnLanguageComponentSteps();
            ProfileLanguageOverviewStepsObj = new ProfileLanguageOverviewComponentSteps();
        }

        [When(@"I added a language '([^']*)'")]
        public void WhenIAddedALanguage(string userLanguage)
        {
            //-- Add language--
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(userLanguage);

                //Deleting language
                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                }
                //Adding language
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddLanguage"), "Add language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddLanguage"), "Exception in add language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A language '([^']*)' record should be added successfully")]
        public void ThenALanguageRecordShouldBeAddedSuccessfully(string userLanguage)
        {
            try
            {
                //------Validating language addition----------
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(userLanguage);

                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddLanguage"), "Add language validation");

                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.ValidateLanguageAdded(language);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddLanguage"), "Exception in add language validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I delete a language '([^']*)'")]
        public void WhenIDeleteALanguage(string userLanguage)
        {
            //-- Add Skill--------------------
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(userLanguage);

                //Adding langauge for deletion
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                }
                //Deleting langauge record 
                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Delete language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Exception in delete language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A language '([^']*)' record should be deleted successfully")]
        public void ThenALanguageRecordShouldBeDeletedSuccessfully(string userLanguage)
        {
            //------Validating language deletion----------
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(userLanguage);

                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Delete language validation");

                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.ValidateLanguageDeleted(language);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Exception in delete language validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I updated an old language '([^']*)' details to new language detail '([^']*)'")]
        public void WhenIUpdatedAnOldLanguageDetailsToNewLanguageDetail(string oldLanguagePath, string newLanguagePath)
        {
            //------Update a language------
            try
            {
                List<LanguageModel> oldLanguageList = JsonReader.GetData<LanguageModel>(oldLanguagePath);
                List<UpdateLanguageModel> newLanguageList = JsonReader.GetData<UpdateLanguageModel>(newLanguagePath);

                //Deleting language
                foreach (var language in oldLanguageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                }
                foreach (var language in newLanguageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteUpdatedLanguage(language);
                }

                //Adding langauge for updation
                foreach (var language in oldLanguageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                }
                //Updating langauge         
                foreach (var language in newLanguageList)
                {
                    ActionOnLanguageStepsObj.UpdateLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateLanguage"), "Update language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateLanguage"), "Exception in update language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A language '([^']*)' should get updated")]
        public void ThenALanguageShouldGetUpdated(string newLanguagePath)
        {
            //------Validating language updation----------
            try
            {
                List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(newLanguagePath);

                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateLanguage"), "Update language validation");

                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.ValidateLanguageUpdated(language);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateLanguage"), "Exception in update language validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I cancelled adding a language '([^']*)'")]
        public void WhenICancelledAddingALanguage(string languagePath)
        {
            //------Cancel adding a language------
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
                //Adding langauge to cancel
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.CancelAddLanguage(language);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelLanguageAddition"), "Exception in Cancel Add language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A duplicate language '([^']*)' should not get added")]
        public void ThenADuplicateLanguageShouldNotGetAdded(string languagePath)
        {
            //----Add duplicated language------
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);

                //Deleting language
                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                }
                //Adding language
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                }
                //Adding duplicate langauge
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddDuplicateLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDuplicateLanguage"), "Add duplicate language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDuplicateLanguage"), "Exception in add duplicate language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I add an invalid language '([^']*)'")]
        public void WhenIAddAnInvalidLanguage(string languagePath)
        {
            //------Adding an invalid language------
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
                //Adding invalid langauge record 
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddInvalidLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidLanguage"), "Add invalid language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidLanguage"), "Exception in add invalid language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A language '([^']*)' should not get added")]
        public void ThenALanguageShouldNotGetAdded(string languagePath)
        {
            //------Validating language not added------
            try
            {
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);

                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "LanguageNotAdded"), "Language not added successful");

                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotAdded(language);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "LanguageNotAdded"), "Exception in language not added validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I update an old language '([^']*)' details to new invalid language detail '([^']*)'")]
        public void WhenIUpdateAnOldLanguageDetailsToNewInvalidLanguageDetail(string oldLanguagePath, string newLanguagePath)
        {
            //------Update an invalid language------
            try
            {
                List<LanguageModel> oldLanguageList = JsonReader.GetData<LanguageModel>(oldLanguagePath);
                List<UpdateLanguageModel> newLanguageList = JsonReader.GetData<UpdateLanguageModel>(newLanguagePath);

                //Deleting language
                foreach (var language in oldLanguageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                }
                //Adding langauge for updation
                foreach (var language in oldLanguageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                }
                //Updating langauge         
                foreach (var language in newLanguageList)
                {
                    ActionOnLanguageStepsObj.UpdateInvalidLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidLanguage"), "Update invalid language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidLanguage"), "Exception in Update invalid language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I update an old language '([^']*)' details to new language detail '([^']*)'")]
        public void WhenIUpdateAnOldLanguageDetailsToNewLanguageDetail(string oldLanguagePath, string newLanguagePath)
        {
            //------Cancel updating a language------
            try
            {
                List<LanguageModel> oldLanguageList = JsonReader.GetData<LanguageModel>(oldLanguagePath);
                List<UpdateLanguageModel> newLanguageList = JsonReader.GetData<UpdateLanguageModel>(newLanguagePath);

                //Deleting language
                foreach (var language in oldLanguageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                }
                //Adding langauge for updation
                foreach (var language in oldLanguageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                }
                //Updating langauge         
                foreach (var language in newLanguageList)
                {
                    ActionOnLanguageStepsObj.CancelUpdateLanguage(language);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelUpdateLanguage"), "Cancel update language successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelUpdateLanguage"), "Exception in cancel update invalid language");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A language '([^']*)' should not get updated")]
        public void ThenALanguageShouldNotGetUpdated(string newLanguagePath)
        {
            //------Validating invalid language updation----------
            try
            {
                List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(newLanguagePath);

                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "LanguageNotUpdated"), "Language not updated validation");

                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotUpdated(language);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "LanguageNotUpdated"), "Exception in language not updated validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

    }
}
