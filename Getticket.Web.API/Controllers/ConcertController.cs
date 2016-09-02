using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Getticket.Web.API.Models.Concerts;
using Getticket.Web.API.Models.Events;
using Getticket.Web.API.Services;
using Microsoft.AspNet.Identity;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с Concert
    /// </summary>
    [RoutePrefix("concerts")]
    [Authorize(Roles = "Admin")]
    public class ConcertController : ApiController
    {
        private readonly IEventService _eventService;
        private readonly IConcertService _concertService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="eventService"></param>
        /// <param name="concertService"></param>
        public ConcertController(IEventService eventService, IConcertService concertService)
        {
            _eventService = eventService;
            _concertService = concertService;
        }

        #region Concerts

        /// <see cref="IConcertService.GetConcerts()" />
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetConcerts()
        {
            return Ok(_concertService.GetConcerts());
        }

        /// <see cref="IConcertService.GetConcerts(int)" />
        [Route("all/{id}")]
        [HttpGet]
        public IHttpActionResult GetConcerts(int id)
        {
            return Ok(_concertService.GetConcerts(id));
        }

        /// <see cref="IConcertService.GetConcert" />
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetConcert(int id)
        {
            return Ok(_concertService.GetConcert(id));
        }

        /// <see cref="IConcertService.GetConcertSeriesName" />
        [Route("series")]
        [HttpGet]
        public IHttpActionResult GetConcertSeriesName()
        {
            return Ok(_concertService.GetConcertSeriesName());
        }


        /// <see cref="IConcertService.GetConcertSchedules" />
        [Route("schedule/{id}")]
        [HttpGet]
        public IHttpActionResult GetConcertSchedules(int id)
        {
            return Ok(_concertService.GetConcertSchedules(id));
        }

        /// <see cref="IConcertService.GetConcertSchedules" />
        [Route("schedule/week/preview")]
        [HttpPost]
        public IHttpActionResult GetConcertSchedules([FromBody] IEnumerable<WeekScheduleModel> models)
        {
            return Ok(_concertService.GetPreview(models));
        }

        /// <see cref="IConcertService.GetConcertSchedules" />
        [Route("schedule/preview")]
        [HttpPost]
        public IHttpActionResult GetConcertSchedules([FromBody] IEnumerable<RangeScheduleModel> models)
        {
            return Ok(_concertService.GetPreview(models));
        }



        /// <see cref="IConcertService.GetConcertProgramms" />
        [Route("programm/{id}")]
        [HttpGet]
        public IHttpActionResult GetConcertProgramms(int id)
        {
            return Ok(_concertService.GetConcertProgramms(id));
        }

        /// <see cref="IConcertService.GetConcertProgramms" />
        [Route("actor/{id}")]
        [HttpGet]
        public IHttpActionResult GetActorProgramms(int id)
        {
            return Ok(_concertService.GetActorProgramms(id));
        }

        /// <see cref="IConcertService.GetConcertPlaces" />
        [Route("halls/{id}")]
        [HttpGet]
        public IHttpActionResult GetConcertHalls(int id)
        {
            return Ok(_concertService.GetConcertPlaces(id));
        }

        /// <see cref="IConcertService.GetConcertExist" />
        [Route("exist/{id}")]
        [HttpGet]
        public IHttpActionResult GetConcertExist(int id)
        {
            return Ok(_concertService.GetConcertExist(id));
        }

        /// <see cref="IConcertService.GetConcertExist" />
        [Route("groups")]
        [HttpGet]
        public IHttpActionResult GetActorGroups()
        {
            return Ok(_concertService.GetActorGroups());
        }

        /// <see cref="IConcertService.SaveConcert" />
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody] EventModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();
            var succes = ServiceResponce.FromSuccess().Result("Concert save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert");
            var concert = _concertService.SaveConcert(model, userId);
            if (concert == null) return Ok(error.Response());
            succes.Add("concertId", concert.Id);
            return Ok(succes.Response());
        }

        /// <see cref="IConcertService.SaveConcert" />
        [HttpPost]
        [Route("update")]
        public IHttpActionResult Post([FromBody] UpdateConcertProgrammModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();
            var succes = ServiceResponce.FromSuccess().Result("Concert save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert");
            var concert = _concertService.SaveConcert(model.Concert, userId);
            if (model.Programms != null)
                foreach (var el in model.Programms)
                    _concertService.UpdateConcertProgramm(el);
            if (model.Actors != null)
                foreach (var el in model.Actors)
                    _concertService.UpdateActor(el);
            if (concert == null) return Ok(error.Response());
            succes.Add("concertId", concert.Id);
            return Ok(succes.Response());
        }

        /// <see cref="IConcertService.SaveConcertProgramm(int, IEnumerable{ConcertProgrammModel})" />
        [HttpPost]
        [Route("programm/{id}")]
        public IHttpActionResult Post(int id, [FromBody] IEnumerable<ConcertProgrammModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();
            var succes = ServiceResponce.FromSuccess().Result("Concert programms save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert programms");

            return Ok(_concertService.SaveConcertProgramm(id, models) ? succes.Response() : error.Response());
        }

        /// <see cref="IConcertService.SaveConcertProgramm(ConcertProgrammModel)" />
        [HttpPost]
        [Route("programm/save")]
        public IHttpActionResult Post([FromBody] ConcertProgrammModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();

            return Ok(_concertService.SaveConcertProgramm(model).Response());
        }

        /// <see cref="IConcertService.SaveConcertSchedules" />
        [HttpPost]
        [Route("schedule/{id}")]
        public IHttpActionResult Post(int id, [FromBody] ConcertDateRangeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();
            var succes = ServiceResponce.FromSuccess().Result("Concert schedules save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert schedules");

            return Ok(_concertService.SaveConcertSchedules(model) ? succes.Response() : error.Response());
        }

        /// <see cref="IConcertService.SaveConcertSchedules" />
        [HttpPost]
        [Route("tickets/save")]
        public IHttpActionResult Post([FromBody] ConcertTicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();
            return Ok(_concertService.SaveConcertTicket(model).Response());
        }

        /// <see cref="IConcertService.SaveConcertPlace" />
        [HttpPost]
        [Route("concertplace/save")]
        public IHttpActionResult Post([FromBody] ConcertPlaceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var succes = ServiceResponce.FromSuccess().Result("Concert schedules save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert schedules");
            var res = _concertService.SaveConcertPlace(model);
            if (res != null)
                succes.Add("ConcertPlaceId", res.Id);
            return Ok(res != null ? succes.Response() : error.Response());
        }

        /// <see cref="IConcertService.SaveConcertPlace" />
        [HttpPost]
        [Route("hall/save")]
        public IHttpActionResult Post([FromBody] HallModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var succes = ServiceResponce.FromSuccess().Result("Concert schedules save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert schedules");
            var res = _concertService.SaveHall(model);
            if (res != null)
                succes.Add("ConcertPlaceId", res.Id);
            return Ok(res != null ? succes.Response() : error.Response());
        }

        /// <see cref="IConcertService.SaveGroup" />
        [HttpPost]
        [Route("group/save")]
        public IHttpActionResult Post([FromBody] ActorGroupModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_concertService.SaveGroup(model).Response());
        }

        /// <see cref="IConcertService.SaveGroup" />
        [HttpPost]
        [Route("actor/save")]
        public IHttpActionResult Post([FromBody] ActorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_concertService.SaveActor(model).Response());
        }
        #endregion


    }


}
