using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.SkillDetails;
using SpecFlowProject.AssertHelpers;
using SpecFlowProject.Utilities;

namespace SpecFlowProject.Services.ShareSkillServices
{
    public class SkillDetailsService : CommonDriver
    {
        SkillDetailsComponent SkillDetailsComponentObj;
        public SkillDetailsService()
        {
            SkillDetailsComponentObj = new SkillDetailsComponent();
        }
        public void ValidateSkillTitle(SkillModel skill)
        {
            //--------Validate a skill title---

            string expectedTitle = skill.title;
            string actualTitel = SkillDetailsComponentObj.GetSkillTitle();
            CommonMethods.AddScreenCapture(driver, "ValidateWatchSkillDetails");
            ManageListingHelper.AssertWatchSkillDetail(expectedTitle, actualTitel);
        }
    }
}
