using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SpecFlowProject.Utilities
{
    public class CommonDriver
    {
        //Initialize the browser
        public static IWebDriver driver;
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();
        }

        //Closing browser
        public void Close()
        {
            driver.Close();
        }

        //Navigating to Mars portal
        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(ConstantUtils.MarsUrl);
        }

        //Refreshing browser
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

    }
}
