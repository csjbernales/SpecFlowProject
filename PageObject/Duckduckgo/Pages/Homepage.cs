using PageObject.Duckduckgo.Actions;

namespace PageObject.Duckduckgo.Pages
{
    public class Homepage : HomepageActions
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='searchbox_input']")]
        public IWebElement? SearchBox { get; set; }

        public Homepage(IWebDriver webDriver)
        {
            WebDriver ??= webDriver;
            PageFactory.InitElements(WebDriver, this);
        }
    }
}