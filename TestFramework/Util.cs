namespace TestFramework
{
    public static class Util
    {
        public static IWebElement TextThenEnter(this IWebElement element, string keyword)
        {
            element.SendKeys(keyword);
            element.SendKeys(Keys.Enter);

            return element;
        }
    }
}