using SpecFlowProject.Model;
using SpecFlowProject.Pages;
using NUnit.Framework;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages.Components.ShareSkillOverview;
using SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview;

namespace SpecFlowProject.Steps
{
    public class HomePageSteps
    {
        HomePage HomePageComponentObj;
        ProfileOverviewComponents ProfileOverviewComponentsObj;
        ShareSkillComponent ShareSkillComponentObj;
        ProfileMenuTabOverviewComponent ProfileMenuTabOverviewComponentObj;
        public HomePageSteps()
        {
            HomePageComponentObj = new HomePage();
            ProfileOverviewComponentsObj = HomePageComponentObj.GetProfileOverviewComponents();
            ShareSkillComponentObj = HomePageComponentObj.GetShareSkillComponent();
            ProfileMenuTabOverviewComponentObj = HomePageComponentObj.GetProfileMenuTabOverviewComponent();
        }
        public void ValidateFirstName(UserInformation user)
        {
            //--------Validate first name--------
            try
            {
                //Verify if user is taken to their home page upon login in to Mars 
                string actualUserName = HomePageComponentObj.GetFirstName();
                Assert.IsTrue(actualUserName.StartsWith("Hi"), "User not logged in successfully !!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateNotSignedIn(UserInformation user)
        {
            //Validate user is not signed in--------
            try
            {
                //Verify if user is not taken to their home page upon login into Mars with invalid credentials
                string actualUserName = HomePageComponentObj.GetFirstName();
                Assert.IsFalse(actualUserName.StartsWith("Hi"), "user is able to log in");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
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
            ////--------Click sent requests tab--------
            ProfileMenuTabOverviewComponentObj.ClickSentRequestsTab();
        }
    }
}