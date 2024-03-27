using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.AssertHelpers
{
    public class ShareSkillAssertHelper
    {
        public static void AssertSkillAdded(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Skill not added successfully");

        }
        public static void AssertSkillNotAdded(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Skill added successfully");

        }
        public static void AssertInvalidSkillMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Error message is not correct for adding invalid skill");

        }
        public static void AssertValidationMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Validation message is not correct for adding invalid skill");

        }
    }
}
