using OpenQA.Selenium;
using SpecFlowProject.Model;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.SignInOverview
{
    public class SignInComponent : CommonDriver
    {
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement loginButton;
        public void RenderComponents()
        {
            //--------Render component--------
            try
            {
                emailTextbox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
                passwordTextbox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
                loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void SignIn(UserInformation user)
        {
            //------Signing in into Mars--------
            RenderComponents();

            //Enter the email address and password.
            emailTextbox.SendKeys(user.email);
            passwordTextbox.SendKeys(user.password);
            //Click on "Login" button
            loginButton.Click();
        }
    }
}