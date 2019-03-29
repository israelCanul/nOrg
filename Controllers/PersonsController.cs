using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PersonsController : Controller
    {
        private IConfiguration _configuration;
        private IPersonRepository _PersonRepository;
        public PersonsController(IConfiguration configuration, IPersonRepository personRepository) {
            _configuration = configuration;
            _PersonRepository = personRepository;
        }
        // GET: api/Persons
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _PersonRepository.GetPersons();
            return Ok(res);
        }

        // GET: api/Persons/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _PersonRepository.GetPerson(id);
            if (res == null) {
                return BadRequest("{\"code\":-1,\"desc\":\"no se encuentra el objeto\"}");
            }
            if (res.status != "ACTIVE") {
                return BadRequest("{\"code\":-1,\"desc\":\"This Person is not Active\"}");
            }
            return Ok(res);
        }

        // POST: api/Persons
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Persons person)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var res = await _PersonRepository.SetPerson(person);
            return Ok(res);
        }

        // PUT: api/Persons/5
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody]Persons person)
        {
            if (!ModelState.IsValid) {
                return BadRequest("{\"code\":-1,\"desc\":\"no se encuentra el objeto\"}");
            }
            var res = _PersonRepository.UpdatePerson(id, person);
            return Ok(res);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
