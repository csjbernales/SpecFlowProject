using PageObject.Google.Actions;

namespace PageObject.Google.Pages
{
    public class Homepage : HomepageActions
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@title='Search']")]
        public IWebElement? SearchBox { get; set; }

        public Homepage(IWebDriver webDriver)
        {
            this.WebDriver ??= webDriver;
            PageFactory.InitElements(this.WebDriver, this);
        }
    }
}