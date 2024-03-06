using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.AssertHelpers
{
    public class ManageListingHelper
    {
        public static void AssertSkillDeleted(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Skill not deleted successfully");

        }
        public static void AssertSkillDeletedMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Succes message is not correct for delete skill");

        }
        public static void AssertSkillUpdated(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Skill not updated successfully");

        }
        public static void AssertSkillNotUpdated(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Skill not updated successfully");

        }
        public static void AssertSkillActivatedMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Succes message is not correct for skill activation");

        }
        public static void AssertSkillDectivatedMessage(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Succes message is not correct for skill deactivation");

        }
        public static void AssertNextPageNavigation(int expected, int actual)
        {

            Assert.AreEqual(expected, actual, "Not navigated to next page successfully");

        }
        public static void AssertPreviousPageNavigation(int expected, int actual)
        {

            Assert.AreEqual(expected, actual, "Not navigated to next page successfully");

        }
        public static void AssertWatchSkillDetail(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Not able to watch skill details successfully");

        }
        public static void AssertSkillNotDeleted(string expected, string actual)
        {

            Assert.AreEqual(expected, actual, "Skill deleted");

        }
    }
}
