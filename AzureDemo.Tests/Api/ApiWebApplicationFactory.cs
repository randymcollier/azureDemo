using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AzureDemo.Tests.Api
{
    public class ApiWebApplicationFactory : WebApplicationFactory<AzureDemo.Api.Startup>
    {
        private readonly string _baseUrl;
        public ApiWebApplicationFactory(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public HttpClient GetHttpClient()
        {
            WebApplicationFactoryClientOptions options = new WebApplicationFactoryClientOptions
            {
                BaseAddress = new System.Uri(_baseUrl)
            };
            return base.CreateClient(options);
        } 
    }
}