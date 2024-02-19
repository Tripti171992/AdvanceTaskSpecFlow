using SpecFlowProject.Model;
using SpecFlowProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject.Pages.Components.ShareSkillOverview
{
    public class AddShareSkillComponent : CommonDriver
    {
        private IWebElement title;
        private IWebElement description;
        private IWebElement categoryDropDown;
        private IWebElement subCategoryDropDown;
        private IWebElement tags;
        private IWebElement hourlyBasisService;
        private IWebElement oneOffService;
        private IWebElement onSiteLocationType;
        private IWebElement onLineLocationType;
        private IWebElement startDate;
        private IWebElement endDate;
        private IReadOnlyCollection<IWebElement> checkBoxes;
        private IWebElement skillExchangeSkillTrade;
        private IWebElement creditSkillTrade;
        private IWebElement skillExchange;
        private IWebElement activeRadioButton;
        private IWebElement hiddenRadioButton;
        private IWebElement saveButton;
        private IWebElement cancelButton;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;
        private IWebElement creditTextBox;
        private IWebElement validationMessage;
        public void RenderComponents()
        {
            //--Render component------
            try
            {
                title = driver.FindElement(By.XPath("//input[@name='title']"));
                description = driver.FindElement(By.XPath("//textarea[@name='description']"));
                categoryDropDown = driver.FindElement(By.XPath("//select[@name='categoryId']"));
                tags = driver.FindElement(By.XPath("(//input[@class='ReactTags__tagInputField'])[1]"));
                hourlyBasisService = driver.FindElement(By.XPath("(//input[@name='serviceType'])[1]"));
                oneOffService = driver.FindElement(By.XPath("(//input[@name='serviceType'])[2]"));
                onSiteLocationType = driver.FindElement(By.XPath("(//input[@name='locationType'])[1]"));
                onLineLocationType = driver.FindElement(By.XPath("(//input[@name='locationType'])[2]"));
                startDate = driver.FindElement(By.XPath("//input[@name='startDate']"));
                endDate = driver.FindElement(By.XPath("//input[@name='endDate']"));
                checkBoxes = driver.FindElements(By.XPath("//div[@class='ui checkbox']"));
                skillExchangeSkillTrade = driver.FindElement(By.XPath("(//input[@name='skillTrades'])[1]"));
                creditSkillTrade = driver.FindElement(By.XPath("(//input[@name='skillTrades'])[2]"));
                skillExchange = driver.FindElement(By.XPath("(//input[@placeholder='Add new tag'])[2]"));
                activeRadioButton = driver.FindElement(By.XPath("(//input[@name='isActive'])[1]"));
                hiddenRadioButton = driver.FindElement(By.XPath("(//input[@name='isActive'])[2]"));
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
                cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderSubCategoryComponents()
        {
            //------Render sub category component------
            try
            {
                subCategoryDropDown = driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderCreditTextBoxComponents()
        {
            //------Render credit textbox component------
            try
            {
                creditTextBox = driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderMessage()
        {
            //------Render message component------
            try
            {
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderValidationMessage()
        {
            //------Render validation message component------
            try
            {
                validationMessage = driver.FindElement(By.XPath("//div[@class='ui basic red prompt label transition visible']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddShareSkill(SkillModel skill)
        {
            //--------Adding Skill-----
            Wait.WaitToExist(driver, "XPath", "//select[@name='categoryId']", 4);
            //Entering details
            RenderComponents();

            title.SendKeys(skill.title);
            description.SendKeys(skill.description);
            SelectElement categoryOption = new SelectElement(categoryDropDown);
            categoryOption.SelectByText(skill.category);
            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='subcategoryId']", 4);
            RenderSubCategoryComponents();
            SelectElement subCategoryOption = new SelectElement(subCategoryDropDown);
            subCategoryOption.SelectByText(skill.subCategory);
            tags.SendKeys(skill.tags);
            tags.SendKeys(Keys.Enter);
            SelectServiceType(skill.serviceType);
            SelectLocationType(skill.locationType);
            startDate.SendKeys(GetTodaysDate().ToString("dd/MM/yyyy"));
            endDate.SendKeys(GetTodaysDate().AddDays(6).ToString("dd/MM/yyyy"));
            SelectCheckBox(skill.day);
            EnterStartTime(skill.day, skill.startTime);
            EnterEndTime(skill.day, skill.endTime);
            SelectSkillTrade(skill.skillTrade, skill.skillExchangeOrCredit);
            SelectActive(skill.active);
            ClickOnSaveButton();
        }
        public void AddShareSkillWithPastEndDate(SkillModel skill)
        {
            //--------Adding Skill-----
            Wait.WaitToExist(driver, "XPath", "//select[@name='categoryId']", 4);
            //Entering details
            RenderComponents();
            title.SendKeys(skill.title);
            description.SendKeys(skill.description);
            SelectElement categoryOption = new SelectElement(categoryDropDown);
            categoryOption.SelectByText(skill.category);
            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='subcategoryId']", 4);
            RenderSubCategoryComponents();
            SelectElement subCategoryOption = new SelectElement(subCategoryDropDown);
            subCategoryOption.SelectByText(skill.subCategory);
            tags.SendKeys(skill.tags);
            tags.SendKeys(Keys.Enter);
            SelectServiceType(skill.serviceType);
            SelectLocationType(skill.locationType);
            startDate.SendKeys(GetTodaysDate().ToString("dd/MM/yyyy"));
            endDate.SendKeys(GetTodaysDate().AddDays(-2).ToString("dd/MM/yyyy"));
            SelectCheckBox(skill.day);
            EnterStartTime(skill.day, skill.startTime);
            EnterEndTime(skill.day, skill.endTime);
            SelectSkillTrade(skill.skillTrade, skill.skillExchangeOrCredit);
            SelectActive(skill.active);
            ClickOnSaveButton();
        }
        public void UpdateSkillDetails(SkillModel skill)
        {
            //---Updating Skill-----
            Wait.WaitToExist(driver, "XPath", "//input[@name='title']", 4);
            Wait.WaitToExist(driver, "XPath", "//select[@name='categoryId']", 4);
            //Entering details
            RenderComponents();
            description.SendKeys(Keys.Control + "A");
            description.SendKeys(Keys.Backspace);
            description.SendKeys(skill.description);
            ClickOnSaveButton();
        }
        public string GetMessage()
        {
            //--Returning error or success message--
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box-inner']", 9);
            RenderMessage();
            string message = messageWindow.Text;
            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 6);
            closeMessageIcon.Click();
            return message;
        }
        public void CancelAddShareSkill(SkillModel skill)
        {
            //---Cancel adding share skil-----
            Wait.WaitToExist(driver, "XPath", "//input[@name='title']", 4);
            Wait.WaitToExist(driver, "XPath", "//select[@name='categoryId']", 4);
            //Entering details
            RenderComponents();
            title.SendKeys(skill.title);
            description.SendKeys(skill.description);
            SelectElement categoryOption = new SelectElement(categoryDropDown);
            categoryOption.SelectByText(skill.category);
            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='subcategoryId']", 4);
            RenderSubCategoryComponents();
            SelectElement subCategoryOption = new SelectElement(subCategoryDropDown);
            subCategoryOption.SelectByText(skill.subCategory);
            tags.SendKeys(skill.tags);
            tags.SendKeys(Keys.Enter);
            SelectServiceType(skill.serviceType);
            SelectLocationType(skill.locationType);
            startDate.SendKeys(GetTodaysDate().ToString());
            endDate.SendKeys(GetTodaysDate().AddDays(6).ToString());
            SelectCheckBox(skill.day);
            EnterStartTime(skill.day, skill.startTime);
            EnterEndTime(skill.day, skill.endTime);
            SelectSkillTrade(skill.skillTrade, skill.skillExchangeOrCredit);
            SelectActive(skill.active);
            //Click on cancel button
            cancelButton.Click();
        }
        public string GetValidationMessage()
        {
            //--Returning validation message--
            Wait.WaitToExist(driver, "XPath", "//div[@class='ui basic red prompt label transition visible']", 5);
            RenderValidationMessage();
            string message = validationMessage.Text;
            return message;
        }
        public void SelectCheckBox(List<string> day)
        {
            //------Select checkbox------
            foreach (IWebElement checkBox in checkBoxes)
            {
                // Get the day associated with the checkbox
                IWebElement dayLabel = checkBox.FindElement(By.XPath("./label"));
                string dayText = dayLabel.Text;
                for (int i = 0; i < day.Count; i++)
                {
                    if (dayText.Equals(day[i], StringComparison.OrdinalIgnoreCase))
                    {
                        //Click on CheckBox of desired row
                        checkBox.FindElement(By.XPath("./input")).Click();
                        break;
                    }
                }
            }
        }

        public void EnterStartTime(List<string> day, string startTime)
        {
            //------Enter start time------
            IReadOnlyCollection<IWebElement> dayLabelList = driver.FindElements(By.XPath("//div[@class='ui checkbox']/label"));
            foreach (IWebElement dayLabel in dayLabelList)
            {
                string dayText = dayLabel.Text;
                for (int i = 0; i < day.Count; i++)
                {
                    if (dayText.Equals(day[i], StringComparison.OrdinalIgnoreCase))
                    {
                        dayLabel.FindElement(By.XPath(".//following::input")).SendKeys(startTime);
                        break;
                    }
                }
            }
        }
        public void EnterEndTime(List<string> day, string endTime)
        {
            //------Enter end time------
            IReadOnlyCollection<IWebElement> dayLabelList = driver.FindElements(By.XPath("//div[@class='ui checkbox']/label"));
            foreach (IWebElement dayLabel in dayLabelList)
            {
                string dayText = dayLabel.Text;
                for (int i = 0; i < day.Count; i++)
                {
                    if (dayText.Equals(day[i], StringComparison.OrdinalIgnoreCase))
                    {
                        dayLabel.FindElement(By.XPath(".//following::input//following::input")).SendKeys(endTime);
                        break;
                    }
                }
            }
        }
        public void SelectSkillTrade(string skillTrade, string skillExchangeOrCredit)
        {
            //------Select skill trade------
            if (skillTrade == "Skill-exchange")
            {
                skillExchangeSkillTrade.Click();
                skillExchange.SendKeys(skillExchangeOrCredit);
                skillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                creditSkillTrade.Click();
                RenderCreditTextBoxComponents();
                creditTextBox.SendKeys(skillExchangeOrCredit);
            }
        }
        public DateTime GetTodaysDate()
        {
            //------Get todays date------
            DateTime todaysDate = DateTime.Today;
            return todaysDate;
        }
        public void SelectServiceType(string serviceType)
        {
            //------Select service type------
            if (serviceType == "Hourly basis service")
            {
                hourlyBasisService.Click();
            }
            else
            {
                oneOffService.Click();
            }
        }
        public void SelectLocationType(string locationType)
        {
            //------Select location type------
            if (locationType == "Online")
            {
                onLineLocationType.Click();

            }
            else
            {
                onSiteLocationType.Click();
            }
        }

        public void SelectActive(string active)
        {
            //--Change skill active/deactive status---
            if (active == "Active")
            {
                activeRadioButton.Click();
            }
            else
            {
                hiddenRadioButton.Click();
            }
        }
        public void ClickOnSaveButton()
        {
            //--------Click on save button--------
            saveButton.Click();
        }
        public void ClickOnCancelButton()
        {
            //--------Click on cancel button--------
            cancelButton.Click();
        }
    }
}
