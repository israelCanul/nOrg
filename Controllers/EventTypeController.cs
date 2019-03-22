using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using narilearsi.Services;

namespace narilearsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EventTypeController : ControllerBase
    {
        private IConfiguration _configuration;
        private IEventTypeRepository _eventTypeRepository;
        public EventTypeController(IConfiguration configuration, IEventTypeRepository eventTypeRepository)
        {
            _configuration = configuration;
            _eventTypeRepository = eventTypeRepository;
        }
        // GET: api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            var res = _eventTypeRepository.GetEventTypes();
            return Ok(res);
        }
    }
}
