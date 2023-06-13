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

        public static Settings GetSettingsConfig()
        {
            const string defaultFileName = "settings.json";
            const string localFileName = "settings.local.json";

            string path = Path.Combine(GetProjectRootDirectory(), "Initializers", localFileName);

            if (!File.Exists(path))
            {
                path = Path.Combine(GetProjectRootDirectory(), "Initializers", defaultFileName);
            }

            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path))!;
            return settings;
        }
    }
}