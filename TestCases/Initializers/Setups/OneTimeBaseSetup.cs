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
    }
}