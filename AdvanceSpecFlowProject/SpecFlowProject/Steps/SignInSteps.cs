using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.SignInOverview;
using SpecFlowProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProject.Model;

namespace SpecFlowProject.Steps
{
    public class SignInSteps
    {
        SplashPage SplashPageComponentObj;
        SignInComponent SigninComponentObj;
        public SignInSteps()
        {
            SplashPageComponentObj = new SplashPage();
            SigninComponentObj = new SignInComponent();
        }

        public void SignIn(UserInformation user)
        {
            //------Sign in------
            try
            {
                SplashPageComponentObj.ClickSignInButton();
                //Login into Mars         
                SigninComponentObj.SignIn(user);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
