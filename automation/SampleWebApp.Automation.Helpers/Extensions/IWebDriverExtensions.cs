using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SampleWebApp.Automation.Helpers.Configuration;

namespace SampleWebApp.Automation.Helpers.Extensions
{
    public static class WebDriverExtensions
    {
        // Clear a text field and then send the required text
        public static void SendKeys(this IWebElement element, string text, bool clearFirst = true)
        {
            if (clearFirst)
                element.Clear();

            element.SendKeys(text);
        }

        // Return the text in the entire page without any HTML code
        public static string GetText(this IWebDriver driver)
        {
            return driver.FindElement(By.TagName("body")).Text;
        }

        // Test of existence of an element
        public static bool HasElement(this IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        public static IWebElement GetParent(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

        public static void MoveTo(this IWebDriver driver, By locator)
        {
            var element = driver.FindElement(locator);
            var builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }

        public static void MoveTo(this IWebElement element)
        {
            var driver = ((IWrapsDriver) element).WrappedDriver;
            var builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }

        public static void MoveAndClick(this IWebDriver driver, By locator)
        {
            var element = driver.FindElement(locator);
            var builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
            // TODO: It sometimes does not work with IE. In IE, mouse cursor
            // does not stay on element.
            //IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            //if (javascript != null)
            //{
            //    string jsCommand = "return $(\"a:contains(" + element.Text + ")\").mouseover();";
            //    javascript.ExecuteScript(jsCommand);
            //}
            element.Click();
        }

        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null) && element.Displayed && element.Enabled ? element : null;
            };
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            wait.Until(ElementIsClickable(locator));
        }

        public static void MoveAndClick(this IWebElement element)
        {
            var driver = ((IWrapsDriver) element).WrappedDriver;
            var builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
            element.Click();
        }

        // This is a workaround solution only for Firefox where if the browser window
        // is not in full size a popup will open half way outside the visible area.
        // When fire a .Click(), it does nothing because the link to click is outside
        // of the viewed area. This is to force the browser to scroll so that the element
        // is in view.
        public static IWebElement FindElementOnPage(this IWebDriver driver, By locator)
        {
            var element = (RemoteWebElement) driver.FindElement(locator);
            var forceBrowsertoScroll = element.LocationOnScreenOnceScrolledIntoView;
            return element;
        }

        // This method finds a select element and then selects
        // the option element using the visible text.
        // Please note that in the SelectElement Constructor, a check is made that the given
        // element is, indeed, a SELECT tag. If it is not, then an UnexpectedTagNameException
        // is thrown.
        public static void SelectOptionByText(this IWebDriver driver, By locator, string text)
        {
            var select = new SelectElement(driver.FindElement(locator));
            select.SelectByText(text);
        }

        public static string GetSelectedOptionText(this IWebDriver driver, By locator)
        {
            var select = new SelectElement(driver.FindElement(locator));
            return select.SelectedOption.Text;
        }

        public static IList<string> GetAllOptionTexts(this IWebDriver driver, By locator)
        {
            IList<string> optionTexts = new List<string>();
            var select = new SelectElement(driver.FindElement(locator));
            foreach (var option in select.Options)
                optionTexts.Add(option.Text);
            return optionTexts;
        }

        // Wait for the specified element to present
        public static void WaitForElementToPresent(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        // Wait for the specified element to present and become visible
        public static void WaitForElementToBeVisible(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Wait for the element text to present
        public static void WaitForElementTextToPresent(this IWebDriver driver, By locator, string text)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(d => d.FindElement(locator).Text.Trim().Contains(text));
        }

        // Wait for Alert to appear and get it.
        public static IAlert WaitAndGetAlert(this IWebDriver driver)
        {
            IAlert alert = null;

            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            try
            {
                alert = wait.Until(d =>
                {
                    try
                    {
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        return null;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                alert = null;
            }
            catch (Exception)
            {
                throw;
            }

            return alert;
        }

        // Wait for new title to appear
        public static void WaitForTitleToAppear(this IWebDriver driver, string title)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            wait.Until(ExpectedConditions.TitleIs(title));
        }

        // Wait for a case-sensitive substring of the title to appear
        public static void WaitForSubTitleToAppear(this IWebDriver driver, string subTitle)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);
            wait.Until(ExpectedConditions.TitleContains(subTitle));
        }

        // Wait until the page finishes loading
        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, ConfigurationHelpers.PageTimeout);

            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("Driver must support javascript execution", nameof(driver));

            wait.Until(d =>
            {
                try
                {
                    var readyState = javascript.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException ex)
                {
                    // Window is no longer available
                    return ex.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException ex)
                {
                    // Browser is no longer available
                    return ex.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        // Parse GetAttribute text into other types
        public static T GetAttributeAsType<T>(this IWebElement element, string attributeName)
        {
            var text = element.GetAttribute(attributeName) ?? string.Empty;
            return (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(text);
        }
    }
}