using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureDemo.Domain.Contracts;

namespace AzureDemo.Domain.Services
{
    public class ValueGenerator : IGenerateValues
    {
        public async Task<string> GetValue(int id)
        {
            return await Task.FromResult($"value{id}").ConfigureAwait(false);
        }

        public async Task<IEnumerable<string>> GetValues()
        {
            return await Task.FromResult(Enumerable.Range(1, 3).Select(x => $"value{x}")).ConfigureAwait(false);
        }
    }
}