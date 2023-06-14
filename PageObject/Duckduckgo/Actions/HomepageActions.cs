using Newtonsoft.Json;

using PageObject.Duckduckgo.Pages;
using PageObject.TestData;

namespace PageObject.Duckduckgo.Actions
{
    public class HomepageActions
    {
        public IWebDriver? WebDriver { get; set; }
        public Data? Data { get; set; }

        private Homepage? Homepage;

        public void GoToHomePage()
        {
            Data ??= GetTestData();
            Utils.WebDriver = WebDriver;
            Homepage ??= new Homepage(WebDriver!);

            WebDriver!.Navigate().GoToUrl(Data!.DuckduckgoUrl);
            Homepage.SearchBox!.WaitToBeVisible();
        }

        private static Data GetTestData()
        {
            string currentDirectory = Directory.GetCurrentDirectory()
                .Split("bin")[0]
                .Split("TestCases")[0] + "PageObject";

            string path = Path.Combine(currentDirectory, "TestData", "data.json");

            Data data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(path))!;
            return data;
        }
    }
}