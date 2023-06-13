namespace TestFramework
{
    public static class Utils
    {
        public static bool WaitToBeVisible(this IWebElement webElement)
        {
            WebElementWait wait = new(webElement, TimeSpan.FromSeconds(20));
            return wait.Until(ExpectedConditionsSearchContext.ElementToBeClickable(webElement)).Displayed;
        }
    }
}