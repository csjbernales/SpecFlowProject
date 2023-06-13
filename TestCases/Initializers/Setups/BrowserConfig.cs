using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestCases.Initializers.Setups
{
    public class BrowserConfig : OneTimeBaseSetup
    {
        public IWebDriver? InitializeBrowser(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                    ChromeOptions chromeOptions = new();
                    chromeOptions.AddArguments(Settings!.Value.ChromeConfig);
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    FirefoxOptions firefoxOptions = new();
                    firefoxOptions.AddArguments(Settings!.Value.FirefoxConfig);
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    EdgeOptions edgeOptions = new();
                    edgeOptions.AddArguments(Settings!.Value.EdgeConfig);
                    return new EdgeDriver(edgeOptions);
            }

            return null;
        }
    }
}