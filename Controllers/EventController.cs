using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace narilearsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EventController : ControllerBase
    {
        private IConfiguration _configuration;
        public EventController(IConfiguration configuration) {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("eventos");
        }
    }
}