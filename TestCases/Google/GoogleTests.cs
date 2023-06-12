using PageObject.Google.Pages;
using TestCases.Initializers.Setups;

namespace TestCases.Google
{
    public class GoogleTests : BaseSetup
    {
        [Test]
        [TestCaseSource(nameof(RunOnSpecifiedBrowser))]
        public void PerformGoogleSearchWithKeywordFireship(string browserType)
        {
            //arrange
            Driver = InitializeBrowser(browserType);
            string searchKeyword = "Fireship";
            Homepage homepage = new(Driver!);

            //act
            homepage.GoToHomePage();
            homepage.SearchBox!.SendKeys(searchKeyword);
            homepage.SearchBox!.SendKeys(Keys.Enter);

            IWebElement webResult = Driver.FindElement(By.XPath($"//div/div/span[text()='{searchKeyword}'][1]"), WaitForElement.Exists);

            //assert
            webResult.Should().NotBeNull();
        }
    }
}