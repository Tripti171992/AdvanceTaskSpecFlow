using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.DescriptionOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services.DescriptionServices
{
    public class DescriptionOverviewService : CommonDriver
    {
        DescriptionOverviewComponent DescriptionOverviewComponentObj;
        public DescriptionOverviewService()
        {
            DescriptionOverviewComponentObj = new DescriptionOverviewComponent();
        }
        public void ValidateDesciption(string descriptionPath)
        {
            //--------Verify the description added/updated--------

            List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(descriptionPath);
            string newAddedDescription = DescriptionOverviewComponentObj.GetAddedUpdatedDescription();
            DescriptionAssertHelper.AssertDescriptionAddedUpdated(descriptionList[0].description, newAddedDescription);
            CommonMethods.AddScreenCapture(driver, "ValidateAddUpdateDescription");
        }
        public void ValidateOutOfLimitDesciption(string descriptionPath)
        {
            //--------Verify the out of limit description added/updated--------

            List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(descriptionPath);
            string newAddedDescription = DescriptionOverviewComponentObj.GetAddedUpdatedDescription();
            DescriptionAssertHelper.AssertDescriptionNotAddedUpdated(descriptionList[0].description, newAddedDescription);
            CommonMethods.AddScreenCapture(driver, "ValidateOutOfLimitDesciption");
        }

    }
}

