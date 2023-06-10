using PageObjectModel.Google;

namespace TestCases.StepDefinitions
{
    [Binding]
    public class SearchFisreshipOnYoutubeStepDefinitions : BaseClass
    {
        [Given(@"Launch browser")]
        public void GivenLaunchBrowser()
        {
            driver.Manage().Window.Maximize();
        }

        [When(@"Webpage is on google.com")]
        public void WhenWebpageIsOnGoogle_Com()
        {
            driver.Navigate().GoToUrl("https://google.com");
        }

        [Then(@"search fireship on searchbar")]
        public void ThenSearchFireshipOnSearchbar()
        {
            Homepage homepage = new(driver);
            homepage.SearchBox.SendKeys("Fireship");
            homepage.SearchBox.SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//div/div/span[text()='Fireship'][1]"), WaitForElement.Visible);
        }
    }
}