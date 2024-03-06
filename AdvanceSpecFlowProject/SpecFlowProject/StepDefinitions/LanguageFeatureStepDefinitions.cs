using SpecFlowProject.Services.LanguageServices;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions
    {
        ActionOnLanguageComponentService ActionOnLanguageServiceObj;
        ProfileLanguageOverviewComponentService ProfileLanguageOverviewServiceObj;

        public LanguageFeatureStepDefinitions()
        {
            ActionOnLanguageServiceObj = new ActionOnLanguageComponentService();
            ProfileLanguageOverviewServiceObj = new ProfileLanguageOverviewComponentService();
        }

        [When(@"I added a language '([^']*)'")]
        public void WhenIAddedALanguage(string languagePath)
        {
            //-- Add language----------

            ProfileLanguageOverviewServiceObj.DeleteLanguage(languagePath);
            ActionOnLanguageServiceObj.AddLanguage(languagePath);
        }

        [Then(@"A language '([^']*)' record should be added successfully")]
        public void ThenALanguageRecordShouldBeAddedSuccessfully(string languagePath)
        {
            //------Validating language addition----------

            ProfileLanguageOverviewServiceObj.ValidateLanguageAdded(languagePath);
        }

        [When(@"I delete a language '([^']*)'")]
        public void WhenIDeleteALanguage(string languagePath)
        {
            //-- Delete language--------------------

            ActionOnLanguageServiceObj.AddLanguage(languagePath);
            ProfileLanguageOverviewServiceObj.DeleteLanguage(languagePath);
        }

        [Then(@"A language '([^']*)' record should be deleted successfully")]
        public void ThenALanguageRecordShouldBeDeletedSuccessfully(string languagePath)
        {
            //------Validating language deletion----------

            ProfileLanguageOverviewServiceObj.ValidateLanguageDeleted(languagePath);
        }

        [When(@"I updated an old language '([^']*)' details to new language detail '([^']*)'")]
        public void WhenIUpdatedAnOldLanguageDetailsToNewLanguageDetail(string oldLanguagePath, string newLanguagePath)
        {
            //------Update a language------

            ProfileLanguageOverviewServiceObj.DeleteLanguage(oldLanguagePath);
            ProfileLanguageOverviewServiceObj.DeleteUpdatedLanguage(newLanguagePath);
            ActionOnLanguageServiceObj.AddLanguage(oldLanguagePath);
            ActionOnLanguageServiceObj.UpdateLanguage(newLanguagePath);
        }

        [Then(@"A language '([^']*)' should get updated")]
        public void ThenALanguageShouldGetUpdated(string newLanguagePath)
        {
            //------Validating language updation----------

            ProfileLanguageOverviewServiceObj.ValidateLanguageUpdated(newLanguagePath);
        }

        [When(@"I cancelled adding a language '([^']*)'")]
        public void WhenICancelledAddingALanguage(string languagePath)
        {
            //------Cancel adding a language------

            ActionOnLanguageServiceObj.CancelAddLanguage(languagePath);
        }

        [Then(@"A language '([^']*)' should not get added")]
        public void ThenALanguageShouldNotGetAdded(string languagePath)
        {
            //------Validating language not added------

            ProfileLanguageOverviewServiceObj.ValidateLanguageNotAdded(languagePath);
        }

        [Then(@"A duplicate language '([^']*)' should not get added")]
        public void ThenADuplicateLanguageShouldNotGetAdded(string languagePath)
        {
            //----Validating duplicate language not added------

            ProfileLanguageOverviewServiceObj.DeleteLanguage(languagePath);
            ActionOnLanguageServiceObj.AddLanguage(languagePath);
            ActionOnLanguageServiceObj.AddDuplicateLanguage(languagePath);
        }

        [When(@"I add an invalid language '([^']*)'")]
        public void WhenIAddAnInvalidLanguage(string languagePath)
        {
            //------Adding invalid language------

            ActionOnLanguageServiceObj.AddInvalidLanguage(languagePath);
        }

        [When(@"I update an old language '([^']*)' details to new invalid language detail '([^']*)'")]
        public void WhenIUpdateAnOldLanguageDetailsToNewInvalidLanguageDetail(string oldLanguagePath, string newLanguagePath)
        {
            //------Update an invalid language------

            ProfileLanguageOverviewServiceObj.DeleteLanguage(oldLanguagePath);
            ActionOnLanguageServiceObj.AddLanguage(oldLanguagePath);
            ActionOnLanguageServiceObj.UpdateInvalidLanguage(newLanguagePath);
        }

        [Then(@"A language '([^']*)' should not get updated")]
        public void ThenALanguageShouldNotGetUpdated(string newLanguagePath)
        {
            //------Validating language not updation----------

            ProfileLanguageOverviewServiceObj.ValidateLanguageNotUpdated(newLanguagePath);
        }

        [When(@"I cancel update an old language '([^']*)' details to new language detail '([^']*)'")]
        public void WhenICancelUpdateAnOldLanguageDetailsToNewLanguageDetail(string oldLanguagePath, string newLanguagePath)
        {
            //------Cancel updating a language------

            ProfileLanguageOverviewServiceObj.DeleteLanguage(oldLanguagePath);
            ActionOnLanguageServiceObj.AddLanguage(oldLanguagePath);
            ActionOnLanguageServiceObj.CancelUpdateLanguage(newLanguagePath);
        }
    }
}

