using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ShareSkillOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.AssertHelpers;

namespace SpecFlowProject.Services.ShareSkillServices
{
    public class AddShareSkillService : CommonDriver
    {
        AddShareSkillComponent AddShareSkillComponentObj;
        ShareSkillComponent ShareSkillComponentObj;

        public AddShareSkillService()
        {
            ShareSkillComponentObj = new ShareSkillComponent();
            AddShareSkillComponentObj = new AddShareSkillComponent();
        }
        public void AddShareSkill(string skillPath)
        {
            //--------Add a skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                ShareSkillComponentObj.ClickShareSkillButton();
                AddShareSkillComponentObj.AddShareSkill(skill);
            }
        }
        public void AddInvalidShareSkill(string skillPath)
        {
            //--------Add an invalid skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            foreach (var skill in skillList)
            {
                ShareSkillComponentObj.ClickShareSkillButton();
                AddShareSkillComponentObj.AddShareSkill(skill);
                CommonMethods.AddScreenCapture(driver, "AddInvalidShareSkill");
                ValidateInvalidMessage();
            }
        }
        public void AddSkillWithEmptyTitle(string skillPath)
        {
            //--------Add a skill with empty title--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            ShareSkillComponentObj.ClickShareSkillButton();
            AddShareSkillComponentObj.AddShareSkill(skillList[0]);
            CommonMethods.AddScreenCapture(driver, "AddSkillWithEmptyTitle");
        }
        public void AddSkillWithEmptyDescription(string skillPath)
        {
            //--------Add a skill with empty description--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            ShareSkillComponentObj.ClickShareSkillButton();
            AddShareSkillComponentObj.AddShareSkill(skillList[0]);
            CommonMethods.AddScreenCapture(driver, "AddSkillWithEmptyDescription");
        }
        public void AddShareSkillWithPastEndDate(string skillPath)
        {
            //--------Add a skill with past end date--------

            string expectedMessage = "Start Date shouldn't be greater than End Date";
            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            ShareSkillComponentObj.ClickShareSkillButton();
            AddShareSkillComponentObj.AddShareSkillWithPastEndDate(skillList[0]);
            CommonMethods.AddScreenCapture(driver, "AddShareSkillWithPastEndDate");
            ValidateInvalidMessage();
            ValidateValidationMessage(expectedMessage);
        }
        public void CancelAddShareSkill(string skillPath)
        {
            //--------Cancel adding a skill--------

            List<SkillModel> skillList = JsonReader.GetData<SkillModel>(skillPath);
            ShareSkillComponentObj.ClickShareSkillButton();
            AddShareSkillComponentObj.CancelAddShareSkill(skillList[0]);
        }
        public void ValidateInvalidMessage()
        {
            //--------Validate an invalid message--------

            string expectedMessage = "Please complete the form correctly.";
            string actualMessage = AddShareSkillComponentObj.GetMessage();
            ShareSkillAssertHelper.AssertInvalidSkillMessage(expectedMessage, actualMessage);
        }
        public void ValidateEmptyTitleValidationMessage()
        {
            //--Validate validation error message for empty title--

            string expectedMessage = "Title is required";
            ValidateInvalidMessage();
            ValidateValidationMessage(expectedMessage);
        }
        public void ValidateEmptyDescriptionValidationMessage()
        {
            //--Validate validation error message for empty description--

            string expectedMessage = "Description is required";
            ValidateInvalidMessage();
            ValidateValidationMessage(expectedMessage);
        }
        public void ValidateValidationMessage(string expectedMessage)
        {
            //----Validate validation message--

            string expected = expectedMessage;
            string actual = AddShareSkillComponentObj.GetValidationMessage();
            ShareSkillAssertHelper.AssertValidationMessage(expected, actual);
        }
    }
}
