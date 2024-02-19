using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview
{
    public class ProfileMenuTabOverviewComponent : CommonDriver
    {
        private IWebElement dashboardTab;
        private IWebElement profileTab;
        private IWebElement manageListingsTab;
        private IWebElement receivedRequestsTab;
        private IWebElement sentRequestsTab;
        public void RenderComponents()
        {
            //------Render component------
            try
            {
                dashboardTab = driver.FindElement(By.XPath("//a[text()='Dashboard']"));
                profileTab = driver.FindElement(By.XPath("//a[text()='Profile']"));
                manageListingsTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
                receivedRequestsTab = driver.FindElement(By.XPath("//a[text()='Received Requests']"));
                sentRequestsTab = driver.FindElement(By.XPath("//a[text()='Sent Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickDashboardTab()
        {
            //------Click dashboard tab------
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Dashboard']", 5);
            RenderComponents();
            dashboardTab.Click();
        }
        public void ClickProfileTab()
        {
            //------Click profile tab------
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Profile']", 5);
            RenderComponents();
            profileTab.Click();
        }
        public void ClickManageListingsTab()
        {
            //------Click manage listings tab------
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Manage Listings']", 5);
            RenderComponents();
            manageListingsTab.Click();
        }
        public void ClickReceivedRequestsTab()
        {
            //------Click received requests tab------
            Wait.WaitToBeClickable(driver, "XPath", "/a[text()='Received Requests']", 5);
            RenderComponents();
            receivedRequestsTab.Click();
        }
        public void ClickSentRequestsTab()
        {
            //------Click sent requests tab------
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Sent Requests']", 5);
            RenderComponents();
            sentRequestsTab.Click();
        }
    }
}
