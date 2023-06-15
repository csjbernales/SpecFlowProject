[assembly: LevelOfParallelism(10)]

namespace TestCases.Initializers.Setups
{
    public class OneTimeBaseSetup
    {
        public static Settings? Settings { get; set; } = null;
        public IWebDriver? Driver { get; set; } = null;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }
    }
}