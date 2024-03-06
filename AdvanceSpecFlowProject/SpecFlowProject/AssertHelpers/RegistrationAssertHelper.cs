using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.AssertHelpers
{
    public class RegistrationAssertHelper
    {
        public static void AssertRegisterUnsuccessful(string expected, string actual)
        {

            Assert.AreNotEqual(expected, actual, "Registration successful.");

        }
    }
}
