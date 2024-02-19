using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Utilities;
using NUnit.Framework;

namespace SpecFlowProject.Steps.LanguageSteps
{
    public class ActionOnLanguageComponentSteps
    {
        ProfileLanguageOverviewComponent ProfileLanguageOverviewComponentObj;
        ActionOnLanguageComponent ActionOnLanguageComponentObj;

        public ActionOnLanguageComponentSteps()
        {
            ProfileLanguageOverviewComponentObj = new ProfileLanguageOverviewComponent();
            ActionOnLanguageComponentObj = new ActionOnLanguageComponent();
        }
        public void AddLanguage(LanguageModel language)
        {
            //--------Add language--------
            try
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.AddLanguage(language);
                ValidateLanguageAddedMessage(language);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateLanguageAddedMessage(LanguageModel language)
        {
            //--------Add language--------
            try
            {
                //Verifying success message for addition of a language record
                string expectedMessage = language.language + " has been added to your languages";
                string acutalMessage = ActionOnLanguageComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, acutalMessage, "Actual and expected message do not match. Language not added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void UpdateLanguage(UpdateLanguageModel language)
        {
            //--------Update language--------
            try
            {
                ProfileLanguageOverviewComponentObj.ClickUpdateIcon(language.oldLanguage);
                ActionOnLanguageComponentObj.UpdateLanguage(language);

                //Verifying success message for updation of a language record
                string expectedMessage = language.language + " has been updated to your languages";
                string actualMessage = ActionOnLanguageComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message match. Language not updated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void CancelAddLanguage(LanguageModel language)
        {
            //--------Cancel adding a language--------
            try
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.CancelLanguageAddition(language);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void AddDuplicateLanguage(LanguageModel language)
        {
            //--------Adding a duplicate language--------
            try
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.AddLanguage(language);

                //Verifying an error message for duplicate language updation displayed
                string expectedMessage = "This language is already exist in your language list.";
                string actualMessage = ActionOnLanguageComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match.Duplicate language record added!!");

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void AddInvalidLanguage(LanguageModel language)
        {
            //--------Adding an invalid language--------
            try
            {
                ProfileLanguageOverviewComponentObj.ClickAddLanguageButton();
                ActionOnLanguageComponentObj.AddLanguage(language);

                //Verifying error message for invalid language record addition
                string expectedMessage = "Please enter language and level";
                string actualMessage = ActionOnLanguageComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Language record added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void UpdateInvalidLanguage(UpdateLanguageModel language)
        {
            try
            {
                //--------Undating an invalid language--------
                ProfileLanguageOverviewComponentObj.ClickUpdateIcon(language.oldLanguage);
                ActionOnLanguageComponentObj.UpdateLanguage(language);

                //Verifying error message for invalid language updation in a record
                string expectedMessage = "Please enter language and level";
                string actualMessage = ActionOnLanguageComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match.Language not updated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void CancelUpdateLanguage(UpdateLanguageModel language)
        {
            try
            {
                //--------Cancel updating a language--------
                ProfileLanguageOverviewComponentObj.ClickUpdateIcon(language.oldLanguage);
                ActionOnLanguageComponentObj.CancelUpdateLanguage(language);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
