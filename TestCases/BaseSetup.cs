using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestCases
{
    [Parallelizable]
    public class BaseSetup : OneTimeBaseSetup
    {
        public IWebDriver Init(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    Driver = new ChromeDriver();
                    break;

                case "firefox":
                    Driver = new FirefoxDriver();
                    break;

                case "edge":
                    Driver = new EdgeDriver();
                    break;
            }
            Driver!.Manage().Window.Maximize();
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return Driver;
        }

        [TearDown]
        public void TearDown()
        {
            Driver!.Close();
            Console.WriteLine("TearDown");
        }

        public static IEnumerable<string> RunOnSpecifiedBrowser()
        {
            string[] browsers = { "chrome", "firefox", "edge" };

            foreach (string browser in browsers)
            {
                yield return browser;
            }
        }
    }
}