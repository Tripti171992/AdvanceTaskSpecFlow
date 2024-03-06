using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.DescriptionOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services.DescriptionServices
{
    public class ActionOnDescriptionService : CommonDriver
    {
        DescriptionOverviewComponent DescriptionOverviewComponentObj;
        ActionOnDescriptionComponent ActionOnDescriptionComponentObj;

        public ActionOnDescriptionService()
        {
            DescriptionOverviewComponentObj = new DescriptionOverviewComponent();
            ActionOnDescriptionComponentObj = new ActionOnDescriptionComponent();
        }
        public void AddUpdateDescription(string descriptionPath)
        {
            //-----------add/update description record---------

            List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(descriptionPath);
            DescriptionOverviewComponentObj.ClickDescriptionWriteIcon();
            ActionOnDescriptionComponentObj.AddUpdateDescription(descriptionList[0]);
            //Verifying success message for addition of description
            string expectedMessage = "Description has been saved successfully";
            string actualMessage = ActionOnDescriptionComponentObj.GetMessage();
            DescriptionAssertHelper.AssertDescriptionAddedUpdatedMessage(expectedMessage, actualMessage);
        }
        public void AddUpdateOutOfLimitDescription(string descriptionPath)
        {
            //-----------add/update out of limit description record---------

            List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>(descriptionPath);
            DescriptionOverviewComponentObj.ClickDescriptionWriteIcon();
            ActionOnDescriptionComponentObj.AddUpdateOutOfLimitDescription(descriptionList[0]);
            string newEnteredDescription = ActionOnDescriptionComponentObj.GetEnteredDescription();
            CommonMethods.AddScreenCapture(driver, "AddUpdateOutOfLimitDescription");
            DescriptionAssertHelper.AssertDescriptionEntered(descriptionList[0].description, newEnteredDescription);
        }
    }
}
