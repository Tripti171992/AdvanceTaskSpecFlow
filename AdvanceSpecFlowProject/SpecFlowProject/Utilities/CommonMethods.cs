using OpenQA.Selenium;
using SpecFlowProject.Hooks;
using System.Text;

namespace SpecFlowProject.Utilities
{
    public class CommonMethods
    {
        //Screenshots
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName)
        {
            var folderLocation = (ConstantUtils.ScreenshotPath);

            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            fileName.Append(".jpeg");
            screenShot.SaveAsFile(fileName.ToString());
            return fileName.ToString();
        }

        //Add screenshot to report
        public static void AddScreenCapture(IWebDriver driver, string screeShotFileName)
        {
            Hook.test.AddScreenCaptureFromPath(SaveScreenshot(driver, screeShotFileName));
        }
    }
}
