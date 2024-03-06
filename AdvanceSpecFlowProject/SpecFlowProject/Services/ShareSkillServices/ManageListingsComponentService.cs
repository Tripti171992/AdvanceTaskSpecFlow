using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileMenuTabNavigationOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services.ShareSkillServices
{
    public class ManageListingsComponentService : CommonDriver
    {
        ManageListingsComponent ManageListingsComponentObj;
        ProfileMenuTabOverviewComponent ProfileMenuTabOverviewComponentObj;
        SkillDetailsService SkillDetailsServiceObj;
        public ManageListingsComponentService()
        {
            ManageListingsComponentObj = new ManageListingsComponent();
            ProfileMenuTabOverviewComponentObj = new ProfileMenuTabOverviewComponent();
            SkillDetailsServiceObj = new SkillDetailsService();
        }
        public void DeleteShareSkill(string skillPath)
        {
            //--------Delete a skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                ManageListingsComponentObj.DeleteShareSkill(skill);
                CommonMethods.AddScreenCapture(driver, "DeleteShareSkill");
                ValidateDeleteSkillMessage(skill);
            }
        }

        public void ValidateDeleteSkillMessage(SkillModel skill)
        {
            //Verify if message is displayed on deleting share skill

            string expectedMessage = skill.title + " has been deleted";
            string actualMessage = ManageListingsComponentObj.GetMessage();
            if (actualMessage.Contains("Timed out after"))
            {
                Console.WriteLine("");
            }
            else
            {
                ManageListingHelper.AssertSkillDeletedMessage(expectedMessage, actualMessage);
            }
        }
        public void ValidateSkillDeleted(string skillPath)
        {
            //Verify the share skill record deleted

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                string result = ManageListingsComponentObj.GetDeleteShareSkillResult(skill);
                CommonMethods.AddScreenCapture(driver, "ValidateDeleteSkill");
                ManageListingHelper.AssertSkillDeleted("Deleted", result);
            }

        }
        public void WatchSkillDetails(string skillPath)
        {
            //--------Watch a skill details--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            ManageListingsComponentObj.WatchSkillDetails(skillList[0]);
            SkillDetailsServiceObj.ValidateSkillTitle(skillList[0]);
        }
        public void UpdateSkillDetails(string skillPathl)
        {
            //--------Update a skill details--

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPathl);
            foreach (var skill in skillList)
            {
                ManageListingsComponentObj.UpdateSkillDetails(skill);
            }
        }
        public void UpdateInvalidSkillDetails(string skillPathl)
        {
            //--------Update a skill details--

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPathl);
            foreach (var skill in skillList)
            {
                ManageListingsComponentObj.UpdateSkillDetails(skill);
                CommonMethods.AddScreenCapture(driver, "UpdateInvalidSkillDetails");
                ProfileMenuTabOverviewComponentObj.ClickManageListingsTab();
            }
        }
        public void ValidateSkillUpdated(string skillPath)
        {
            //--------Validate a skill updation--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                string result = ManageListingsComponentObj.GetUpdateSkillResult(skill);
                CommonMethods.AddScreenCapture(driver, "ValidateUpdateSkillDetails");
                ManageListingHelper.AssertSkillUpdated("Updated", result);
            }
        }
        public void ValidateSkillNotUpdated(string skillPath)
        {
            //--------Validate a skill is not updated----

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                string result = ManageListingsComponentObj.GetUpdateSkillResult(skill);
                CommonMethods.AddScreenCapture(driver, "ValidateSkillNotUpdated");
                ManageListingHelper.AssertSkillNotUpdated("Not updated", result);
            }
        }
        public void CancelDeleteShareSkill(string skillPath)
        {
            //--------Cancell deletig a skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            ManageListingsComponentObj.CancelDeleteShareSkill(skillList[0]);
        }
        public void ValidateSkillNotDeleted(string skillPath)
        {
            //Verify the skill record not deleted

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            string result = ManageListingsComponentObj.GetDeleteShareSkillResult(skillList[0]);
            CommonMethods.AddScreenCapture(driver, "ValidateCancelDeleteSkill");
            ManageListingHelper.AssertSkillNotDeleted("Not Deleted", result);
        }
        public void ActivateShareSkill(string skillPath)
        {
            //--------Activate a skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            string expectedMessage = "Service has been activated";
            ManageListingsComponentObj.ChangeShareSkillStatus(skillList[0]);
            CommonMethods.AddScreenCapture(driver, "ActivateShareSkill");
            string actualMessage = ManageListingsComponentObj.GetMessage();
            ManageListingHelper.AssertSkillActivatedMessage(expectedMessage, actualMessage);
        }
        public void DeactivateShareSkill(string skillPath)
        {
            //--------Deavtivate a skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            string expectedMessage = "Service has been deactivated";
            ManageListingsComponentObj.ChangeShareSkillStatus(skillList[0]);
            CommonMethods.AddScreenCapture(driver, "DeactivateShareSkill");
            string actualMessage = ManageListingsComponentObj.GetMessage();
            ManageListingHelper.AssertSkillDectivatedMessage(expectedMessage, actualMessage);
        }
        public void NavigateToNextPage()
        {
            //--------Navigate to next page----

            int expectedNextPage = ManageListingsComponentObj.GetActivePageNumber() + 1;
            ManageListingsComponentObj.NavigateToNextPage();
            int actualNextPage = ManageListingsComponentObj.GetActivePageNumber();
            CommonMethods.AddScreenCapture(driver, "NavigateToNextPage");
            ManageListingHelper.AssertNextPageNavigation(expectedNextPage, actualNextPage);
        }
        public void NavigateToPreviousPage()
        {
            //--------Navigate to previous page --------

            ManageListingsComponentObj.NavigateToNextPage();
            int expectedPrevioustPage = ManageListingsComponentObj.GetActivePageNumber() - 1;
            ManageListingsComponentObj.NavigateToPreviousPage();
            int actualPreviousPage = ManageListingsComponentObj.GetActivePageNumber();
            CommonMethods.AddScreenCapture(driver, "NavigateToPreviousPage");
            ManageListingHelper.AssertPreviousPageNavigation(expectedPrevioustPage, actualPreviousPage);
        }
        public void ValidateShareSkillAdded(string skillPath)
        {
            //--------Validate askill is added--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                string additionStatus = ManageListingsComponentObj.GetShareSkillAddedStatus(skill);
                ShareSkillAssertHelper.AssertSkillAdded("Added", additionStatus);
                CommonMethods.AddScreenCapture(driver, "AddShareSkill");
            }
        }
        public void ValidateShareSkillNotAdded(string skillPath)
        {
            //--------Validate a skill is not added--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                string additionStatus = ManageListingsComponentObj.GetShareSkillAddedStatus(skill);
                CommonMethods.AddScreenCapture(driver, "ValidateSkillNotAdded");
                ShareSkillAssertHelper.AssertSkillNotAdded("Not Added", additionStatus);
            }

        }
    }
}
