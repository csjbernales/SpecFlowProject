using PageObject.Google;

namespace TestCases.Google
{
    public class GoogleTests : BaseSetup
    {
        private const string resultTitle = "//div/div/span[text()='Fireship'][1]";

        [Test]
        [TestCaseSource(nameof(RunOnSpecifiedBrowser))]
        public void PerformGoogleSearchWithKeywordFireship(string browser)
        {
            Driver = Init(browser);
            Homepage homepage = new(Driver!);
            homepage.GoToHomePage();
            homepage.SearchBox!.SendKeys("Fireship");
            homepage.SearchBox!.SendKeys(Keys.Enter);

            IWebElement webResult = Driver.FindElement(By.XPath(resultTitle), WaitForElement.Exists);

            webResult.Should().NotBeNull();
        }
    }
}