using SpecFlowProject.Model;
using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages.Components.ProfileOverview
{
    public class ProfileLanguageOverviewComponent : CommonDriver
    {
        private IWebElement addNewLanguageButton;
        private IWebElement tableHead;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;
        public void RenderComponents()
        {
            //------Render component------
            try
            {
                addNewLanguageButton = driver.FindElement(By.XPath("//*[text()='Language']/following-sibling::th[2]/div"));
                tableHead = driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead"));
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
        public void ClickAddLanguageButton()
        {
            //------Adding Language------
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Language']/following-sibling::th[2]/div", 7);
            RenderComponents();
            addNewLanguageButton.Click();
        }
        public string GetLanguageAddedResult(LanguageModel language)
        {
            //------Return language added result------
            WaitForRowsToGetPopulated();
            RenderComponents();
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody/tr"));
            string result = "Not added";
            foreach (IWebElement row in rows)
            {
                // Get the text of the language and level column in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                IWebElement languageLevel = row.FindElement(By.XPath("./td[2]"));
                // Check if the language matches the provided text
                if (languageElement.Text.Equals(language.language, StringComparison.OrdinalIgnoreCase) && languageLevel.Text.Equals(language.level, StringComparison.OrdinalIgnoreCase))
                {
                    result = "Added";
                    break;
                }
            }
            return result;
        }
        public void ClickUpdateIcon(string language)
        {
            //------Updating Language------
            WaitForRowsToGetPopulated();
            RenderComponents();
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody/tr"));
            foreach (IWebElement row in rows)
            {
                // Get the text of the language column in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                // Check if the language matches the provided language
                if (languageElement.Text.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    //Click on update icon button of desired row
                    IWebElement languageUpdateIcon = row.FindElement(By.XPath("./td[3]/span[1]/i"));
                    languageUpdateIcon.Click();
                    break;
                }
            }
        }
        public string GetUpdatedLanguageResult(UpdateLanguageModel language)
        {
            //------Return language updated result------
            WaitForRowsToGetPopulated();
            RenderComponents();
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody/tr"));
            string result = "Not updated";
            foreach (IWebElement row in rows)
            {
                // Get the text of the language and level column in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                IWebElement languageLevel = row.FindElement(By.XPath("./td[2]"));
                // Check if the language matches the provided text
                if (languageElement.Text.Equals(language.language, StringComparison.OrdinalIgnoreCase) && languageLevel.Text.Equals(language.level, StringComparison.OrdinalIgnoreCase))
                {
                    result = "Updated";
                    break;
                }
            }
            return result;
        }
        public void DeleteLanguage(LanguageModel language)
        {
            //------Deleting Language------
            WaitForRowsToGetPopulated();
            RenderComponents();
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody/tr"));
            foreach (IWebElement row in rows)
            {
                // Get the language column element in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                // Check if the language matches the provided text               
                if (languageElement.Text.Equals(language.language, StringComparison.OrdinalIgnoreCase))
                {
                    //Click on delete icon button of desired row
                    IWebElement languageDeleteIcon = row.FindElement(By.XPath("./td[3]/span[2]/i"));
                    languageDeleteIcon.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
        public void DeleteUpdatedLanguage(UpdateLanguageModel language)
        {
            //------Deleting Language------
            WaitForRowsToGetPopulated();
            RenderComponents();
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody/tr"));
            foreach (IWebElement row in rows)
            {
                // Get the language column element in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                // Check if the language matches the provided text
                if (languageElement.Text.Equals(language.language, StringComparison.OrdinalIgnoreCase))
                {
                    //Click on delete icon button of desired row
                    IWebElement languageDeleteIcon = row.FindElement(By.XPath("./td[3]/span[2]/i"));
                    languageDeleteIcon.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
        public string GetDeleteLanguageResult(LanguageModel language)
        {
            //------Return language deleted result------
            WaitForRowsToGetPopulated();
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead/following-sibling::tbody/tr"));
            string result = "Deleted";
            foreach (IWebElement row in rows)
            {
                // Get the text of the language column in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                // Check if the language matches the provided text
                if (languageElement.Text.Equals(language.language, StringComparison.OrdinalIgnoreCase))
                {
                    result = "Not Deleted";
                    break;
                }
            }
            return result;
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
        public void WaitForRowsToGetPopulated()
        {
            try
            {
                //wait for rows to get populated

                Wait.WaitToBeVisible(driver, "XPath", "//th[text()='Language']//ancestor::thead/following-sibling::tbody[last()]", 4);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }
    }
}
