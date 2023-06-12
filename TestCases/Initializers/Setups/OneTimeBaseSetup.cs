using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

[assembly: LevelOfParallelism(20)]

namespace TestCases.Initializers.Setups
{
    public class OneTimeBaseSetup
    {
        public static AppsettingsConfig? AppConfig { get; set; } = null;
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
                    chromeOptions.AddArguments(AppConfig!.Value.ChromeConfig);
                    Driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    FirefoxOptions firefoxOptions = new();
                    firefoxOptions.AddArguments(AppConfig!.Value.FirefoxConfig);
                    Driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    EdgeOptions edgeOptions = new();
                    edgeOptions.AddArguments(AppConfig!.Value.EdgeConfig);
                    Driver = new EdgeDriver(edgeOptions);
                    break;
            }

            Driver!.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            return Driver;
        }
    }
}