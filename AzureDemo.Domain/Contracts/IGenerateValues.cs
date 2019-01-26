using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDemo.Domain.Contracts
{
    public interface IGenerateValues
    {
        Task<string> GetValue(int id);
        Task<IEnumerable<string>> GetValues();
    }
}