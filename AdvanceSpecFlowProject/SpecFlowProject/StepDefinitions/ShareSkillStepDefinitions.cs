using SpecFlowProject.Services;
using SpecFlowProject.Services.ShareSkillServices;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ShareSkillStepDefinitions : CommonDriver
    {
        HomePageService HomePageServiceObj;
        AddShareSkillService AddShareSkillServiceObj;
        ManageListingsComponentService ManageListingsComponentServiceObj;
        public ShareSkillStepDefinitions()
        {
            HomePageServiceObj = new HomePageService();
            AddShareSkillServiceObj = new AddShareSkillService();
            ManageListingsComponentServiceObj = new ManageListingsComponentService();
        }

        [When(@"I added skill '([^']*)'")]
        public void WhenIAddedSkill(string skillPath)
        {
            //-- Add Skill--

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(skillPath);
            AddShareSkillServiceObj.AddShareSkill(skillPath);
        }

        [Then(@"A skill '([^']*)' should get added")]
        public void ThenASkillShouldGetAdded(string skillPath)
        {
            //------Validating skill addition----------

            ManageListingsComponentServiceObj.ValidateShareSkillAdded(skillPath);
        }

        [When(@"I cancelled adding skill '([^']*)'")]
        public void WhenICancelledAddingSkill(string skillPath)
        {
            //-- Cancel adding Skill--

            AddShareSkillServiceObj.CancelAddShareSkill(skillPath);
        }

        [Then(@"A skill '([^']*)' should not get added")]
        public void ThenASkillShouldNotGetAdded(string skillPath)
        {
            //------Validating skill not added----------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.ValidateShareSkillNotAdded(skillPath);
        }

        [When(@"I add invalid skill '([^']*)'")]
        public void WhenIAddInvalidSkill(string skillPath)
        {
            //--Adding invalid skill--

            AddShareSkillServiceObj.AddInvalidShareSkill(skillPath);
        }

        [When(@"I add skill '([^']*)' with past end date")]
        public void WhenIAddSkillWithPastEndDate(string skillPath)
        {
            //------Add a skill with past end date------

            AddShareSkillServiceObj.AddShareSkillWithPastEndDate(skillPath);
        }

        [When(@"I add skill '([^']*)' with empty title")]
        public void WhenIAddSkillWithEmptyTitle(string skillPath)
        {
            //------Adding skill with empty title------

            AddShareSkillServiceObj.AddSkillWithEmptyTitle(skillPath);
        }

        [Then(@"An error message should display for empty title")]
        public void ThenAnErrorMessageShouldDisplayForEmptyTitle()
        {
            //------Validating error message for empty title----------

            AddShareSkillServiceObj.ValidateEmptyTitleValidationMessage();
        }

        [When(@"I add skill '([^']*)' with empty description")]
        public void WhenIAddSkillWithEmptyDescription(string skillPath)
        {
            //------Adding skill with empty description------

            AddShareSkillServiceObj.AddSkillWithEmptyDescription(skillPath);
        }

        [Then(@"An error message should display for empty description")]
        public void ThenAnErrorMessageShouldDisplayForEmptyDescription()
        {
            //------Validating error message for description

            AddShareSkillServiceObj.ValidateEmptyDescriptionValidationMessage();
        }
    }
}
