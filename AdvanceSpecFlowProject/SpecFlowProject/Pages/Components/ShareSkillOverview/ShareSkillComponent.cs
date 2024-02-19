using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages.Components.ShareSkillOverview
{
    public class ShareSkillComponent : CommonDriver
    {
        private IWebElement ShareSkillButton;
        public void RenderComponents()
        {
            //--------Render component--------
            try
            {
                ShareSkillButton = driver.FindElement(By.XPath("//*[text()='Share Skill']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickShareSkillButton()
        {
            //--------Click on ShareSkill button--------

            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Share Skill']", 6);

            RenderComponents();

            ShareSkillButton.Click();
        }
    }
}
