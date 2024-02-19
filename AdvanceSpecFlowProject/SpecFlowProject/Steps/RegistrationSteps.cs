using SpecFlowProject.Model;
using SpecFlowProject.Pages;
using NUnit.Framework;
using SpecFlowProject.Pages.Components.RegistrationOverview;

namespace MarsAdvanceTaskNUnit.Steps
{
    public class RegistrationSteps
    {
        SplashPage SplashPageComponentObj;
        RegistrationComponent RegistrationComponentObj;
        public RegistrationSteps()
        {
            SplashPageComponentObj = new SplashPage();
            RegistrationComponentObj = new RegistrationComponent();
        }
        public void RegistrationInvalid(RegistrationModel user)
        {
            //------Invalid registration------
            try
            {
                SplashPageComponentObj.ClickJoinButton();
                RegistrationComponentObj.RegistrationInvalid(user);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateRegistrationInvalid()
        {
            //------Validate invalid registration------
            try
            {
                string message = RegistrationComponentObj.GetRegistrationMessage();
                Assert.AreNotEqual("Registration successful", message, "Actual and expected message do not match.User registered successfully !!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

    }
}
