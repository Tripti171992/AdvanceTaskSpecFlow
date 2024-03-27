using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages.Components.DescriptionOverview
{
    public class DescriptionOverviewComponent : CommonDriver
    {
        private IWebElement descriptionWriteIcon;
        private IWebElement savedDescription;
        public void RenderComponents()
        {
            //------Render component------

            descriptionWriteIcon = driver.FindElement(By.XPath("//*[text()='Description']//i"));
            savedDescription = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        }
        public void ClickDescriptionWriteIcon()
        {
            //------Click on WriteIcon button------

            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Description']//i", 6);
            RenderComponents();
            descriptionWriteIcon.Click();
        }
        public string GetAddedUpdatedDescription()
        {
            //------Return new added/Updated description------

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span", 4);
            RenderComponents();
            return savedDescription.Text;

        }
    }
}
