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
            const string defaultFileName = "settings.json";
            const string localFileName = "settings.local.json";

            string path = Path.Combine(GetProjectRootDirectory(), "Initializers", localFileName);

            if (!File.Exists(path))
            {
                path = Path.Combine(GetProjectRootDirectory(), "Initializers", defaultFileName);
            }

            AppsettingsConfig appsettingsConfig = JsonConvert.DeserializeObject<AppsettingsConfig>(File.ReadAllText(path))!;
            return appsettingsConfig;
        }
    }
}