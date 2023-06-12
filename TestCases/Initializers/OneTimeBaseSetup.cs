using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

[assembly: LevelOfParallelism(25)]

namespace TestCases.Initializers
{
    public class OneTimeBaseSetup
    {
        public static AppsettingsConfig? AppsettingsConfig { get; set; } = null;
        public IWebDriver? Driver { get; set; } = null;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("Test start");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver!.Quit();
        }

#pragma warning disable NUnit1028 // The non-test method is public
        public IWebDriver InitializeBrowser(string browserType)
#pragma warning restore NUnit1028 // The non-test method is public
        {
            switch (browserType)
            {
                case "chrome":
                    ChromeOptions chromeOptions = new();
                    chromeOptions.AddArguments(AppsettingsConfig.ChromeConfig);
                    Driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    FirefoxOptions firefoxOptions = new();
                    firefoxOptions.AddArguments(AppsettingsConfig.FirefoxConfig);
                    Driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    EdgeOptions edgeOptions = new();
                    edgeOptions.AddArguments(AppsettingsConfig.EdgeConfig);
                    Driver = new EdgeDriver(edgeOptions);
                    break;
            }

            Driver!.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return Driver;
        }

#pragma warning disable NUnit1028 // The non-test method is public
        public static IEnumerable<string> RunOnSpecifiedBrowser()
#pragma warning restore NUnit1028 // The non-test method is public
        {
            AppsettingsConfig ??= Configuration.GetTestConfig();
            foreach (var browser in AppsettingsConfig.BrowsersToRun!)
            {
                yield return browser;
            }
        }
    }
}