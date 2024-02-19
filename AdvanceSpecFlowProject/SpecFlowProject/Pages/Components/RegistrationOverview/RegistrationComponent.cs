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
            try
            {
                firstNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='First name']"));
                lastNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='Last name']"));
                emailTextbox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
                passwordTextbox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
                confirmPasswordTextbox = driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
                checkbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
                finalJoinButton = driver.FindElement(By.XPath("//*[@id='submit-btn']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderMessageComponents()
        {
            //------Render message component------
            try
            {
                registrationMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
                RenderMessageComponents();
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 1);
                return registrationMessage.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
