using PageObjectModel.Youtube;

using System;
using TechTalk.SpecFlow;

namespace TestCases.StepDefinitions
{
    [Binding]
    public class YoutubeSearchStepDefinitions : BaseClass
    {
        [Given(@"Launch browser and navigate to https://www.youtube.com")]
        public void GivenLaunchBrowser()
        {
            driver!.Manage().Window.Maximize();
        }

        [When(@"Webpage is on (.*)")]
        public void WhenWebpageIsOnYoutube_Com(string url)
        {
            driver!.Navigate().GoToUrl(url);
        }

        [Then(@"search (.*) on searchbar")]
        public void ThenSearchFireshipOnSearchbar(string keyword)
        {
            YoutubeHomepage homepage = new(driver!);
            Util.TextThenEnter(homepage.SearchBox!, keyword);

            driver.FindElement(By.XPath($"(//span[contains(.,'{keyword}')])[1]"), WaitForElement.Exists);
        }
    }
}