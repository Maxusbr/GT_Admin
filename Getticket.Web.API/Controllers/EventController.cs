using System;
using System.Web.Http;
using Getticket.Web.API.Services;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с Event
    /// </summary>
    [RoutePrefix("events")]
    [Authorize(Roles = "Admin")]
    public class EventController : ApiController
    {
        private readonly IEventService _eventService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="eventService"></param>
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <see cref="IEventService.GetEvents" />
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {

            return Ok(_eventService.GetEvents());
        }

        [Route("{Id}")]
        [HttpPost]
        public IHttpActionResult GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            throw new NotImplementedException();
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
