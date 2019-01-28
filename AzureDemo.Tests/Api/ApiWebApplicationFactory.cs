using System.Net.Http;
using AzureDemo.Tests.Utilities;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AzureDemo.Tests.Api
{
    public class ApiWebApplicationFactory : WebApplicationFactory<AzureDemo.Api.Startup>
    {
        private readonly Environment _environment;
        private readonly string _baseUrl;

        public ApiWebApplicationFactory(Environment environment)
        {
            _environment = environment;
            _baseUrl = EnvironmentHelper.GetBaseUrl(_environment);
        }

        public HttpClient GetHttpClient()
        {
            if (_environment == Environment.Local)
            {
                return base.CreateClient();
            }
            else
            {
                return new HttpClient { BaseAddress = new System.Uri(_baseUrl) };
            }
        } 
    }
}