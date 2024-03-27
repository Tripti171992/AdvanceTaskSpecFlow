using NUnit.Framework.Interfaces;
using NUnit.Framework;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports.Reporter;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hook : CommonDriver
    {

        public static ExtentReports extent;
        public static ExtentTest test;
        public Hook()
        {

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentSparkReporter htmlReport = new ExtentSparkReporter(ConstantUtils.ReportsPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Tripti");

            htmlReport.Config.DocumentTitle = "Automation Report";
            htmlReport.Config.ReportName = "Test Report";
            htmlReport.Config.Theme = Theme.Dark;
        }

        [BeforeScenario]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Initialize();
            NavigateUrl();
            test = extent.CreateTest(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {
                test.Pass("Test Case Passed!!");
            }
            else if (status == TestStatus.Failed)
            {
                test.Fail("Test Case Failed!!");

            }
            Close();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }
    }
}