using SpecFlowProject.Services.DescriptionServices;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class DescriptionStepDefinitions : CommonDriver
    {
        ActionOnDescriptionService ActionOnDescriptionServiceObj;
        DescriptionOverviewService DescriptionOverviewServiceObj;
        public DescriptionStepDefinitions()
        {
            ActionOnDescriptionServiceObj = new ActionOnDescriptionService();
            DescriptionOverviewServiceObj = new DescriptionOverviewService();
        }

        [When(@"I added description '([^']*)'")]
        public void WhenIAddedDescription(string descriptionPath)
        {
            //-- Add description--

            ActionOnDescriptionServiceObj.AddUpdateDescription(descriptionPath);
        }

        [Then(@"A description '([^']*)' should get added")]
        public void ThenADescriptionShouldGetAdded(string descriptionPath)
        {
            //---------Validate description added---

            DescriptionOverviewServiceObj.ValidateDesciption(descriptionPath);
        }

        [When(@"I updated description '([^']*)'")]
        public void WhenIUpdatedDescription(string descriptionPath)
        {
            //-- Update description--

            ActionOnDescriptionServiceObj.AddUpdateDescription(descriptionPath);
        }

        [Then(@"A description '([^']*)' should get updated")]
        public void ThenADescriptionShouldGetUpdated(string descriptionPath)
        {
            //---------Validate description updated---

            DescriptionOverviewServiceObj.ValidateDesciption(descriptionPath);
        }

        [When(@"I added out of limit description '([^']*)'")]
        public void WhenIAddedOutOfLimitDescription(string descriptionPath)
        {
            //-- Add out of limit description--

            ActionOnDescriptionServiceObj.AddUpdateOutOfLimitDescription(descriptionPath);
        }

        [Then(@"A out of limit description '([^']*)' not should get added")]
        public void ThenAOutOfLimitDescriptionNotShouldGetAdded(string descriptionPath)
        {
            //---------Validate out of limit description not added---

            DescriptionOverviewServiceObj.ValidateOutOfLimitDesciption(descriptionPath);
        }

        [When(@"I updated out of limit description '([^']*)'")]
        public void WhenIUpdatedOutOfLimitDescription(string descriptionPath)
        {
            //-- Update out of limit description--

            ActionOnDescriptionServiceObj.AddUpdateOutOfLimitDescription(descriptionPath);
        }

        [Then(@"A out of limit description '([^']*)' not should get updated")]
        public void ThenAOutOfLimitDescriptionNotShouldGetUpdated(string descriptionPath)
        {
            //---------Validate out of limit description not update---

            DescriptionOverviewServiceObj.ValidateOutOfLimitDesciption(descriptionPath);
        }
    }
}

