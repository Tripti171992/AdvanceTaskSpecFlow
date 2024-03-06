using SpecFlowProject.Utilities;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    public class SplashPage : CommonDriver
    {
        private IWebElement signInButton;
        private IWebElement JoinButton;
        public void RenderSignInComponents()
        {
            //--------Render sign in component--------

            signInButton = driver.FindElement(By.XPath("//*[text()='Sign In']"));
        }
        public void RenderRegistationComponents()
        {
            //--------Render registration component--------

            JoinButton = driver.FindElement(By.XPath("//button[text()='Join']"));
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