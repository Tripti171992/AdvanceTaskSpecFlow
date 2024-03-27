using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.AssertHelpers
{
    public class DescriptionAssertHelper
    {
        public static void AssertDescriptionAddedUpdatedMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Description added or updated message not correct");

        }
        public static void AssertDescriptionAddedUpdated(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Description not added or updated successfully");

        }
        public static void AssertDescriptionEntered(string expected, string actual)
        {

            Assert.AreNotEqual(expected, actual, "Description entered matches");

        }
        public static void AssertDescriptionNotAddedUpdated(string expected, string actual)
        {

            Assert.AreNotEqual(expected, actual, "Description added or updated successfully");

        }
    }
}
