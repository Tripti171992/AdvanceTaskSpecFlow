using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages.Components.SkillDetails
{
    public class SkillDetailsComponent : CommonDriver
    {
        private IWebElement skillTitle;
        private IWebElement skillDescription;
        private IWebElement skillCategory;
        private IWebElement skillSubcategory;
        private IWebElement skillServiceType;
        private IWebElement skillStartDate;
        private IWebElement skillEndDate;
        private IWebElement skillsTrade;
        private IWebElement skillLocationType;

        public void RenderComponents()
        {
            //--------Render component--------

            skillTitle = driver.FindElement(By.XPath("//h1/span"));
            skillDescription = driver.FindElement(By.XPath("//div[text()='Description']/following-sibling::div"));
            skillCategory = driver.FindElement(By.XPath("//div[text()='Category']/following-sibling::div"));
            skillSubcategory = driver.FindElement(By.XPath("//div[text()='Subcategory']/following-sibling::div"));
            skillServiceType = driver.FindElement(By.XPath("//div[text()='Service Type']/following-sibling::div"));
            skillStartDate = driver.FindElement(By.XPath("//div[text()='Start Date']/following-sibling::div"));
            skillEndDate = driver.FindElement(By.XPath("//div[text()='End Date']/following-sibling::div"));
            skillsTrade = driver.FindElement(By.XPath("//div[text()='Skills Trade']/following-sibling::div/span"));
            skillLocationType = driver.FindElement(By.XPath("//div[text()='Location Type']/following-sibling::div"));
        }
        public string GetSkillTitle()
        {
            //--------Get skill title--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillTitle.Text;
        }
        public string GetSkillDescription()
        {
            //--------Get skill description--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillDescription.Text;
        }
        public string GetSkillCategory()
        {
            //--------Get skill category--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillCategory.Text;
        }
        public string GetSkillSubcategory()
        {
            //--------Get skill sub category--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillSubcategory.Text;
        }
        public string GetSkillServiceType()
        {
            //--------Get skill service--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillServiceType.Text;
        }
        public string GetSkillStartDate()
        {
            //--------Get skill start date--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillStartDate.Text;
        }
        public string GetSkillEndDate()
        {
            //--------Get skill end date--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillEndDate.Text;
        }
        public string GetskillsTrade()
        {
            //--------Get skill trade--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillsTrade.Text;
        }
        public string GetSkillLocationType()
        {
            //--------Get skill location type--------
            Wait.WaitToBeClickable(driver, "XPath", "//h1/span", 5);
            RenderComponents();
            return skillLocationType.Text;
        }
    }
}
