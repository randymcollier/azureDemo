namespace AzureDemo.Tests.Utilities
{
    public enum Environment
    {
        Local,
        Staging,
        Production
    }

    public static class EnvironmentHelper
    {
        private static Environment? _environment;

        public static Environment GetEnvironment(string input)
        {
            if (_environment.HasValue) return _environment.Value;

            switch (input)
            {
                case ("local"):
                    _environment = Environment.Local;
                    break;
                case ("staging"):
                    _environment = Environment.Staging;
                    break;
                case ("production"):
                    _environment = Environment.Production;
                    break;
                default:
                    _environment = Environment.Local;
                    break;
            }
            
            return _environment.Value;
        }

        public static string GetBaseUrl(string input)
        {
            var env = GetEnvironment(input);
            switch (env)
            {
                case (Environment.Local):
                    return "http://localhost/";
                case (Environment.Staging):
                    return "https://azuredemoapi13454-stagin.azurewebsites.net/";
                case (Environment.Production):
                    return "https://azuredemoapi13454.azurewebsites.net/";
                default:
                    return "http://localhost/";

            }
        }

        public static string GetBaseUrl(Environment input)
        {
            switch (input)
            {
                case (Environment.Local):
                    return "http://localhost/";
                case (Environment.Staging):
                    return "https://azuredemoapi13454-staging.azurewebsites.net/";
                case (Environment.Production):
                    return "https://azuredemoapi13454.azurewebsites.net/";
                default:
                    return "http://localhost/";

            }
        }
    }
}