[assembly: LevelOfParallelism(25)]

namespace TestCases
{
    public class OneTimeBaseSetup
    {
        public IWebDriver? Driver { get; set; } = null;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("OneTimeSetup");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver!.Quit();
            Console.WriteLine("OneTimeTearDown");
        }
    }
}