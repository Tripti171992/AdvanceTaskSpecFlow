using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services.LanguageServices
{
    public class ActionOnLanguageComponentService : CommonDriver
    {
        ProfileLanguageOverviewComponent ProfileLanguageOverviewComponentObj;
        ActionOnLanguageComponent ActionOnLanguageComponentObj;

        public ActionOnLanguageComponentService()
        {
            ProfileLanguageOverviewComponentObj = new ProfileLanguageOverviewComponent();
            ActionOnLanguageComponentObj = new ActionOnLanguageComponent();
        }
        public void AddLanguage(string languagePath)
        {
            //--------Add language--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.AddLanguage(language);
                CommonMethods.AddScreenCapture(driver, "AddLanguage");
                ValidateLanguageAddedMessage(language);
            }
        }
        public void ValidateLanguageAddedMessage(LanguageModel language)
        {
            //--Verifying success message for addition of a language record----

            string expectedMessage = language.language + " has been added to your languages";
            string actualMessage = ActionOnLanguageComponentObj.GetMessage();
            LanguageAssertHelper.AssertLanguageAddedSuccessMessage(expectedMessage, actualMessage);
        }
        public void UpdateLanguage(string languagePath)
        {
            //--------Update language--------

            List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickUpdateIcon(language.oldLanguage);
                ActionOnLanguageComponentObj.UpdateLanguage(language);
                CommonMethods.AddScreenCapture(driver, "UpdateLanguage");
                ValidateLanguageUpdatedMessage(language);
            }
        }
        public void ValidateLanguageUpdatedMessage(UpdateLanguageModel language)
        {
            //--------Validate language updated message--------

            string expectedMessage = language.language + " has been updated to your languages";
            string actualMessage = ActionOnLanguageComponentObj.GetMessage();
            LanguageAssertHelper.AssertLanguageUpdatedMessage(expectedMessage, actualMessage);
        }
        public void CancelAddLanguage(string languagePath)
        {
            //--------Cancel adding a language--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.CancelLanguageAddition(language);
            }
        }
        public void AddDuplicateLanguage(string languagePath)
        {
            //--------Adding a duplicate language--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.AddLanguage(language);
                CommonMethods.AddScreenCapture(driver, "AddDuplicateLanguage");
                ValidateDuplicateLanguageErrorMessage();
            }
        }
        public void ValidateDuplicateLanguageErrorMessage()
        {
            //--------Validate error message for duplicate language addition-- 

            string expectedMessage = "This language is already exist in your language list.";
            string actualMessage = ActionOnLanguageComponentObj.GetMessage();
            LanguageAssertHelper.AssertDuplicateLanguageErrorMessage(expectedMessage, actualMessage);
        }
        public void AddInvalidLanguage(string languagePath)
        {
            //--------Adding an invalid language--------

            List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.AddLanguage(language);
                CommonMethods.AddScreenCapture(driver, "AddInvalidLanguage");
                ValidateInvalidLanguageErrorMessage();
            }
        }
        public void ValidateInvalidLanguageErrorMessage()
        {
            //----Verifying error message for invalid language record addition/updation------

            string expectedMessage = "Please enter language and level";
            string actualMessage = ActionOnLanguageComponentObj.GetMessage();
            LanguageAssertHelper.AssertInvalidLanguageErrorMessage(expectedMessage, actualMessage);
        }
        public void UpdateInvalidLanguage(string languagePath)
        {
            //--------Undating an invalid language--------

            List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickUpdateIcon(language.oldLanguage);
                ActionOnLanguageComponentObj.UpdateLanguage(language);
                CommonMethods.AddScreenCapture(driver, "UpdateInvalidLanguage");
                ValidateInvalidLanguageErrorMessage();
            }
        }
        public void CancelUpdateLanguage(string languagePath)
        {
            //--------Cancel updating a language--------

            List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>(languagePath);
            foreach (var language in languageList)
            {
                ProfileLanguageOverviewComponentObj.ClickUpdateIcon(language.oldLanguage);
                ActionOnLanguageComponentObj.CancelUpdateLanguage(language);
            }
        }
    }
}
