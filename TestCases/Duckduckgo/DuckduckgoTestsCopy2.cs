using PageObject.Duckduckgo.Pages;

using TestCases.Initializers;
using TestCases.Initializers.Setups;

namespace TestCases.Google
{
    public class DuckduckgoTestsCopy2 : BaseSetup
    {
        [Test]
        [TestCaseSource(nameof(RunOnSpecifiedBrowser))]
        public void GSearch(string[] testData)
        {
            //arrange
            Driver = InitializeBrowser(testData[0]);
            Homepage homepage = new(Driver!);

            //act
            homepage.GoToHomePage();
            homepage.SearchBox!.SendKeys(testData[1]);
            homepage.SearchBox!.SendKeys(Keys.Enter);

            IWebElement webResult = Driver.FindElement(By.XPath($"(//span[contains(.,'Fireship')])[1]"), WaitForElement.Exists);

            //assert
            webResult.Should().NotBeNull();
        }

        private static IEnumerable<string[]> RunOnSpecifiedBrowser()
        {
            string testData1 = "Fireship";
            string testData2 = "fireship";
            AppConfig ??= Configuration.GetTestConfig();

            foreach (string browser in AppConfig!.Value.BrowsersToRun!)
            {
                yield return new string[]
                {
                    browser, testData1
                };
            }

            foreach (string browser in AppConfig!.Value.BrowsersToRun!)
            {
                yield return new string[]
                {
                    browser, testData2
                };
            }
        }
    }
}