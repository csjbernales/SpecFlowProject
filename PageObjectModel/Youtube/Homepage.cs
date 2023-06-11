namespace PageObjectModel.Youtube
{
    public class Homepage
    {
        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement? SearchBox { get; set; }

        private readonly IWebDriver? webDriver;

        public Homepage(IWebDriver webDriver)
        {
            this.webDriver ??= webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }
    }
}