using SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages.Components.ShareSkillOverview;
using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    public class HomePage : CommonDriver
    {
        private IWebElement UserNameLable;
        private ProfileOverviewComponents ProfileOverviewComponentsObj;
        private ShareSkillComponent ShareSkillComponentObj;
        private ProfileMenuTabOverviewComponent ProfileMenuTabComponentObj;
        public HomePage()
        {
            ProfileOverviewComponentsObj = new ProfileOverviewComponents();
            ShareSkillComponentObj = new ShareSkillComponent();
            ProfileMenuTabComponentObj = new ProfileMenuTabOverviewComponent();
        }
        public void RenderComponents()
        {
            //--------Render component--------
            UserNameLable = driver.FindElement(By.XPath("//span[contains(@class,'item ui')]"));
        }
        public ProfileOverviewComponents GetProfileOverviewComponents()
        {
            //------Return ProfileOverviewComponents object--------
            return ProfileOverviewComponentsObj;
        }
        public ShareSkillComponent GetShareSkillComponent()
        {
            //------Return ShareSkillComponent object--------
            return ShareSkillComponentObj;
        }
        public ProfileMenuTabOverviewComponent GetProfileMenuTabOverviewComponent()
        {
            //----Return ProfileMenuTabOverviewComponent object--------
            return ProfileMenuTabComponentObj;
        }

        public string GetFirstName()
        {
            //--------Return username--------
            try
            {
                // Thread.Sleep(2000);
                Wait.WaitToExist(driver, "XPath", "//span[contains(@class,'item ui')]", 3);
                RenderComponents();
                return UserNameLable.Text;
            }
            catch (WebDriverTimeoutException ex)
            {
                return ex.Message;
            }
        }
    }
}