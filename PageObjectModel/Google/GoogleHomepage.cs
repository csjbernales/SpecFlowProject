namespace PageObjectModel.Google
{
    public class GoogleHomepage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@title='Search']")]
        public IWebElement? SearchBox { get; set; }

        public GoogleHomepage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}