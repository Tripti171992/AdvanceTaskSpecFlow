using SpecFlowProject.Model;
using SpecFlowProject.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.DescriptionOverview
{
    public class ActionOnDescriptionComponent : CommonDriver
    {
        private IWebElement textArea;
        private IWebElement saveButton;
        private IWebElement messageWindow;
        public void RenderComponents()
        {
            //------Render component------
            try
            {
                textArea = driver.FindElement(By.XPath("//textarea[contains(@placeholder,' hobbies, additional expertise, or')]"));
                saveButton = driver.FindElement(By.XPath("(//*[text()='Save'])[2]"));
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickSaveButton()
        {
            //------Click on "Save" button------
            RenderComponents();
            saveButton.Click();
        }
        public void AddUpdateDescription(DescriptionModel description)
        {
            //-------Adding/Updating description------
            Thread.Sleep(500);
            RenderComponents();
            //Write description
            if (textArea.Text.Count() > 0)
            {
                textArea.Clear();
            }
            textArea.SendKeys(description.description);
            //Click on "Save" button
            saveButton.Click();
        }
        public void AddUpdateOutOfLimitDescription(DescriptionModel description)
        {
            //-------Adding/Updating out of limit description-------
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[contains(@placeholder,' hobbies, additional ')]", 4);
            RenderComponents();
            //Write description
            if (textArea.Text.Count() > 0)
            {
                textArea.Clear();
            }
            textArea.SendKeys(description.description);
            //Click on "Save" button
            saveButton.Click();
        }
        public string GetMessage()
        {
            //------Return error or success message------
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 5);
            RenderMessage();
            string message = messageWindow.Text;
            return message;
        }
        public string GetEnteredDescription()
        {
            //------Return new entered description------
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[contains(@placeholder,' hobbies, additional ')]", 4);
            RenderComponents();
            return textArea.Text;
        }
    }
}
