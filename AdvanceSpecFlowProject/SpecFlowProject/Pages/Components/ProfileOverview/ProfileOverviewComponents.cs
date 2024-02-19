using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages.Components.ProfileOverview
{
    public class ProfileOverviewComponents : CommonDriver
    {
        private IWebElement languagesTab;
        private IWebElement skillsTab;
        private IWebElement educationTab;
        private IWebElement certificationsTab;
        public void RenderComponents()
        {
            //------Render component------
            try
            {
                languagesTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                educationTab = driver.FindElement(By.XPath("//a[text()='Education']"));
                certificationsTab = driver.FindElement(By.XPath("//a[text()='Certifications']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickCertificationTab()
        {
            //------Click certification tab------
            Wait.WaitToBeClickable(driver, "XPath", "//h3[text()='Certification']", 5);
            RenderComponents();
            certificationsTab.Click();
        }

        public void ClickLangaugesTab()
        {
            //------Click languages tab------
            Wait.WaitToBeClickable(driver, "XPath", "//h3[text()='Languages']", 5);
            RenderComponents();
            languagesTab.Click();
        }

        public void ClickEducationTab()
        {
            //------Click education tab------
            Wait.WaitToBeClickable(driver, "XPath", "//h3[text()='Education']", 5);
            RenderComponents();
            educationTab.Click();
        }

        public void ClickSkillsTab()
        {
            //------Click skills tab------
            Wait.WaitToBeClickable(driver, "XPath", "//h3[text()='Skills']", 5);
            RenderComponents();
            skillsTab.Click();
        }
    }
}
