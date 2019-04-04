using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using narilearsi.Services;

namespace narilearsi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPersonRepository _PersonRepository;


        public ValuesController(IConfiguration configuration, IPersonRepository personRepository) {
            _configuration = configuration;
            _PersonRepository = personRepository;
        }

        // GET api/values
        [HttpGet("getToken")]
        public async Task<IActionResult> configGetAsync()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("narilearsi");
            if (tokenResponse.IsError) {
                return BadRequest("Error getting token");
            }
            return Ok(tokenResponse.Json);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
