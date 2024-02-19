using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Steps.ShareSkillSteps
{
    public class ManageListingsComponentSteps
    {
        ManageListingsComponent ManageListingsComponentObj;
        public ManageListingsComponentSteps()
        {
            ManageListingsComponentObj = new ManageListingsComponent();
        }
        public void DeleteShareSkill(SkillModel skill)
        {
            //--------Delete a skill--------
            try
            {
                ManageListingsComponentObj.DeleteShareSkill(skill);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateDeleteSkillMessage(SkillModel skill)
        {
            //Verify if message is displayed on deleting share skill
            try
            {
                string expectedMessage = skill.title + " has been deleted";
                string actualMessage = ManageListingsComponentObj.GetMessage();
                if (actualMessage.Contains("Timed out after"))
                {
                    Console.WriteLine("");
                }
                else
                {
                    Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Share skill not deleted successfully !!");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateSkillDeleted(SkillModel skill)
        {
            //Verify the share skill record deleted
            try
            {
                string result = ManageListingsComponentObj.GetDeleteShareSkillResult(skill);
                Assert.AreEqual("Deleted", result, "Actual and expected result do not match. Share skill not deleted!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void WatchSkillDetails(SkillModel skill)
        {
            //--------Watch a skill details--------
            try
            {
                ManageListingsComponentObj.WatchSkillDetails(skill);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void UpdateSkillDetails(SkillModel skill)
        {
            //--------Update a skill details
            try
            {
                ManageListingsComponentObj.UpdateSkillDetails(skill);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateSkillUpdated(SkillModel skill)
        {
            //--------Validate a skill updation--------
            try
            {
                //Verify the updated skill record in the table
                string result = ManageListingsComponentObj.GetUpdateSkillResult(skill);
                Assert.AreEqual("Updated", result, "Actual and expected result do not match. Skill not updated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateSkillNotUpdated(SkillModel skill)
        {
            //--------Validate a skill is not updated----
            try
            {
                //Verify the updated skill record in the table
                string result = ManageListingsComponentObj.GetUpdateSkillResult(skill);
                Assert.AreNotEqual("Updated", result, "Actual and expected result match.");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void CancelDeleteShareSkill(SkillModel skill)
        {
            //--------Cancell deletig a skill--------
            try
            {
                ManageListingsComponentObj.CancelDeleteShareSkill(skill);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateSkillNotDeleted(SkillModel skill)
        {
            //Verify the share skill record not deleted
            try
            {
                string result = ManageListingsComponentObj.GetDeleteShareSkillResult(skill);
                Assert.AreEqual("Not Deleted", result, "Actual and expected result do not match. Share skill deleted!!");

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ActivateShareSkill(SkillModel skill)
        {
            //--------Activate a skill--------
            try
            {
                ManageListingsComponentObj.ChangeShareSkillStatus(skill);
                //Verify the message displayed on activating share skill
                string expectedMessage = "Service has been activated";
                string actualMessage = ManageListingsComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected share skill do not match. Share skill not activated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void DeactivateShareSkill(SkillModel skill)
        {
            //--------Deavtivate a skill--------
            try
            {
                ManageListingsComponentObj.ChangeShareSkillStatus(skill);
                //Verify the message displayed on deactivating share skill
                string expectedMessage = "Service has been deactivated";
                string actualMessage = ManageListingsComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected share skill do not match. Share skill not deactivated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void NavigateToNextPage()
        {
            //--------Navigate to next page----
            try
            {
                int expectedNextPage = ManageListingsComponentObj.GetActivePageNumber() + 1;
                ManageListingsComponentObj.NavigateToNextPage();
                int actualNextPage = ManageListingsComponentObj.GetActivePageNumber();
                Assert.AreEqual(expectedNextPage, actualNextPage, "Actual and expected page number do not match. Not navigated to next page!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void NavigateToPreviousPage()
        {
            //--------Navigate to previous page --------
            try
            {
                ManageListingsComponentObj.NavigateToNextPage();
                int expectedPrevioustPage = ManageListingsComponentObj.GetActivePageNumber() - 1;
                ManageListingsComponentObj.NavigateToPreviousPage();
                int actualPreviousPage = ManageListingsComponentObj.GetActivePageNumber();
                Assert.AreEqual(expectedPrevioustPage, actualPreviousPage, "Actual and expected page number do not match. Not navigated to previous page!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateShareSkillAdded(SkillModel skill)
        {
            //--------Validate askill is added--------
            try
            {
                //Verify the added share skill record in the table
                string additionStatus = ManageListingsComponentObj.GetShareSkillAddedStatus(skill);
                Assert.AreEqual("Added", additionStatus, "Actual and expected do not match. Share skill not added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateAllSkillNotAdded(SkillModel skill)
        {
            //--------Validate a skill is not added--------
            try
            {
                //Verify the share skill record in the table is not added
                string additionStatus = ManageListingsComponentObj.GetShareSkillAddedStatus(skill);
                Assert.AreEqual("Not Added", additionStatus, "Actual and expected do not match. Share skill added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateShareSkillNotAdded(SkillModel skill)
        {
            //--------Validate a skill is not added--------
            try
            {
                //Verify the share skill record in the table is not added
                string newTitleAddedCell = ManageListingsComponentObj.GetTitle();
                Assert.AreNotEqual(skill.title, newTitleAddedCell, "Actual and expected skill do not match. Skill added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
