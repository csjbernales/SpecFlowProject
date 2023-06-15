using PageObject.Duckduckgo.Pages;

using TestCases.Initializers;
using TestCases.Initializers.Setups;

using TestFramework;

namespace TestCases.Duckduckgo
{
    public class DuckduckgoTests2 : BaseSetup
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
            homepage.SettingsButton!.ClickWhenReady();
            homepage.FontsizeDropdown!.SelectFromDropdown("Small");

            bool webResult = Driver!.PageSource.Contains(testData[1]);

            //assert
            webResult.Should().BeTrue();
        }

        private static IEnumerable<string[]> RunOnSpecifiedBrowser()
        {
            string testData1 = "FIRESHIP";

            Settings ??= Configuration.GetSettingsConfig();
            foreach (string browser in Settings.Value.BrowserList!)
            {
                yield return new string[]
                {
                    browser, testData1
                };
            }
        }
    }
}