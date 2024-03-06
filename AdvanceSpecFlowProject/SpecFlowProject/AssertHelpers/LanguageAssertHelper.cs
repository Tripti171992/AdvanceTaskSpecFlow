using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.AssertHelpers
{
    public class LanguageAssertHelper
    {
        public static void AssertLanguageAddedSuccessMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Succes message is not correct for add language");

        }
        public static void AssertLanguageAdded(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Language not added successfully");

        }
        public static void AssertDeleteLanguageSuccessMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Succes message is not correct for delete language");

        }
        public static void AssertLanguageDeleted(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Language not deleted successfully");

        }
        public static void AssertLanguageUpdatedMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Succes message is not correct for updated language");

        }

        public static void AssertLanguageUpdated (string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Language not updated successfully");

        }
        public static void AssertLanguageNotAdded(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Language added.");

        }
        public static void AssertDuplicateLanguageErrorMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Actual and expected duplicate error message do not match.");

        }
        public static void AssertInvalidLanguageErrorMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Actual and expected invalid error message do not match.");

        }
        public static void AssertLanguageNotUpdated(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Actual and expected do not match.Language updated.");

        }
    }
}
