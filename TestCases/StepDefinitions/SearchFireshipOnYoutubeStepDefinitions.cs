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

        [When(@"Webpage is on (.*)")]
        public void WhenWebpageIsOnGoogle_Com(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [Then(@"search (.*) on searchbar")]
        public void ThenSearchFireshipOnSearchbar(string keyword)
        {
            IHomepage homepage = new Homepage(driver);
            TextThenEnter(keyword, homepage);

            driver.FindElement(By.XPath("//div/div/span[text()='Fireship'][1]"), WaitForElement.Visible);
        }
    }
}