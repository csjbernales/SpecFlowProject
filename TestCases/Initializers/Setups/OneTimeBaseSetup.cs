using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

[assembly: LevelOfParallelism(25)]

namespace TestCases.Initializers.Setups
{
    public class OneTimeBaseSetup
    {
        private static AppsettingsConfig? AppsettingsConfig { get; set; } = null;
        public IWebDriver? Driver { get; set; } = null;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver!.Quit();
        }

        public IWebDriver InitializeBrowser(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                    ChromeOptions chromeOptions = new();
                    chromeOptions.AddArguments(AppsettingsConfig!.Value.ChromeConfig);
                    Driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    FirefoxOptions firefoxOptions = new();
                    firefoxOptions.AddArguments(AppsettingsConfig!.Value.FirefoxConfig);
                    Driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    EdgeOptions edgeOptions = new();
                    edgeOptions.AddArguments(AppsettingsConfig!.Value.EdgeConfig);
                    Driver = new EdgeDriver(edgeOptions);
                    break;
            }

            Driver!.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return Driver;
        }

        public static IEnumerable<string> RunOnSpecifiedBrowser()
        {
            AppsettingsConfig ??= Configuration.GetTestConfig();
            foreach (var browser in AppsettingsConfig.Value.BrowsersToRun!)
            {
                yield return browser;
            }
        }
    }
}