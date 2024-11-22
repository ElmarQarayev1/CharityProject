using System;
using Charity.Service;
using System.Data;
using Charity.Service.Dtos.Event;
using Charity.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
	[ApiController]
	public class EventsController:ControllerBase
	{
        public IEventService _eventService;
        public EventsController(IEventService eventService)
		{

			_eventService = eventService;

		}
        [HttpPost("api/admin/Events")]
        public ActionResult Create([FromForm] EventCreateDto createDto)
        {

            var newEventId = _eventService.Create(createDto);


            return StatusCode(201, new { Id = newEventId });
        }

       
       
        [HttpGet("api/admin/Events")]
        public ActionResult<PaginatedList<EventPaginatedGetDto>> GetAll(string? search = null, int page = 1, int size = 10)
        {

            var result = _eventService.GetAllByPage(search, page, size);
            return Ok(result);
        }


       
      
        [HttpGet("api/admin/Events/all")]
        public ActionResult<List<EventGetDto>> GetAll()
        {

            var result = _eventService.GetAll();


            return Ok(result);
        }


      
        [HttpGet("api/admin/Events/{id}")]
        public ActionResult<EventGetDto> GetById(int id)
        {


            var result = _eventService.GetById(id);

            return Ok(result);
        }
      
        [HttpDelete("api/admin/Events/{id}")]
        public IActionResult Delete(int id)
        {
            _eventService.Delete(id);

            return NoContent();
        }

       
        [HttpPut("api/admin/Events/{id}")]
        public void Update(int id, [FromForm] EventUpdateDto updateDto)
        {
            _eventService.Update(id, updateDto);


        }


    }
}

