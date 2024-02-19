using NUnit.Framework;
using SpecFlowProject.Hooks;
using SpecFlowProject.Model;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions : CommonDriver
    {
        SignInSteps SignInStepsObj;
        HomePageSteps HomePageStepsObj;
        public SignInStepDefinitions()
        {
            SignInStepsObj = new SignInSteps();
            HomePageStepsObj = new HomePageSteps();
        }

        [Given(@"I sigin to the Mars portal successfully with valid credentials'([^']*)'")]
        public void GivenISiginToTheMarsPortalSuccessfullyWithValidCredentials(string credentials)
        {
            //------Sign in------
            try
            {
                List<UserInformation> userList = JsonReader.GetData<UserInformation>(credentials);
                SignInStepsObj.SignIn(userList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "Exception in Signin");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"User should be taken to his '([^']*)'home page successfully")]
        public void ThenUserShouldBeTakenToHisHomePageSuccessfully(string credentials)
        {
            //------ Verifying user is taken to his home page------
            try
            {
                List<UserInformation> userList = JsonReader.GetData<UserInformation>(credentials);
                HomePageStepsObj.ValidateFirstName(userList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "successful sign in");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "Exception in Signin");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Given(@"I am not taken to home page on sigin with invalid credentials'([^']*)'")]
        public void GivenIAmNotTakenToHomePageOnSiginWithInvalidCredentials(string credentials)
        {
            //------Sign in with invalid credentials------
            try
            {
                List<UserInformation> userList = JsonReader.GetData<UserInformation>(credentials);
                foreach (var user in userList)
                {
                    SignInStepsObj.SignIn(user);
                    HomePageStepsObj.ValidateNotSignedIn(user);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignInInvalid"), "successful sign in invalid");
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignInValid"), "Exception in Signin invalid");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }
    }
}
