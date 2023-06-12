namespace TestCases.Initializers.Setups
{
    [Parallelizable]
    public class BaseSetup : OneTimeBaseSetup
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            Driver!.Close();
        }
    }
}