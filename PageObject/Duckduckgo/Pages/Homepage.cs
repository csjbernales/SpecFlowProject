using PageObject.Duckduckgo.Actions;

namespace PageObject.Duckduckgo.Pages
{
    public class Homepage : HomepageActions
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='searchbox_input']")]
        public IWebElement? SearchBox { get; set; }

        public By SettingsButton = By.XPath("(//a[contains(.,'Settings')])[1]");
        public By FontsizeDropdown = By.Id("setting_ks");

        public Homepage(IWebDriver webDriver)
        {
            WebDriver ??= webDriver;
            PageFactory.InitElements(WebDriver, this);
        }
    }
}