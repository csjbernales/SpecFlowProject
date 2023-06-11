namespace PageObjectModel.Google
{
    public class Homepage : IHomepage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@title='Search']")]
        public IWebElement SearchBox { get; set; }

        public Homepage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}