

using PageObjectModel.Google;

namespace TestFramework
{
    public class Util
    {
        protected Util()
        {
            
        }

        public static void TextThenEnter<T>(string keyword, T page) where T : IObjectInterface
        {
            page.SearchBox.SendKeys(keyword);
            page.SearchBox.SendKeys(Keys.Enter);
        }
    }
}