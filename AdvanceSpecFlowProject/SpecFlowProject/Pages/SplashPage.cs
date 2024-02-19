using SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages
{
    public class SplashPage : CommonDriver
    {
        private IWebElement signInButton;
        private IWebElement JoinButton;
        public void RenderSignInComponents()
        {
            //--------Render sign in component--------
            try
            {
                signInButton = driver.FindElement(By.XPath("//*[text()='Sign In']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderRegistationComponents()
        {
            //--------Render registration component--------
            try
            {
                JoinButton = driver.FindElement(By.XPath("//button[text()='Join']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickSignInButton()
        {
            //--------Click on "Sign In" button--------
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Sign In']", 10);

            RenderSignInComponents();
            signInButton.Click();
        }
        public void ClickJoinButton()
        {
            //--------Click on "Join" button--------
            Wait.WaitToBeClickable(driver, "XPath", "//button[text()='Join']", 10);

            RenderRegistationComponents();
            JoinButton.Click();
        }
    }
}