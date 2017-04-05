using TechTalk.SpecFlow;
using SampleWebApp.Automation.Common;

namespace SampleWebApp.Automation.BDD.Common
{
    [Binding]
    public class Browser
    {
        private readonly WebDriver _webDriver;

        public Browser(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [BeforeScenario]
        public void ScenarioSetup()
        {
            var driver = _webDriver.Current;
            var basePage = new BasePage(driver);
            basePage.MaximiseWindow();
            ScenarioContext.Current["WebDriver"] = driver;
            ScenarioContext.Current["BasePage"] = basePage;
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            _webDriver.Close();
        }
    }
}