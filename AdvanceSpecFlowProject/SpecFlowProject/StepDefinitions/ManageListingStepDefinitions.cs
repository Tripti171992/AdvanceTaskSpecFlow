using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;
using SpecFlowProject.Services.ShareSkillServices;
using SpecFlowProject.Services;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ManageListingStepDefinitions : CommonDriver
    {
        HomePageService HomePageServiceObj;
        AddShareSkillService AddShareSkillServiceObj;
        ManageListingsComponentService ManageListingsComponentServiceObj;
        public ManageListingStepDefinitions()
        {
            HomePageServiceObj = new HomePageService();
            AddShareSkillServiceObj = new AddShareSkillService();
            ManageListingsComponentServiceObj = new ManageListingsComponentService();
        }

        [When(@"I deleted skill '([^']*)'")]
        public void WhenIDeletedSkill(string skillPath)
        {
            //-- Delete Skill--

            AddShareSkillServiceObj.AddShareSkill(skillPath);
            ManageListingsComponentServiceObj.DeleteShareSkill(skillPath);
        }

        [Then(@"A skill '([^']*)' should get deleted")]
        public void ThenASkillShouldGetDeleted(string skillPathl)
        {
            //------Validating skill deleted----------

            ManageListingsComponentServiceObj.ValidateSkillDeleted(skillPathl);
        }

        [When(@"I updated a skill '([^']*)' detail to new skilldetails '([^']*)'")]
        public void WhenIUpdatedASkillDetailToNewSkilldetails(string oldSkillPath, string newSkillPath)
        {
            //------Updating skill details------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(oldSkillPath);
            AddShareSkillServiceObj.AddShareSkill(oldSkillPath);
            ManageListingsComponentServiceObj.UpdateSkillDetails(newSkillPath);
        }

        [Then(@"A skill '([^']*)' should get updated")]
        public void ThenASkillShouldGetUpdated(string newSkillPath)
        {
            //------Validating skill details updated------

            ManageListingsComponentServiceObj.ValidateSkillUpdated(newSkillPath);
        }

        [When(@"I updated a skill '([^']*)' detail to new invalid skilldetails '([^']*)'")]
        public void WhenIUpdatedASkillDetailToNewInvalidSkilldetails(string oldSkillPath, string newSkillPath)
        {
            //------Updating invalid skill details------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(oldSkillPath);
            AddShareSkillServiceObj.AddShareSkill(oldSkillPath);
            ManageListingsComponentServiceObj.UpdateInvalidSkillDetails(newSkillPath);
        }

        [Then(@"A skill '([^']*)' should not get updated")]
        public void ThenASkillShouldNotGetUpdated(string skillPath)
        {
            //------validating invalid skill details not updated------

            ManageListingsComponentServiceObj.ValidateSkillNotUpdated(skillPath);
        }

        [Then(@"Skill'([^']*)' status should get changed to active on activation")]
        public void ThenSkillStatusShouldGetChangedToActiveOnActivation(string skillPath)
        {
            //------Activate skill details------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(skillPath);
            AddShareSkillServiceObj.AddShareSkill(skillPath);
            ManageListingsComponentServiceObj.ActivateShareSkill(skillPath);
        }

        [Then(@"Skill'([^']*)' status should get changed to deactive on deactivation")]
        public void ThenSkillStatusShouldGetChangedToDeactiveOnDeactivation(string skillPath)
        {
            //------Deactivate skill details------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(skillPath);
            AddShareSkillServiceObj.AddShareSkill(skillPath);
            ManageListingsComponentServiceObj.DeactivateShareSkill(skillPath);
        }

        [Then(@"I navigated to next page on clicking on next page")]
        public void ThenINavigatedToNextPageOnClickingOnNextPage()
        {
            //------Navigate to next page------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.NavigateToNextPage();
        }

        [Then(@"I navigated to previous page on clicking on previous page")]
        public void ThenINavigatedToPreviousPageOnClickingOnPreviousPage()
        {
            //------Navigate to previous page------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.NavigateToPreviousPage();
        }

        [Then(@"I was nevigated to skill'([^']*)' details page on clicking on watch icon")]
        public void ThenIWasNevigatedToSkillDetailsPageOnClickingOnWatchIcon(string skillPath)
        {
            //------Watch skill details------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(skillPath);
            AddShareSkillServiceObj.AddShareSkill(skillPath);
            ManageListingsComponentServiceObj.WatchSkillDetails(skillPath);
        }

        [When(@"I cancel deleting skill '([^']*)'")]
        public void WhenICancelDeletingSkill(string skillPath)
        {
            //------Cancel deleting skill------

            HomePageServiceObj.ClickManageListingsTab();
            ManageListingsComponentServiceObj.DeleteShareSkill(skillPath);
            AddShareSkillServiceObj.AddShareSkill(skillPath);
            ManageListingsComponentServiceObj.CancelDeleteShareSkill(skillPath);
        }

        [Then(@"A skill '([^']*)' should not get deleted")]
        public void ThenASkillShouldNotGetDeleted(string skillPath)
        {
            //------Validating skill not deleted----------

            ManageListingsComponentServiceObj.ValidateSkillNotDeleted(skillPath);
        }
    }
}
