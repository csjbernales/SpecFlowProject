using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class SearchFireshipOnYoutubeStepDefinitions
    {
        private IWebDriver? driver;

        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [When(@"Navigated to Youtube.com")]
        public void WhenBrowserIsReady()
        {
            driver!.Url = "http://youtube.com/";
        }

        [Then(@"Search for Fireship")]
        public void ThenNavigateToYoutubeAndSearchForFireship()
        {
            var searchBar = driver!.FindElement(By.XPath("//input[contains(@id,'search')]")); //@FindBy(xpath = "//input[contains(@id,'search')]")
            searchBar.SendKeys("Fireship");
            searchBar.SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            driver.Close();
        }
    }
}