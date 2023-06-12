using Newtonsoft.Json;

using PageObject.Google.Pages;
using PageObject.TestData;

namespace PageObject.Google.Actions
{
    public class HomepageActions
    {
        public IWebDriver? WebDriver { get; set; }
        public Data? Data { get; set; }

        public Homepage? GoToHomePage()
        {
            this.Data ??= GetTestData();

            WebDriver!.Navigate().GoToUrl(Data!.GoogleUrl);
            return new Homepage(WebDriver);
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