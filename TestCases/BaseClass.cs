using OpenQA.Selenium.Edge;

namespace TestCases
{
    public class BaseClass
    {
        public IWebDriver? driver;

        [Before]
        public void Setup()
        {
            driver = new EdgeDriver();
            Console.WriteLine("Setup");
        }

        [After]
        public void Teardown()
        {
            driver!.Close();
            Console.WriteLine("Teardown");
        }

        //-----------------------------------------------------------------

        //[BeforeScenarioBlock]
        //public void BeforeScenarioBlock()
        //{
        //    Console.WriteLine("BeforeScenarioBlock");
        //}

        //[AfterScenarioBlock]
        //public void AfterScenarioBlock()
        //{
        //    Console.WriteLine("AfterScenarioBlock");
        //}

        //-----------------------------------------------------------------

        //[BeforeFeature]
        //public static void BeforeFeature()
        //{
        //    Console.WriteLine("BeforeFeature");
        //}

        //[AfterFeature]
        //public static void AfterFeature()
        //{
        //    Console.WriteLine("AfterFeature");
        //}

        ////-----------------------------------------------------------------

        //[BeforeTestRun]
        //public static void BeforeTestRun()
        //{
        //    Console.WriteLine("BeforeTestRun");
        //}

        //[AfterTestRun]
        //public static void AfterTestRun()
        //{
        //    Console.WriteLine("AfterTestRun");
        //}
    }
}