using Newtonsoft.Json;

namespace TestCases.Initializers
{
    public static class Configuration
    {
        private static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }

        public static AppsettingsConfig GetTestConfig()
        {
            string path = Path.Combine(GetProjectRootDirectory(), "Initializers", "settings.json");
            AppsettingsConfig appsettingsConfig = JsonConvert.DeserializeObject<AppsettingsConfig>(File.ReadAllText(path))!;
            return appsettingsConfig;
        }
    }
}