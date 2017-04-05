using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using SampleWebApp.Automation.Helpers.Configuration;

namespace SampleWebApp.Automation.Common
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver != null)
                    return _currentWebDriver;

                switch (ConfigurationHelpers.WebBrowser)
                {
                    case "Firefox":
                        var firefoxProfile = new FirefoxProfile {AcceptUntrustedCertificates = true};
                        _currentWebDriver = new FirefoxDriver(firefoxProfile);
                        break;
                    case "Internet Explorer":
                    case "IE":
                        _currentWebDriver = new InternetExplorerDriver(new InternetExplorerOptions
                        {
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true
                        });
                        break;
                    case "Chrome":
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddExcludedArgument("ignore-certificate-errors");
                        _currentWebDriver = new ChromeDriver(chromeOptions);
                        break;
                    case "Safari":
                        _currentWebDriver = new SafariDriver();
                        break;
                    default:
                        throw new DriveNotFoundException(
                            $"Your browser '{ConfigurationHelpers.WebBrowser}' is not supported");
                }

                return _currentWebDriver;
            }
        }

        public void Close()
        {
            _currentWebDriver?.Quit();
            _currentWebDriver?.Dispose();
        }
    }
}