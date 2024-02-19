using SpecFlowProject.Hooks;
using SpecFlowProject.Model;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;
using MarsAdvanceTaskNUnit.Steps;
using NUnit.Framework;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions : CommonDriver
    {
        RegistrationSteps RegistrationStepsObj;
        public RegistrationStepDefinitions()
        {
            RegistrationStepsObj = new RegistrationSteps();
        }

        [Given(@"I registered into the Mars portal with existing credentials '([^']*)'")]
        public void GivenIRegisteredIntoTheMarsPortalWithExistingCredentials(string credentials)
        {
            //------Registration with existing credentials------
            try
            {
                List<RegistrationModel> userList = JsonReader.GetData<RegistrationModel>(credentials);

                RegistrationStepsObj.RegistrationInvalid(userList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationWithExistCred"), "Registration with existing credentials successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationWithExistCred"), "Exception in Registration with existing credentials");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A user should not be registered successfully")]
        public void ThenAUserShouldNotBeRegisteredSuccessfully()
        {
            //------ Verifying user is not registered------
            try
            {
                RegistrationStepsObj.ValidateRegistrationInvalid();
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationWithExistCred"), "Exception in registration with existing credentials");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Given(@"I am not able to register into the Mars portal with invalid credentials '([^']*)'")]
        public void GivenIAmNotAbleToRegisterIntoTheMarsPortalWithInvalidCredentials(string credentials)
        {
            //------Registration with invalid credentials------
            try
            {
                List<RegistrationModel> userList = JsonReader.GetData<RegistrationModel>(credentials);
                foreach (var user in userList)
                {
                    RegistrationStepsObj.RegistrationInvalid(user);
                    RegistrationStepsObj.ValidateRegistrationInvalid();
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationInvalid"), "Registration sign in invalid ");
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationInvalid"), "Exception in registration with invalid credentials");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }
    }
}
