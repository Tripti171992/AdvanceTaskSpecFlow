using SpecFlowProject.Model;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages.Components.ShareSkillOverview;
using SpecFlowProject.Pages;
using NUnit.Framework;
using SpecFlowProject.Pages.Components.SkillDetails;

namespace SpecFlowProject.Steps.ShareSkillSteps
{
    public class SkillDetailsSteps
    {
        SkillDetailsComponent SkillDetailsComponentObj;
        public SkillDetailsSteps()
        {
            SkillDetailsComponentObj = new SkillDetailsComponent();
        }
        public void ValidateSkillTitle(SkillModel skill)
        {
            //--------Validate a skill title---
            try
            {
                //Verify the title of the page  
                string expectedTitle = skill.title;
                string actualTitel = SkillDetailsComponentObj.GetSkillTitle();
                Assert.AreEqual(expectedTitle, actualTitel, "Actual and expected title do not match.");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
    }
}
