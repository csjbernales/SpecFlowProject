using OpenQA.Selenium.Edge;

using System.Diagnostics;

using TechTalk.SpecFlow;

namespace TestCases
{
    public class BaseClass
    {
        public IWebDriver? driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new EdgeDriver();
            Debug.WriteLine("BeforeScenario");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver!.Close();
            Debug.WriteLine("AfterScenario");
        }

    }
}