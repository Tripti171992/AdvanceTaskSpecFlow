using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.AssertHelpers
{
    public class SignInAssertHelper
    {
        public static void AssertSignInSuccessful(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "SignIn unsuccessful");

        }
        public static void AssertSignUnsuccessful(string expected, string actual)
        {

            Assert.AreNotEqual(expected, actual, "SignIn successful");

        }
    }
}
