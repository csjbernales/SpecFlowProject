using OpenQA.Selenium.DevTools.V112.CSS;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using Selenium.DefaultWaitHelpers;

namespace TestFramework
{
    public static class Utils
    {
        public static IWebDriver? WebDriver { get; set; }

        public static bool WaitToBeVisible(this IWebElement webElement)
        {
            WebElementWait wait = new(webElement, TimeSpan.FromSeconds(20));
            return wait.Until(ExpectedConditionsSearchContext.ElementToBeClickable(webElement)).Displayed;
        }

        public static void ClickWhenReady(this IWebElement webElement)
        {
            if (webElement.Displayed && webElement.Enabled)
            {
                webElement.Click();
            }
        }

        public static void ClickWhenReady(this By webElement)
        {
            IWebElement elem = WebDriver.FindElement(webElement, WaitForElement.Visible);
            elem.ClickWhenReady();
        }

        public static void SelectFromDropdown(this IWebElement dropdown, string dropdownItem)
        {
            var elem = new SelectElement(dropdown);
            elem.SelectByText(dropdownItem);
        }

        public static void SelectFromDropdown(this By dropdown, string dropdownItem)
        {
            IWebElement elem = WebDriver.FindElement(dropdown, WaitForElement.Visible);
            elem.SelectFromDropdown(dropdownItem);
        }
    }
}