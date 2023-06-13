using PageObject.Duckduckgo.Pages;

using TestCases.Initializers;
using TestCases.Initializers.Setups;

namespace TestCases.Duckduckgo
{
    public class DuckduckgoTests9 : BaseSetup
    {
        private BrowserConfig? browserConfig;

        [SetUp]
        public void SetUp()
        {
            browserConfig = new BrowserConfig();
        }

        [Test]
        [TestCaseSource(nameof(RunOnSpecifiedBrowser))]
        public void DSearch(string[] testData)
        {
            //arrange
            Driver = browserConfig!.InitializeBrowser(testData[0]);
            Homepage homepage = new(Driver!);

            //act
            homepage.GoToHomePage();
            homepage.SearchBox!.SendKeys(testData[1]);
            homepage.SearchBox!.SendKeys(Keys.Enter);

            bool webResult = Driver!.PageSource.Contains(testData[1]);

            //assert
            webResult.Should().BeTrue();
        }

        private static IEnumerable<string[]> RunOnSpecifiedBrowser()
        {
            string testData1 = "FIRESHIP";

            Settings ??= Configuration.GetSettingsConfig();

            string[] browserlist = Settings!.Value.BrowsersToRun();
            foreach (string browser in browserlist)
            {
                yield return new string[]
                {
                    browser, testData1
                };
            }
        }
    }
}