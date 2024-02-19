using NUnit.Framework;
using SpecFlowProject.Hooks;
using SpecFlowProject.Model;
using SpecFlowProject.Steps;
using SpecFlowProject.Steps.ShareSkillSteps;
using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ShareSkillStepDefinitions : CommonDriver
    {
        HomePageSteps HomePageStepsObj;
        AddShareSkillSteps AddShareSkillStepsObj;
        ManageListingsComponentSteps ManageListingsComponentStepsObj;
        public ShareSkillStepDefinitions()
        {
            HomePageStepsObj = new HomePageSteps();
            AddShareSkillStepsObj = new AddShareSkillSteps();
            ManageListingsComponentStepsObj = new ManageListingsComponentSteps();
        }

        [When(@"I added skill '([^']*)'")]
        public void WhenIAddedSkill(string userSkill)
        {
            //-- Add Skill--
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Deleting share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkill"), "Add share skill successful");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkill"), "Exception in add share skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A skill '([^']*)' should get added")]
        public void ThenASkillShouldGetAdded(string userSkill)
        {
            try
            {
                //------Validating skill addition----------
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.ValidateShareSkillAdded(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkill"), "Skill added successfully validated");
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkill"), "Exception in add skill validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }


        [When(@"I add invalid skill '([^']*)'")]
        public void WhenIAddInvalidSkill(string userSkill)
        {
            //--Adding invalid skill--
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidShareSkill"), "Add invalid share skill successful");
                    AddShareSkillStepsObj.ValidateInvalidMessage();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidShareSkill"), "Exception in add invalid share skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"Invalid skill '([^']*)' should not get added")]
        public void ThenInvalidSkillShouldNotGetAdded(string userSkill)
        {
            try
            {
                //------Validating skill not added----------
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.ValidateAllSkillNotAdded(skill);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SkillException"), "Exception Occured");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I cancelled adding skill '([^']*)'")]
        public void WhenICancelledAddingSkill(string userSkill)
        {
            //-- Cancel adding Skill--
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                HomePageStepsObj.ClickShareSkillButton();
                AddShareSkillStepsObj.CancelAddShareSkill(skillList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelAddShareSkill"), "Cancel add share skill successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelAddShareSkill"), "Exception in cancel add share skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I add skill '([^']*)' with past end date")]
        public void WhenIAddSkillWithPastEndDate(string userSkill)
        {
            //------Add a skill to share with past end date------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                HomePageStepsObj.ClickShareSkillButton();
                AddShareSkillStepsObj.AddShareSkillWithPastEndDate(skillList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkillWithPastEndDate"), "Add share skill with past end date successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkillWithPastEndDate"), "Exception in add share skill with past end date");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A skill '([^']*)' should not get added")]
        public void ThenASkillShouldNotGetAdded(string userSkill)
        {
            //------Validating skill not added----------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                HomePageStepsObj.ClickManageListingsTab();
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SkillNotAdded"), "Skill not added successful");
                ManageListingsComponentStepsObj.ValidateShareSkillNotAdded(skillList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SkillNotAdded"), "Exception Occured in validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I add skill '([^']*)' with empty title")]
        public void WhenIAddSkillWithEmptyTitle(string userSkill)
        {
            //------Adding skill with empty title------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Adding share skill with empty title
                HomePageStepsObj.ClickShareSkillButton();
                AddShareSkillStepsObj.AddShareSkill(skillList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyTitleValidationMessage"), "ValidateEmptyTitleValidationMessage successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyTitleValidationMessage"), "Exception in ValidateEmptyTitleValidationMessage");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"An error message should display for empty title")]
        public void ThenAnErrorMessageShouldDisplayForEmptyTitle()
        {
            //------Validating error message for empty title----------
            try
            {
                AddShareSkillStepsObj.ValidateEmptyTitleValidationMessage();
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyTitleValidationMessage"), "Exception in ValidateEmptyTitleValidationMessage");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I add skill '([^']*)' with empty description")]
        public void WhenIAddSkillWithEmptyDescription(string userSkill)
        {
            //------Adding skill with empty description------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Adding share skill with empty description
                HomePageStepsObj.ClickShareSkillButton();
                AddShareSkillStepsObj.AddShareSkill(skillList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyDescriptionValidationMessage"), "ValidateEmptyDescriptionValidationMessage successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyDescriptionValidationMessage"), "Exception in ValidateEmptyDescriptionValidationMessage");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"An error message should display for empty description")]
        public void ThenAnErrorMessageShouldDisplayForEmptyDescription()
        {
            //------Validating error message for description
            try
            {
                AddShareSkillStepsObj.ValidateEmptyDescriptionValidationMessage();
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyDescriptionValidationMessage"), "Exception in ValidateEmptyDescriptionValidationMessage");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }
    }
}
