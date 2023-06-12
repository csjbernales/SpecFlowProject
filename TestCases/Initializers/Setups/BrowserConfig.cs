using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chromium;

namespace TestCases.Initializers.Setups
{
    public class BrowserConfig : OneTimeBaseSetup
    {
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
                    edgeOptions. AddArguments(AppConfig!.Value.EdgeConfig);
                    Driver = new EdgeDriver(edgeOptions);
                    break;

                case "safari":
                    Driver = new SafariDriver();
                    break;

                case "ie":
                    Driver = new InternetExplorerDriver();
                    break;
            }

            Driver!.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            return Driver;
        }
    }
}