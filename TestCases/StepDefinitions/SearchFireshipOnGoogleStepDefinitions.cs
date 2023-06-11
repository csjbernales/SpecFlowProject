using PageObjectModel.Google;

namespace TestCases.StepDefinitions
{
    [Binding]
    public class SearchFireshipOnGoogleStepDefinitions : BaseClass
    {
        [Given(@"Launch browser and navigate to https://www.google.com")]
        public void GivenLaunchBrowser()
        {
            driver!.Manage().Window.Maximize();
        }

        [When(@"Webpage is on (.*)")]
        public void WhenWebpageIsOnGoogle_Com(string url)
        {
            driver!.Navigate().GoToUrl(url);
        }

        [Then(@"search (.*) on searchbar")]
        public void ThenSearchFireshipOnSearchbar(string keyword)
        {
            GoogleHomepage homepage = new(driver!);
            Util.TextThenEnter(homepage.SearchBox!, keyword);

            driver.FindElement(By.XPath($"(//span[contains(.,'{keyword}')])[1]"), WaitForElement.Visible);
        }
    }
}