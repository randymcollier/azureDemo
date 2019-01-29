using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AzureDemo.Tests.Api
{
    public class ApiWebApplicationFactory : WebApplicationFactory<AzureDemo.Api.Startup> { }
}