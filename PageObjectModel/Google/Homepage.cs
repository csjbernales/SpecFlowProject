namespace PageObjectModel.Google
{
    public class Homepage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@title='Search']")]
        public IWebElement SearchBox { get; set; }

        private IWebDriver webDriver;

        public Homepage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
    }
}