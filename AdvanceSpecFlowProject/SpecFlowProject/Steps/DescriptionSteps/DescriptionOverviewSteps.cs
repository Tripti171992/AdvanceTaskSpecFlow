using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.DescriptionOverview;
using NUnit.Framework;

namespace SpecFlowProject.Steps.DescriptionSteps
{
    public class DescriptionOverviewSteps
    {
        DescriptionOverviewComponent DescriptionOverviewComponentObj;
        public DescriptionOverviewSteps()
        {
            DescriptionOverviewComponentObj = new DescriptionOverviewComponent();
        }
        public void ValidateDesciption(DescriptionModel description)
        {
            try
            {

                //--------Verify the description added.--------
                string newAddedDescription = DescriptionOverviewComponentObj.GetAddedUpdatedDescription();
                Assert.AreEqual(description.description, newAddedDescription, "Actual and expected message do not match. Description not added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateOutOfLimitDesciption(DescriptionModel description)
        {
            try
            {
                //--------Verify the out of limit description added.--------
                string newAddedDescription = DescriptionOverviewComponentObj.GetAddedUpdatedDescription();
                Assert.AreNotEqual(description.description, newAddedDescription, "Actual and expected message match. Description added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }

    }
}

