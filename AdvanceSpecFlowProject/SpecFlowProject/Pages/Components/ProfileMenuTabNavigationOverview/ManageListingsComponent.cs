using SpecFlowProject.Model;
using SpecFlowProject.Utilities;
using OpenQA.Selenium;
using SpecFlowProject.Pages.Components.ShareSkillOverview;

namespace SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview
{
    public class ManageListingsComponent : CommonDriver
    {
        AddShareSkillComponent AddShareSkillComponentObj;
        private IWebElement activePageTab;
        private IWebElement firstPageTab;
        private IWebElement previousPageButton;
        private IWebElement nextPageButton;
        private IWebElement tableHead;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;
        private IWebElement deleteServiceYesButton;
        private IWebElement deleteServiceNoButton;
        private int activePageNumber;
        private int noOfPages;

        public ManageListingsComponent()
        {
            AddShareSkillComponentObj = new AddShareSkillComponent();
            activePageNumber = 1;
            noOfPages = 0;
        }
        public void RenderComponents()
        {
            //------Render component------
            try
            {
                firstPageTab = driver.FindElement(By.XPath("//button[text()='1']"));
                previousPageButton = driver.FindElement(By.XPath("//button[text()='<']"));
                nextPageButton = driver.FindElement(By.XPath("//button[text()='>']"));
                tableHead = driver.FindElement(By.XPath("//th[text()='Image']//ancestor::thead"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderActivePageComponents()
        {
            //------Render active page componen------t
            try
            {
                activePageTab = driver.FindElement(By.XPath("//*[@class='ui active button currentPage']"));
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
        public void DeleteYourServiceConfirmationComponent()
        {
            //--Render delete your service confirmation component--
            try
            {
                deleteServiceYesButton = driver.FindElement(By.XPath("//*[text()='Yes']"));
                deleteServiceNoButton = driver.FindElement(By.XPath("//*[text()='No']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteShareSkill(SkillModel skill)
        {
            //----Deleting Skill------------
            Thread.Sleep(2000);
            CountNoOfPages();
            string matchFound = "";
            for (int i = 1; i <= noOfPages; i++)
            {
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    // Check if the title matches the provided title
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        //Click on delete icon button of desired row
                        IWebElement deleteIcon = row.FindElement(By.XPath("./td[8]//button[3]"));
                        deleteIcon.Click();
                        DeleteYourServiceConfirmationComponent();
                        deleteServiceYesButton.Click();
                        matchFound = "Yes";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
        }
        public void CountNoOfPages()
        {
            //------Count number of pages------
            Thread.Sleep(2000);
            IReadOnlyCollection<IWebElement> buttons = driver.FindElements(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']/button"));
            noOfPages = buttons.Count - 2;
            if (GetActivePageNumber() != 1)
            {
                RenderComponents();
                firstPageTab.Click();
            }
        }
        public void WatchSkillDetails(SkillModel skill)
        {
            //----Watch skill details------------
            CountNoOfPages();
            string matchFound = "";
            for (int i = 1; i <= noOfPages; i++)
            {
                Thread.Sleep(1000);
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    // Check if the title matches the provided title
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        //Click on watch icon button of desired row
                        IWebElement watchIcon = row.FindElement(By.XPath("./td[8]//button[1]"));
                        watchIcon.Click();
                        matchFound = "Yes";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
        }
        public void UpdateSkillDetails(SkillModel skill)
        {
            //----Edit skill details------------         
            CountNoOfPages();
            string matchFound = "";
            for (int i = 1; i <= noOfPages; i++)
            {
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        //Click on edit icon button of desired row
                        IWebElement editIcon = row.FindElement(By.XPath("./td[8]//button[2]"));
                        editIcon.Click();
                        //editing details
                        AddShareSkillComponentObj.UpdateSkillDetails(skill);
                        matchFound = "Yes";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
        }
        public void ChangeShareSkillStatus(SkillModel skill)
        {
            //----Activating/Deactivating Skill------------
            CountNoOfPages();
            string matchFound = "";
            for (int i = 1; i <= noOfPages; i++)
            {
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    // Check if the title matches the provided title
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        //Click  active/deactivate icon button of desired row
                        IWebElement activeIcon = row.FindElement(By.XPath("./td[7]//input"));
                        activeIcon.Click();
                        matchFound = "Yes";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
        }
        public void CancelDeleteShareSkill(SkillModel skill)
        {
            //------------Cancel deleting Skill------------
            CountNoOfPages();
            string matchFound = "";
            for (int i = 1; i <= noOfPages; i++)
            {
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    // Check if the title matches the provided title
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        //Click on delete icon button of desired row
                        IWebElement deleteIcon = row.FindElement(By.XPath("./td[8]//button[3]"));
                        deleteIcon.Click();
                        DeleteYourServiceConfirmationComponent();
                        deleteServiceNoButton.Click();
                        matchFound = "Yes";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
        }
        public string GetTitle()
        {
            //--Return new added Title--
            WaitForRowsToGetPopulated();
            RenderComponents();
            IWebElement newTitleAddedCell = tableHead.FindElement(By.XPath("./following-sibling::tbody/descendant::td[3]"));
            return newTitleAddedCell.Text;
        }
        public string GetUpdateSkillResult(SkillModel skill)
        {
            //------------Return skill updated result------------
            CountNoOfPages();
            string matchFound = "";
            string result = "Not updated";
            for (int i = 1; i <= noOfPages; i++)
            {
                Thread.Sleep(1000);
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase) && descriptionElement.Text.Equals(skill.description, StringComparison.OrdinalIgnoreCase))
                    {
                        result = "Updated";
                        matchFound = "Yes";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
            return result;
        }
        public int GetActivePageNumber()
        {
            //------Returning active page------
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            RenderActivePageComponents();
            activePageNumber = Convert.ToInt32(activePageTab.Text);
            return activePageNumber;
        }
        public void ClickNextPage()
        {
            //----Click on next page buttons-----
            nextPageButton.Click();
            Thread.Sleep(2000);
            RenderActivePageComponents();
            activePageNumber = Convert.ToInt32(activePageTab.Text);
        }
        public void NavigateToPreviousPage()
        {
            //------Move to next page------
            WaitForRowsToGetPopulated();
            RenderComponents();
            ClickPreviousPage();
        }
        public void NavigateToNextPage()
        {
            //------Move to previous page------           
            WaitForRowsToGetPopulated();
            RenderComponents();
            ClickNextPage();
        }
        public void ClickPreviousPage()
        {
            //-----Click on previous page buttons----
            previousPageButton.Click();
            Thread.Sleep(1000);
            RenderActivePageComponents();
            activePageNumber = Convert.ToInt32(activePageTab.Text);
        }
        public string GetShareSkillAddedStatus(SkillModel skill)
        {
            //------------Return skill added result------------
            CountNoOfPages();
            string matchFound = "";
            string result = "Not Added";
            for (int i = 1; i <= noOfPages; i++)
            {
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    // Check if the title matches the provided title
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        matchFound = "Yes";
                        result = "Added";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
            return result;
        }
        public string GetDeleteShareSkillResult(SkillModel skill)
        {
            //------Return skill deleted result------
            CountNoOfPages();
            string matchFound = "";
            string result = "Deleted";
            for (int i = 1; i <= noOfPages; i++)
            {
                RenderComponents();
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Image']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the title column element in the row
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    // Check if the title matches the provided title
                    if (titleElement.Text.Equals(skill.title, StringComparison.OrdinalIgnoreCase))
                    {
                        matchFound = "Yes";
                        result = "Not Deleted";
                        break;
                    }
                }
                if (matchFound == "Yes" || i == noOfPages)
                {
                    break;
                }
                ClickNextPage();
            }
            return result;
        }
        public void WaitForRowsToGetPopulated()
        {
            try
            {
                //wait for rows to get populated
                Wait.WaitToBeVisible(driver, "XPath", "//th[text()='Image']//ancestor::thead/following-sibling::tbody[last()]", 6);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }
        public string GetMessage()
        {
            //------Returning error or success message------
            string message = "";
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 5);
                RenderMessage();
                message = messageWindow.Text;
                //If any message visible close it
                Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
                closeMessageIcon.Click();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
