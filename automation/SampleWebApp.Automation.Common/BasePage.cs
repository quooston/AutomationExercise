using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;

// The reference to the Selenium WebDriver namespaces.

namespace SampleWebApp.Automation.Common
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage()
        {
            // Empty constructor...
        }

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void MaximiseWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public void NavigateTo(Uri url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void SaveScreenshot(string filename)
        {
            string parentDirectory = null;
            var directoryInfo = new DirectoryInfo(filename).Parent;
            if (directoryInfo != null)
                parentDirectory = directoryInfo.FullName;

            if ((parentDirectory != null) && !Directory.Exists(parentDirectory))
                Directory.CreateDirectory(parentDirectory);
            ((ITakesScreenshot) Driver).GetScreenshot().SaveAsFile(filename, ImageFormat.Png);
        }
    }
}