namespace TestCases.Initializers
{
    public struct Settings
    {
        public string[]? BrowserList { get; set; }
        public string[]? ChromeConfig { get; set; }
        public string[]? FirefoxConfig { get; set; }
        public string[]? EdgeConfig { get; set; }

        public string[] BrowsersToRun()
        {
            Random rng = new();
            return BrowserList!.OrderBy((item) => rng.NextInt64()).ToArray();
        }
    }
}