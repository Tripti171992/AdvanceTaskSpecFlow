using SpecFlowProject.Services;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions : CommonDriver
    {
        SignInService SignInServiceObj;
        HomePageService HomePageServiceObj;
        public SignInStepDefinitions()
        {
            SignInServiceObj = new SignInService();
            HomePageServiceObj = new HomePageService();
        }

        [Given(@"I sigin to the Mars portal successfully with valid credentials'([^']*)'")]
        public void GivenISiginToTheMarsPortalSuccessfullyWithValidCredentials(string credentialsPath)
        {
            //------Sign in------

            SignInServiceObj.SignIn(credentialsPath);
        }

        [Then(@"User should be taken to his '([^']*)'home page successfully")]
        public void ThenUserShouldBeTakenToHisHomePageSuccessfully(string credentialsPath)
        {
            //------ Verifying user is taken to his home page------

            HomePageServiceObj.ValidateFirstName(credentialsPath);
        }

        [Given(@"I am not taken to home page on sigin with invalid credentials'([^']*)'")]
        public void GivenIAmNotTakenToHomePageOnSiginWithInvalidCredentials(string credentialsPath)
        {
            //------Sign in with invalid credentials------

            SignInServiceObj.SignInInvalid(credentialsPath);
        }
    }
}
