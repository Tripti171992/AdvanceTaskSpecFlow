using SpecFlowProject.Model;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.RegistrationOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace MarsAdvanceTaskNUnit.Services
{
    public class RegistrationService : CommonDriver
    {
        SplashPage SplashPageComponentObj;
        RegistrationComponent RegistrationComponentObj;
        public RegistrationService()
        {
            SplashPageComponentObj = new SplashPage();
            RegistrationComponentObj = new RegistrationComponent();
        }

        public void RegistrationWithExistingCredentials(string credentialsPath)
        {
            //------Registration With Existing Credentials------

            List<RegistrationModel> credentialsList = JsonReader.GetData<RegistrationModel>(credentialsPath);
            SplashPageComponentObj.ClickJoinButton();
            RegistrationComponentObj.RegistrationInvalid(credentialsList[0]);
        }
        public void RegistrationInvalid(string credentialsPath)
        {
            //------Registration With Invalid CredentialsInvalid registration------

            List<RegistrationModel> credentialsList = JsonReader.GetData<RegistrationModel>(credentialsPath);
            foreach (var credentials in credentialsList)
            {
                SplashPageComponentObj.ClickJoinButton();
                RegistrationComponentObj.RegistrationInvalid(credentials);
                ValidateRegistrationInvalid();
                Refresh();
            }
        }
        public void ValidateRegistrationInvalid()
        {
            //------Validate invalid registration------

            string message = RegistrationComponentObj.GetRegistrationMessage();
            RegistrationAssertHelper.AssertRegisterUnsuccessful("Registration successful", message);
            CommonMethods.AddScreenCapture(driver, "RegistrationWithExistOrInvalidCred");
        }
    }
}
