namespace TestCases.Initializers
{
    [Parallelizable]
    public class BaseSetup : OneTimeBaseSetup
    {
        [TearDown]
        public void TearDown()
        {
            Driver!.Close();
        }
    }
}