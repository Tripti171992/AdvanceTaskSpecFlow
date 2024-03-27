using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.SignInOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.Model;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services
{
    public class SignInService : CommonDriver
    {
        SplashPage SplashPageComponentObj;
        SignInComponent SigninComponentObj;
        HomePage HomePageComponentObj;
        public SignInService()
        {
            SplashPageComponentObj = new SplashPage();
            SigninComponentObj = new SignInComponent();
            HomePageComponentObj = new HomePage();
        }

        public void SignIn(string credentialsPath)
        {
            //------Sign in------

            List<UserInformation> credentialsList = JsonReader.GetData<UserInformation>(credentialsPath);
            SplashPageComponentObj.ClickSignInButton();
            SigninComponentObj.SignIn(credentialsList[0]);
        }
        public void SignInInvalid(string credentialsPath)
        {
            //------Sign in invalid------

            List<UserInformation> credentialsList = JsonReader.GetData<UserInformation>(credentialsPath);
            foreach (var credentials in credentialsList)
            {
                SplashPageComponentObj.ClickSignInButton();
                SigninComponentObj.SignIn(credentials);
                ValidateNotSignedIn(credentials);
            }
        }
        public void ValidateNotSignedIn(UserInformation credentials)
        {
            //--Validate user is not signed in--------

            string actualUserName = HomePageComponentObj.GetFirstName();
            string expectedUserName = "Hi " + credentials.firstName;
            SignInAssertHelper.AssertSignUnsuccessful(expectedUserName, actualUserName);
            CommonMethods.AddScreenCapture(driver, "SignInInvalid");
            Refresh();
        }
    }
}
