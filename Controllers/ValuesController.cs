using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("config")]
        public async Task<IActionResult> configGetAsync()
        {
            var res = await _PersonRepository.GetPersons();
            return Ok(res);
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
