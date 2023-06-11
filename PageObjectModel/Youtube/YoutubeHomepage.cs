namespace PageObjectModel.Google
{
    public class YoutubeHomepage
    {
        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement? SearchBox { get; set; }

        public YoutubeHomepage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}