﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EventController : ControllerBase
    {
        private IConfiguration _configuration;
        private IEventRepository _eventRepository;
        public EventController(IConfiguration configuration, IEventRepository eventRepository)
        {
            _configuration = configuration;
            _eventRepository = eventRepository;
        }
        [HttpGet]
        public IActionResult GetAsync()
        {
            var res =_eventRepository.GetEvents();
            return Ok(res);
        }
        [HttpGet("crearEjemplo")]
        public IActionResult CrearEventEjemplo()
        {
            return Ok(_eventRepository.SetEvent());
        }
    }
}