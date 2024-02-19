using SpecFlowProject.Model;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.DescriptionOverview;
using SpecFlowProject.Pages.Components.SignInOverview;
using SpecFlowProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Steps.DescriptionSteps
{
    public class ActionOnDescriptionSteps
    {
        DescriptionOverviewComponent DescriptionOverviewComponentObj;
        ActionOnDescriptionComponent ActionOnDescriptionComponentObj;

        public ActionOnDescriptionSteps()
        {
            DescriptionOverviewComponentObj = new DescriptionOverviewComponent();
            ActionOnDescriptionComponentObj = new ActionOnDescriptionComponent();
        }
        public void AddUpdateDescription(DescriptionModel description)
        {
            //-----------add/update description record---------
            try
            {
                DescriptionOverviewComponentObj.ClickDescriptionWriteIcon();
                ActionOnDescriptionComponentObj.AddUpdateDescription(description);
                //Verifying success message for addition of description
                string expectedMessage = "Description has been saved successfully";
                string actualMessage = ActionOnDescriptionComponentObj.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match. Description not added/updated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void AddUpdateOutOfLimitDescription(DescriptionModel description)
        {
            //-----------add/update out of limit description record---------
            try
            {
                DescriptionOverviewComponentObj.ClickDescriptionWriteIcon();
                ActionOnDescriptionComponentObj.AddUpdateOutOfLimitDescription(description);
                //Verify the description entered
                string newEnteredDescription = ActionOnDescriptionComponentObj.GetEnteredDescription();
                Assert.AreNotEqual(description.description, newEnteredDescription, "Actual and expected message match. Whole description entered!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
