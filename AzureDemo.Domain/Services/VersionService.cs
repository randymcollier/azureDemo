

using System.Reflection;
using AzureDemo.Domain.Contracts;

namespace AzureDemo.Domain.Services
{
    public class VersionService : ITellVersions
    {
        public string GetVersion()
        {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}