using SpecFlowProject.Model;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages.Components.ShareSkillOverview;
using SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services
{
    public class HomePageService : CommonDriver
    {
        HomePage HomePageComponentObj;
        ProfileOverviewComponents ProfileOverviewComponentsObj;
        ShareSkillComponent ShareSkillComponentObj;
        ProfileMenuTabOverviewComponent ProfileMenuTabOverviewComponentObj;
        public HomePageService()
        {
            HomePageComponentObj = new HomePage();
            ProfileOverviewComponentsObj = HomePageComponentObj.GetProfileOverviewComponents();
            ShareSkillComponentObj = HomePageComponentObj.GetShareSkillComponent();
            ProfileMenuTabOverviewComponentObj = HomePageComponentObj.GetProfileMenuTabOverviewComponent();
        }
        public void ValidateFirstName(string credentialsPath)
        {
            //--------Validate first name--------

            List<UserInformation> credentialsList = JsonReader.GetData<UserInformation>(credentialsPath);
            string actualUserName = HomePageComponentObj.GetFirstName();
            string expectedUserName = "Hi " + credentialsList[0].firstName;
            SignInAssertHelper.AssertSignInSuccessful(expectedUserName, actualUserName);
            CommonMethods.AddScreenCapture(driver, "SignIn");
        }
        public void ClickOnCertificationTab()
        {
            //--------Click certification tab--------
            ProfileOverviewComponentsObj.ClickCertificationTab();
        }

        public void ClickOnEducationTab()
        {
            //--------Click education tab--------
            ProfileOverviewComponentsObj.ClickEducationTab();
        }

        public void ClickOnLangaugesTab()
        {
            //--------Click languages tab--------
            ProfileOverviewComponentsObj.ClickLangaugesTab();
        }

        public void ClickOnSkillsTab()
        {
            //--------Click Skills tab--------
            ProfileOverviewComponentsObj.ClickSkillsTab();
        }
        public void ClickShareSkillButton()
        {
            //--------Click Share skill button--------
            ShareSkillComponentObj.ClickShareSkillButton();
        }
        public void ClickDashboardTab()
        {
            //--------Click dashboard tab--------
            ProfileMenuTabOverviewComponentObj.ClickDashboardTab();
        }
        public void ClickProfileTab()
        {
            //--------Click Profile tab--------
            ProfileMenuTabOverviewComponentObj.ClickProfileTab();
        }
        public void ClickManageListingsTab()
        {
            //--------Click manage listings tab--------
            ProfileMenuTabOverviewComponentObj.ClickManageListingsTab();
        }
        public void ClickReceivedRequestsTab()
        {
            //--------Click received requests tab--------
            ProfileMenuTabOverviewComponentObj.ClickReceivedRequestsTab();
        }
        public void ClickSentRequestsTab()
        {
            //--------Click sent requests tab--------
            ProfileMenuTabOverviewComponentObj.ClickSentRequestsTab();
        }
    }
}