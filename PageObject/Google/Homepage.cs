namespace PageObject.Google
{
    public class Homepage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@title='Search']")]
        public IWebElement? SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Google']")]
        public IWebElement? Logo { get; set; }

        private const string Url = "https://www.google.com";

        private readonly IWebDriver? webDriver;

        public Homepage(IWebDriver webDriver)
        {
            this.webDriver ??= webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public Homepage? GoToHomePage()
        {
            webDriver!.Navigate().GoToUrl(Url);
            if (Logo!.Displayed)
            {
                Thread.Sleep(250);
                return this;
            }
            else
            {
                return default;
            }
        }
    }
}