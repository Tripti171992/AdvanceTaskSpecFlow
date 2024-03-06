using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;
using MarsAdvanceTaskNUnit.Services;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions : CommonDriver
    {
        RegistrationService RegistrationServiceObj;
        public RegistrationStepDefinitions()
        {
            RegistrationServiceObj = new RegistrationService();
        }

        [Given(@"I registered into the Mars portal with existing credentials '([^']*)'")]
        public void GivenIRegisteredIntoTheMarsPortalWithExistingCredentials(string credentialsPath)
        {
            //------Registration with existing credentials------

            RegistrationServiceObj.RegistrationWithExistingCredentials(credentialsPath);
        }

        [Then(@"A user should not be registered successfully")]
        public void ThenAUserShouldNotBeRegisteredSuccessfully()
        {
            //------ Verifying user is not registered------

            RegistrationServiceObj.ValidateRegistrationInvalid();
        }

        [Given(@"I am not able to register into the Mars portal with invalid credentials '([^']*)'")]
        public void GivenIAmNotAbleToRegisterIntoTheMarsPortalWithInvalidCredentials(string credentialsPath)
        {
            //------Registration with invalid credentials------

            RegistrationServiceObj.RegistrationInvalid(credentialsPath);
        }
    }
}
