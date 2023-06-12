using PageObject.Duckduckgo.Pages;

using TestCases.Initializers;
using TestCases.Initializers.Setups;

namespace TestCases.Duckduckgo
{
    public class DuckduckgoTests : BaseSetup
    {
        private BrowserConfig browserConfig;

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
            Driver = browserConfig.InitializeBrowser(testData[0]);
            Homepage homepage = new(Driver!);

            //act
            homepage.GoToHomePage();
            homepage.SearchBox!.SendKeys(testData[1]);
            homepage.SearchBox!.SendKeys(Keys.Enter);

            bool webResult = Driver.FindElement(By.XPath($"(//span[contains(.,'{testData[1]}')])[1]"), WaitForElement.Visible).WaitToBeVisible();

            //assert
            webResult.Should().BeTrue();
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

                yield return new string[]
                {
                    browser, testData2
                };
            }
        }
    }
}