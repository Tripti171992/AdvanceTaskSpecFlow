using OpenQA.Selenium;
using SpecFlowProject.Model;
using SpecFlowProject.Utilities;

namespace SpecFlowProject.Pages.Components.RegistrationOverview
{
    public class RegistrationComponent : CommonDriver
    {

        private IWebElement firstNameTextbox;
        private IWebElement lastNameTextbox;
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement confirmPasswordTextbox;
        private IWebElement checkbox;
        private IWebElement finalJoinButton;
        private IWebElement registrationMessage;
        public void RenderComponents()
        {
            //------Render component------

            firstNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='First name']"));
            lastNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='Last name']"));
            emailTextbox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
            passwordTextbox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
            confirmPasswordTextbox = driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
            checkbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            finalJoinButton = driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        }
        public void RenderMessageComponents()
        {
            //------Render message component------

            registrationMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }

        public void RegistrationInvalid(RegistrationModel user)
        {
            //------Invalid Registration into Mars------

            RenderComponents();

            //Enter new user information
            firstNameTextbox.SendKeys(user.firstName);
            lastNameTextbox.SendKeys(user.lastName);
            emailTextbox.SendKeys(user.emailAddress);
            passwordTextbox.SendKeys(user.password);
            confirmPasswordTextbox.SendKeys(user.confirmPassword);
            if (user.checkbox == "yes")
            {
                checkbox.Click();
            }
            finalJoinButton.Click();
        }
        public string GetRegistrationMessage()
        {
            //------Return registration message------

            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 2);
                RenderMessageComponents();
                return registrationMessage.Text;
            }
            catch (WebDriverTimeoutException ex)
            {
                return ex.Message;
            }
        }
    }
}
