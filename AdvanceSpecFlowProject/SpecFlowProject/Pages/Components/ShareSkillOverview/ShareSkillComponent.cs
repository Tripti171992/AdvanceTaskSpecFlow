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
            ShareSkillButton = driver.FindElement(By.XPath("//*[text()='Share Skill']"));
        }
        public void ClickShareSkillButton()
        {
            //--------Click on ShareSkill button--------
            Thread.Sleep(1300);
            RenderComponents();
            ShareSkillButton.Click();
        }
    }
}
