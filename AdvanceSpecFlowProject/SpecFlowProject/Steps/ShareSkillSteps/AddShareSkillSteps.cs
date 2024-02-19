using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages.Components.ShareSkillOverview;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Steps.ShareSkillSteps
{
    public class AddShareSkillSteps
    {
        AddShareSkillComponent AddShareSkillComponentObj;


        public AddShareSkillSteps()
        {
            AddShareSkillComponentObj = new AddShareSkillComponent();
        }

        public void AddShareSkill(SkillModel skill)
        {
            //--------Add a skill--------
            try
            {
                AddShareSkillComponentObj.AddShareSkill(skill);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void AddShareSkillWithPastEndDate(SkillModel skill)
        {
            //--------Add a skill with past end date--------
            try
            {
                string expectedMessage = "Start Date shouldn't be greater than End Date";
                AddShareSkillComponentObj.AddShareSkillWithPastEndDate(skill);
                ValidateInvalidMessage();
                ValidateValidationMessage(expectedMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void CancelAddShareSkill(SkillModel skill)
        {
            //--------Cancel adding a skill--------
            try
            {
                AddShareSkillComponentObj.CancelAddShareSkill(skill);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateInvalidMessage()
        {
            //--------Validate an invalid message--------
            try
            {
                //Verify if message is displayed on adding invalid share skill
                string expectedMessage = "Please complete the form correctly.";
                string actualMessage = AddShareSkillComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match.User added share skill successfully !!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateEmptyTitleValidationMessage()
        {
            //--Validate validation error message for empty title--
            try
            {
                string expectedMessage = "Title is required";
                ValidateInvalidMessage();
                ValidateValidationMessage(expectedMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateEmptyDescriptionValidationMessage()
        {
            //--Validate validation error message for empty description--
            try
            {
                string expectedMessage = "Description is required";
                ValidateInvalidMessage();
                ValidateValidationMessage(expectedMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateValidationMessage(string expectedMessage)
        {
            //----Validate validation message--
            try
            {
                string expected = expectedMessage;
                string actual = AddShareSkillComponentObj.GetValidationMessage();
                Assert.AreEqual(expected, actual, "Actual and expected message do not match.");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
