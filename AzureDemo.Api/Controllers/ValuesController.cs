using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureDemo.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AzureDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGenerateValues _valueGenerator;

        public ValuesController(IGenerateValues valueGenerator)
        {
            _valueGenerator = valueGenerator ?? throw new ArgumentNullException(nameof(valueGenerator));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var result = await _valueGenerator.GetValues().ConfigureAwait(false);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var result = await _valueGenerator.GetValue(id).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
