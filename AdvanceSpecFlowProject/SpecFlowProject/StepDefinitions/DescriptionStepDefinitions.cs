using SpecFlowProject.Model;
using SpecFlowProject.Steps;
using SpecFlowProject.Steps.DescriptionSteps;
using SpecFlowProject.Utilities;
using SpecFlowProject.Hooks;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class DescriptionStepDefinitions : CommonDriver
    {
        ActionOnDescriptionSteps ActionOnDescriptionStepsObj;
        DescriptionOverviewSteps DescriptionOverviewStepsObj;
        public DescriptionStepDefinitions()
        {
            ActionOnDescriptionStepsObj = new ActionOnDescriptionSteps();
            DescriptionOverviewStepsObj = new DescriptionOverviewSteps();
        }

        [When(@"I added description '([^']*)'")]
        public void WhenIAddedDescription(string description)
        {
            //-- Add description--
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Adding description
                ActionOnDescriptionStepsObj.AddUpdateDescription(descriptionList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDescription"), "Exception in Add description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A description '([^']*)' should get added")]
        public void ThenADescriptionShouldGetAdded(string description)
        {
            //---------Validate description added---
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Verify the description added
                DescriptionOverviewStepsObj.ValidateDesciption(descriptionList[0]);
                //Attaching screenshot with report
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDescription"), "Add description successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDescription"), "Exception in Add description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I updated description '([^']*)'")]
        public void WhenIUpdatedDescription(string description)
        {
            //-- Update description--
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Updating description
                ActionOnDescriptionStepsObj.AddUpdateDescription(descriptionList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateDescription"), "Exception in update description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A description '([^']*)' should get updated")]
        public void ThenADescriptionShouldGetUpdated(string description)
        {
            //---------Validate description updated---
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Verify the description updated
                DescriptionOverviewStepsObj.ValidateDesciption(descriptionList[0]);
                //Attaching screenshot with report
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateDescription"), "Update description successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateDescription"), "Exception in Update description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I added out of limit description '([^']*)'")]
        public void WhenIAddedOutOfLimitDescription(string description)
        {
            //-- Add out of limit description--
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Adding description
                ActionOnDescriptionStepsObj.AddUpdateOutOfLimitDescription(descriptionList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddOutOfLimitDescription"), "Exception in add out of limit description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A out of limit description '([^']*)' not should get added")]
        public void ThenAOutOfLimitDescriptionNotShouldGetAdded(string description)
        {
            //---------Validate out of limitd escription added---
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Verify the description added
                DescriptionOverviewStepsObj.ValidateOutOfLimitDesciption(descriptionList[0]);
                //Attaching screenshot with report
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddOutOfLimitDescription"), "Add out of limit description successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddOutOfLimitDescription"), "Exception in add out of limit description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [When(@"I updated out of limit description '([^']*)'")]
        public void WhenIUpdatedOutOfLimitDescription(string description)
        {
            //-- Update out of limit description--
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Updating description
                ActionOnDescriptionStepsObj.AddUpdateOutOfLimitDescription(descriptionList[0]);
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateOutOfLimitDescription"), "Exception in update out of limit description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

        [Then(@"A out of limit description '([^']*)' not should get updated")]
        public void ThenAOutOfLimitDescriptionNotShouldGetUpdated(string description)
        {
            //---------Validate out of limitd escription update---
            try
            {
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(description);
                //Verify the description updated
                DescriptionOverviewStepsObj.ValidateOutOfLimitDesciption(descriptionList[0]);
                //Attaching screenshot with report
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateOutOfLimitDescription"), "Update out of limit description successful");
            }
            catch (Exception ex)
            {
                Hook.test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateOutOfLimitDescription"), "Exception in update out of limit description");
                Hook.test.Fail(ex.Message);
                Assert.Fail();
            }
        }

    }
}
