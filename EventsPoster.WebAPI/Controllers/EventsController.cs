using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Configuration;
using EventsPoster.BL.Events;
using EventsPoster.BL.Events.Entities;
using EventsPoster.Service.Controllers.Entities;

namespace EventsPoster.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventsProvider _eventsProvider;
        private readonly IEventsManager _eventsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventsController(IEventsProvider eventsProvider, IEventsManager eventsManager, IMapper mapper, ILogger logger)
        {
            _eventsManager = eventsManager;
            _eventsProvider = eventsProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //events/
        public IActionResult GetAllEvents()
        {
            var events = _eventsProvider.GetEvents();
            return Ok(new EventsListResponce()
            {
               Events = events.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] //events/filter?filter.AgeViewer=12
        public IActionResult GetFilteredEvents([FromQuery] EventsFilter filter)
        {
            var events = _eventsProvider.GetEvents(_mapper.Map<EventModelFilter>(filter));
            return Ok(new EventsListResponce()
            {
                Events = events.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //events/{id}
        public IActionResult GetEventInfo([FromRoute] Guid id)
        {
            try
            {
                var event_ = _eventsProvider.GetEventInfo(id);
                return Ok(event_);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString()); //stack trace + message
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] CreateEventRequest request) //automatic validation
        {
            try
            {
                var event_ = _eventsManager.CreateEvent(_mapper.Map<CreateEventModel>(request));
                return Ok(event_);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEventInfo([FromRoute] Guid id, UpdateEventRequest request)
        {
            //validator for request
            try
            {
                var event_ = _eventsManager.UpdateEvent(id, _mapper.Map<UpdateEventModel>(request));
                return Ok(event_);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEvent([FromRoute] Guid id)
        {
            try
            {
                _eventsManager.DeleteEvent(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }
}
