using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestCases.StepDefinitions
{
    [Binding]
    public class SearchFireshipOnYoutubeStepDefinitions
    {
        private IWebDriver? driver;

        [Given(@"Open browser")]
        public void GivenOpenBrowser()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [When(@"webpage is on youtube\.com")]
        public void WhenWebpageIsOnYoutube_Com()
        {
            driver!.Url = "http://youtube.com/";
        }

        [Then(@"search fireship on searchbar")]
        public void ThenSearchFireshipOnSearchbar()
        {
            var searchBar = driver!.FindElement(By.XPath("//input[contains(@id,'search')]")); //@FindBy(xpath = "//input[contains(@id,'search')]")
            searchBar.SendKeys("Fireship");
            searchBar.SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            driver.Close();
        }
    }
}