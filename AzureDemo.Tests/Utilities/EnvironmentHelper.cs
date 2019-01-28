namespace AzureDemo.Tests.Utilities
{
    public static class EnvironmentHelper
    {
        private enum Environment
        {
            Local,
            Staging,
            Production
        }

        private static Environment GetEnvironment(string input)
        {
            switch (input)
            {
                case ("local"):
                    return Environment.Local;
                case ("staging"):
                    return Environment.Staging;
                case ("production"):
                    return Environment.Production;
                default:
                    return Environment.Local;
            }
        }

        public static string GetBaseUrl(string input)
        {
            var env = GetEnvironment(input);
            switch (env)
            {
                case (Environment.Local):
                    return "http://localhost";
                case (Environment.Staging):
                    return "https://azuredemoapi13454-staging.azurewebsites.net";
                case (Environment.Production):
                    return "https://azuredemoapi13454.azurewebsites.net";
                default:
                    return "http://localhost";

            }
        }
    }
}