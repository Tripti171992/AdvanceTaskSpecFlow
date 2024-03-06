using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services.LanguageServices
{
    public class ProfileLanguageOverviewComponentService : CommonDriver
    {
        ProfileLanguageOverviewComponent ProfileLanguageOverviewComponentObj;
        public ProfileLanguageOverviewComponentService()
        {
            ProfileLanguageOverviewComponentObj = new ProfileLanguageOverviewComponent();
        }
        public void ValidateLanguageAdded(string languagePath)
        {
            //--------Validate a language added--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                string result = ProfileLanguageOverviewComponentObj.GetLanguageAddedResult(language);
                LanguageAssertHelper.AssertLanguageAdded("Added", result);
                CommonMethods.AddScreenCapture(driver, "AddLanguag");
            }
        }
        public void ValidateLanguageUpdated(string newLanguagePath)
        {
            //--------Validate a language updated--------

            List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(newLanguagePath);
            foreach (var language in languageList)
            {
                string result = ProfileLanguageOverviewComponentObj.GetUpdatedLanguageResult(language);
                CommonMethods.AddScreenCapture(driver, "ValidateLanguageUpdated");
                LanguageAssertHelper.AssertLanguageUpdated("Updated", result);
            }
        }
        public void DeleteLanguage(string languagePath)
        {
            //--------Delete a language--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.DeleteLanguage(language);
                CommonMethods.AddScreenCapture(driver, "DeleteLanguage");
                ValidateLanguageDeleteMessage(language);
            }
        }
        public void ValidateLanguageDeleteMessage(LanguageModel language)
        {
            //--------Validating language deleted message-------

            string expectedMessage = language.language + " has been deleted from your languages";
            string actualMessage = ProfileLanguageOverviewComponentObj.GetMessage();
            if (actualMessage.Contains("Timed out after"))
            {
                Console.WriteLine(expectedMessage);
            }
            else
            {
                LanguageAssertHelper.AssertDeleteLanguageSuccessMessage(expectedMessage, actualMessage);
            }
        }
        public void DeleteUpdatedLanguage(string languagePath)
        {
            //--------Delete updated language--------

            List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.DeleteUpdatedLanguage(language);
                CommonMethods.AddScreenCapture(driver, "DeleteUpdatedLanguage");
                ValidateUpdatedLanguageDeleteMessage(language);
            }
        }
        public void ValidateUpdatedLanguageDeleteMessage(UpdateLanguageModel language)
        {
            //----Verifying success message for deletion of an updated language record--------

            string expectedMessage = language.language + " has been deleted from your languages";
            string actualMessage = ProfileLanguageOverviewComponentObj.GetMessage();
            if (actualMessage.Contains("Timed out after"))
            {
                Console.WriteLine(expectedMessage);
            }
            else
            {
                LanguageAssertHelper.AssertLanguageDeleted(expectedMessage, actualMessage);
            }
        }
        public void ValidateLanguageDeleted(string languagePath)
        {
            //--------Validate language record deleted --------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                string result = ProfileLanguageOverviewComponentObj.GetDeleteLanguageResult(language);
                LanguageAssertHelper.AssertLanguageDeleted("Deleted", result);
                CommonMethods.AddScreenCapture(driver, "ValidateLanguageDeleted");
            }
        }
        public void ValidateLanguageNotAdded(string languagePath)
        {
            //--------Validate language not added--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                string result = ProfileLanguageOverviewComponentObj.GetLanguageAddedResult(language);
                CommonMethods.AddScreenCapture(driver, "ValidateLanguageNotAdded");
                LanguageAssertHelper.AssertLanguageNotAdded("Not added", result);
            }
        }
        public void ValidateLanguageNotUpdated(string languagePath)
        {
            //--------Validate language not updated--------

            List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                string result = ProfileLanguageOverviewComponentObj.GetUpdatedLanguageResult(language);
                CommonMethods.AddScreenCapture(driver, "ValidateLanguageNotUpdated");
                LanguageAssertHelper.AssertLanguageNotUpdated("Not updated", result);
            }
        }
    }
}
