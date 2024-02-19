using NUnit.Framework;
using SpecFlowProject.Hooks;
using SpecFlowProject.Model;
using SpecFlowProject.Steps.ShareSkillSteps;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ManageListingStepDefinitions : CommonDriver
    {
        HomePageSteps HomePageStepsObj;
        AddShareSkillSteps AddShareSkillStepsObj;
        ManageListingsComponentSteps ManageListingsComponentStepsObj;
        SkillDetailsSteps SkillDetailsStepsObj;
        public ManageListingStepDefinitions()
        {
            HomePageStepsObj = new HomePageSteps();
            AddShareSkillStepsObj = new AddShareSkillSteps();
            ManageListingsComponentStepsObj = new ManageListingsComponentSteps();
            SkillDetailsStepsObj = new SkillDetailsSteps();
        }
        [When(@"I deleted skill '([^']*)'")]
        public void WhenIDeletedSkill(string userSkill)
        {
            //-- Delete Skill--
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Adding Share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Deleting share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                    ManageListingsComponentStepsObj.ValidateDeleteSkillMessage(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteShareSkill"), "Delete Share Skill successful");
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteShareSkill"), "Exception in delete Share Skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A skill '([^']*)' should get deleted")]
        public void ThenASkillShouldGetDeleted(string userSkill)
        {
            //------Validating skill deleted----------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.ValidateSkillDeleted(skill);
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteShareSkill"), "Exception in validating Skill deleted");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I updated a skill '([^']*)' detail to new skilldetails '([^']*)'")]
        public void WhenIUpdatedASkillDetailToNewSkilldetails(string userSkill, string newSkill)
        {
            //------Updating skill details------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);
                List<SkillModel> newSkillList = JsonReader.GetData<SkillModel>(newSkill);

                //Deleting share skill if exist
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);

                }
                //Adding hidden share skill 
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Update skill details
                foreach (var skill in newSkillList)
                {
                    ManageListingsComponentStepsObj.UpdateSkillDetails(skill);
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateSkillDetails"), "Exception in update skill details");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A skill '([^']*)' should get updated")]
        public void ThenASkillShouldGetUpdated(string newSkill)
        {
            //------Validating skill details updated------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(newSkill);

                //Validate skill details updated
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.ValidateSkillUpdated(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateSkillDetails"), "Update skill details successful");
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateSkillDetails"), "Exception in update skill details validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I updated a skill '([^']*)' detail to new invalid skilldetails '([^']*)'")]
        public void WhenIUpdatedASkillDetailToNewInvalidSkilldetails(string userSkill, string newSkill)
        {
            //------Updating invalid skill details------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);
                List<SkillModel> newSkillList = JsonReader.GetData<SkillModel>(newSkill);

                //Deleting share skill if exist
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
                }
                //Update invalid skill details
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.UpdateSkillDetails(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidSkillDetails"), "Update invalid skill details successful");
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidSkillDetails"), "Exception in update invalid skill details");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A skill '([^']*)' should not get updated")]
        public void ThenASkillShouldNotGetUpdated(string userSkill)
        {
            //------validating invalid skill details updation------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.ValidateSkillNotUpdated(skill);
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidSkillDetails"), "Exception in update invalid skill details validation");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"Skill'([^']*)' status should get changed to active on activation")]
        public void ThenSkillStatusShouldGetChangedToActiveOnActivation(string userSkill)
        {
            //------Activate skill details------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Deleting share skill if exist
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding hidden share skill 
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Activating share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.ActivateShareSkill(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ActivateShareSkill"), "Activate Share Skill successful");
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ActivateShareSkill"), "Exception in activate Share Skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"Skill'([^']*)' status should get changed to deactive on deactivation")]
        public void ThenSkillStatusShouldGetChangedToDeactiveOnDeactivation(string userSkill)
        {
            //------Deactivate skill details------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Deleting share skill if exist
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding active share skill 
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Deactivating share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.DeactivateShareSkill(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeactivateShareSkill"), "Deactivate Share Skill successful");
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeactivateShareSkill"), "Exception in deactivate Share Skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"I navigated to next page on clicking on next page")]
        public void ThenINavigatedToNextPageOnClickingOnNextPage()
        {
            //------Navigate to next page------
            try
            {
                HomePageStepsObj.ClickManageListingsTab();
                ManageListingsComponentStepsObj.NavigateToNextPage();
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToNextPage"), "Navigate to next page successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToNextPage"), "Exception in Navigate to next page");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"I navigated to previous page on clicking on previous page")]
        public void ThenINavigatedToPreviousPageOnClickingOnPreviousPage()
        {
            //------Navigate to previous page------
            try
            {
                HomePageStepsObj.ClickManageListingsTab();
                ManageListingsComponentStepsObj.NavigateToPreviousPage();
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToPreviousPage"), "Navigate to previous page successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToPreviousPage"), "Exception in previous to next page");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"I was nevigated to skill'([^']*)' details page on clicking on watch icon")]
        public void ThenIWasNevigatedToSkillDetailsPageOnClickingOnWatchIcon(string userSkill)
        {
            //------Watch skill details------
            try
            {

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                //Deleting share skill if exist
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding active share skill 
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Watch skill details
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.WatchSkillDetails(skill);
                    SkillDetailsStepsObj.ValidateSkillTitle(skill);
                    Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "WatchShareSkillDetails"), "Watch skill details successful");
                    HomePageStepsObj.ClickManageListingsTab();
                }
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "WatchShareSkillDetails"), "Exception in watch skill details");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I cancel deleting skill '([^']*)'")]
        public void WhenICancelDeletingSkill(string userSkill)
        {
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                HomePageStepsObj.ClickManageListingsTab();

                //Deleting share skill if exist
                ManageListingsComponentStepsObj.DeleteShareSkill(skillList[0]);

                //Adding share skill 
                HomePageStepsObj.ClickShareSkillButton();
                AddShareSkillStepsObj.AddShareSkill(skillList[0]);

                //Cancel delete share skill
                ManageListingsComponentStepsObj.CancelDeleteShareSkill(skillList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelDeleteShareSkill"), "Exception in cancel delete Share Skill");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A skill '([^']*)' should not get deleted")]
        public void ThenASkillShouldNotGetDeleted(string userSkill)
        {

            //------Validating skill not deleted----------
            try
            {
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>(userSkill);

                ManageListingsComponentStepsObj.ValidateSkillNotDeleted(skillList[0]);
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelDeleteShareSkill"), "Skill not deleted validated.");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelDeleteShareSkill"), "Exception in validating Skill not deleted");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }
    }
}
