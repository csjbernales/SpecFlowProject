using PageObjectModel.Google;

namespace TestCases.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions : BaseClass
    {
        [Given(@"Launch browser and navigate to https://www.google.com")]
        public void GivenLaunchBrowser()
        {
            driver!.Manage().Window.Maximize();
        }

        [When(@"Webpage is on the homepage (.*)")]
        public void WhenWebpageIsOnGoogle_Com(string url)
        {
            driver!.Navigate().GoToUrl(url);
        }

        [Then(@"search (.*) on the searchbar")]
        public void ThenSearchFireshipOnSearchbar(string keyword)
        {
            GoogleHomepage homepage = new(driver!);
            Util.TextThenEnter(homepage.SearchBox!, keyword);

            driver.FindElement(By.XPath($"(//span[contains(.,'{keyword}')])[1]"), WaitForElement.Exists);
        }
    }
}