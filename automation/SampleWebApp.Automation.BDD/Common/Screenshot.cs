using System;
using System.IO;
using SampleWebApp.Automation.Common;
using TechTalk.SpecFlow;

namespace SampleWebApp.Automation.BDD.Common
{
    [Binding]
    public class Screenshot
    {
        private readonly WebDriver _webDriver;

        public Screenshot(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [AfterStep]
        public void TakeScreenshotAfterEachStep()
        {
            var tempFileName =
                Path.Combine(Directory.GetCurrentDirectory(),
                    Path.GetFileNameWithoutExtension(Path.GetTempFileName())) +
                Constants.PngFileExt;
            var basePage = new BasePage(_webDriver.Current);
            basePage.SaveScreenshot(tempFileName);
            Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
        }
    }
}