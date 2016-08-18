﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Events;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.API.Services;
using Microsoft.AspNet.Identity;

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
        private readonly ITagService _tagService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="eventService"></param>
        /// <param name="tagService"></param>
        public EventController(IEventService eventService, ITagService tagService)
        {
            _eventService = eventService;
            _tagService = tagService;
        }


        #region Events

        /// <see cref="IEventService.GetEvents" />
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {

            return Ok(_eventService.GetEvents());
        }

        /// <summary>
        /// Список концертов
        /// </summary>
        /// <returns></returns>
        [Route("realy")]
        [HttpGet]
        public IHttpActionResult GetRealyAll()
        {

            return Ok(_eventService.GetEvents(true));
        }
        /// <see cref="IEventService.GetEvent" />
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetOne(int id)
        {
            return Ok(_eventService.GetEvent(id));
        }

        /// <summary>
        /// <see cref="IEventService.GetCounts" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("counts/{id}")]
        public IHttpActionResult GetCounts(int id)
        {
            return Ok(_eventService.GetCounts(id));
        }

        /// <see cref="IEventService.GetCategories" />
        [Route("categories")]
        [HttpGet]
        public IHttpActionResult GetCategories()
        {

            return Ok(_eventService.GetCategories());
        }

        /// <see cref="IEventService.SaveEvent" />
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post(EventModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Identity.GetUserId<int>();
            return Ok(_eventService.SaveEvent(model, userId).Response());
        }

        /// <see cref="IEventService.SaveEvent" />
        [HttpPut]
        [Route("update/{id}")]
        public IHttpActionResult Put(int id, [FromBody] EventModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.Id = id;
            var userId = User.Identity.GetUserId<int>();
            return Ok(_eventService.SaveEvent(model, userId).Response());
        }

        /// <see cref="IEventService.DeleteEvent" />
        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_eventService.DeleteEvent(id).Response());
        }

        #endregion


        #region Connection

        /// <see cref="IEventService.GetConnection" />
        [HttpGet]
        [Route("connection/{id}")]
        public IHttpActionResult GetConnection(int id)
        {
            return Ok(_eventService.GetConnection(id));
        }

        /// <see cref="IEventService.GetConnectionTypes" />
        [HttpGet]
        [Route("connection/types")]
        public IHttpActionResult GetConnectionTypes()
        {
            return Ok(_eventService.GetConnectionTypes());
        }


        /// <see cref="IEventService.UpdateConnectionTypes" />
        [HttpPost]
        [Route("connection/updatetypes")]
        public IHttpActionResult UpdateConnectionTypes([FromBody] IEnumerable<EventConnectionTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_eventService.UpdateConnectionTypes(models).Response());
        }

        /// <see cref="IEventService.DeleteConnectionTypes" />
        [HttpPost]
        [Route("connection/deltypes")]
        public IHttpActionResult DeleteConnectionTypes([FromBody] IEnumerable<EventConnectionTypeModel> models)
        {
            return Ok(_eventService.DeleteConnectionTypes(models).Response());
        }

        /// <see cref="IEventService.UpdateConnection" />
        [HttpPost]
        [Route("connection/update/{id}")]
        public IHttpActionResult UpdateConnection(int id, [FromBody] IEnumerable<EventConnectionModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            return Ok(_eventService.UpdateConnection(id, models, userId).Response());
        }

        /// <see cref="IEventService.DeleteConnection" />
        [HttpPost]
        [Route("connection/delete")]
        public IHttpActionResult DeleteConnection([FromBody] IEnumerable<EventConnectionModel> models)
        {
            return Ok(_eventService.DeleteConnection(models).Response());
        }

        #endregion


        #region Media

        /// <see cref="IEventService.GetMediaTypes" />
        [HttpGet]
        [Route("media/types")]
        public IHttpActionResult GetMediaTypes()
        {
            return Ok(_eventService.GetMediaTypes());
        }

        /// <see cref="IEventService.GetMedia" />
        [HttpGet]
        [Route("media/{id}")]
        public IHttpActionResult GetMedia(int id)
        {
            return Ok(_eventService.GetMedia(id));
        }

        /// <see cref="IEventService.UpdateMediaTypes" />
        [HttpPost]
        [Route("media/updatetypes")]
        public IHttpActionResult UpdateMediaTypes([FromBody] IEnumerable<MediaTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_eventService.UpdateMediaTypes(models).Response());
        }

        /// <see cref="IEventService.DeleteMediaTypes" />
        [HttpPost]
        [Route("media/deltypes")]
        public IHttpActionResult DeleteMediaTypes([FromBody] IEnumerable<MediaTypeModel> models)
        {
            return Ok(_eventService.DeleteMediaTypes(models).Response());
        }

        /// <see cref="IEventService.UpdateMedia" />
        [HttpPost]
        [Route("media/update/{id}")]
        public IHttpActionResult UpdateMedia(int id, [FromBody] IEnumerable<EventMediaModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var list = models as IList<EventMediaModel> ?? models.ToList();
            var userId = User.Identity.GetUserId<int>();
            var succes = ServiceResponce.FromSuccess().Result("All save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save media");
            if (!_eventService.UpdateMedia(id, list, userId)) return Ok(error.Response());
            error = ServiceResponce.FromFailed().Result($"Error save tags");
            return Ok(list.Any(item => !_tagService.AddTagLinks(new TagsEventMediaModel { IdMedia = item.Id, Tags = item.Tags })) ?
                error.Response() : succes.Response());
        }

        /// <see cref="IEventService.DeleteMedia" />
        [HttpPost]
        [Route("media/delete")]
        public IHttpActionResult DeleteMedia([FromBody] IEnumerable<EventMediaModel> models)
        {
            return Ok(_eventService.DeleteMedia(models).Response());
        }


        /// <see cref="IPersonService.LinkMediaPerson" />
        [HttpPost]
        [Route("media/{id}/link/person/{idPerson}")]
        public IHttpActionResult MediaLinkPerson(int id, int idPerson)
        {
            var succes = ServiceResponce.FromSuccess().Result("Link save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save link");
            return Ok(_eventService.LinkMediaPerson(id, idPerson) ? succes.Response() : error.Response());
        }

        /// <see cref="IPersonService.LinkMediaEvent" />
        [HttpPost]
        [Route("media/{id}/link/event/{idEvent}")]
        public IHttpActionResult MediaLinkEvent(int id, int idEvent)
        {
            var succes = ServiceResponce.FromSuccess().Result("Link save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save link");
            return Ok(_eventService.LinkMediaEvent(id, idEvent) ? succes.Response() : error.Response());
        }
        #endregion


        #region Descriptions

        /// <see cref="IEventService.GetDescriptions" />
        [HttpGet]
        [Route("description/{id}")]
        public IHttpActionResult GetDescriptions(int id)
        {
            return Ok(_eventService.GetDescriptions(id));
        }

        /// <see cref="IEventService.GetDescriptionTypes" />
        [HttpGet]
        [Route("description/types")]
        public IHttpActionResult GetDescriptionTypes()
        {
            return Ok(_eventService.GetDescriptionTypes());
        }

        /// <see cref="IEventService.UpdateDescriptionTypes" />
        [HttpPost]
        [Route("description/updatetypes")]
        public IHttpActionResult UpdateDescriptionTypes([FromBody] IEnumerable<EventDescriptionTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_eventService.UpdateDescriptionTypes(models).Response());
        }

        /// <see cref="IEventService.DeleteDescriptionTypes" />
        [HttpPost]
        [Route("description/deltypes")]
        public IHttpActionResult DeleteDescriptionTypes([FromBody] IEnumerable<EventDescriptionTypeModel> models)
        {
            return Ok(_eventService.DeleteDescriptionTypes(models).Response());
        }

        /// <see cref="IEventService.UpdateDescriptions(int, IEnumerable{EventDescriptionModel}, int)" />
        [HttpPost]
        [Route("description/update/{id}")]
        public IHttpActionResult UpdateDescriptions(int id, [FromBody] IEnumerable<EventDescriptionModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            return Ok(_eventService.UpdateDescriptions(id, models, userId).Response());
        }

        /// <see cref="IEventService.DeleteDescriptions" />
        [HttpPost]
        [Route("description/delete")]
        public IHttpActionResult DeleteDescriptions([FromBody] IEnumerable<EventDescriptionModel> models)
        {
            return Ok(_eventService.DeleteDescriptions(models).Response());
        }
        #endregion



        #region Facts

        /// <see cref="IPersonService.GetFacts" />
        [HttpGet]
        [Route("fact/{id}")]
        public IHttpActionResult GetFacts(int id)
        {
            return Ok(_eventService.GetFacts(id));
        }

        /// <see cref="IPersonService.GetFactsTypes" />
        [HttpGet]
        [Route("fact/types")]
        public IHttpActionResult GetFactsTypes()
        {
            return Ok(_eventService.GetFactsTypes());
        }

        /// <see cref="IPersonService.UpdateFactTypes" />
        [HttpPost]
        [Route("fact/updatetypes")]
        public IHttpActionResult UpdateFactTypes([FromBody] IEnumerable<EventFactTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_eventService.UpdateFactTypes(models).Response());
        }

        /// <see cref="IPersonService.DeleteFactTypes" />
        [HttpPost]
        [Route("fact/deltypes")]
        public IHttpActionResult DeleteFactTypes([FromBody] IEnumerable<EventFactTypeModel> models)
        {
            return Ok(_eventService.DeleteFactTypes(models).Response());
        }

        ///// <see cref="IPersonService.UpdateFacts" />
        //[HttpPost]
        //[Route("fact/update/{id}")]
        //public IHttpActionResult UpdateFacts(int id, [FromBody] IEnumerable<PersonFactModel> models)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var userId = User.Identity.GetUserId<int>();
        //    return Ok(_personService.UpdateFacts(id, models, userId).Response());
        //}

        /// <see cref="IPersonService.UpdateFacts(PersonFactModel, int)" />
        [HttpPost]
        [Route("fact/update/{id}")]
        public IHttpActionResult UpdateFacts(int id, [FromBody] EventFactModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            return Ok(_eventService.UpdateFacts(model, userId));
        }

        /// <see cref="IPersonService.DeleteFacts" />
        [HttpPost]
        [Route("fact/delete")]
        public IHttpActionResult DeleteFacts([FromBody] IEnumerable<EventFactModel> models)
        {
            return Ok(_eventService.DeleteFacts(models).Response());
        }
        #endregion





        /// <see cref="ITagService.GeTags()" />
        [HttpGet]
        [Route("tags")]
        public IHttpActionResult GeTags()
        {
            return Ok(_tagService.GeTags());
        }

        /// <see cref="ITagService.GeEventTags" />
        [HttpGet]
        [Route("tags/{id}")]
        public IHttpActionResult GeTags(int id)
        {
            return Ok(_tagService.GeEventTags(id));
        }

        /// <summary>
        /// Сохранить описания и теги
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost]
        //[Route("tags/save/description")]
        //public IHttpActionResult SaveDescriptions([FromBody] CreateDescriptionModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var error = ServiceResponce.FromFailed().Result($"Error save description");
        //    var succes = ServiceResponce.FromSuccess().Result("All save complete");
        //    var userId = User.Identity.GetUserId<int>();
        //    var id = _eventService.UpdateDescriptions(model.TagDescription.Tizer, userId);
        //    if (id < 1) return Ok(error.Response());
        //    model.TagDescription.Tizer.Id = id;
        //    if (!_tagService.AddTagLinks(model.TagDescription))
        //    {
        //        error.Result("Error save tags");
        //        return Ok(error.Response());
        //    }
        //    if (model.TagDescription.ExistDescription)
        //    {
        //        if (_eventService.UpdateDescriptions(new EventDescriptionModel
        //        {
        //            id_DescriptionType = 2,
        //            id_Event = model.IdEvent,
        //            DescriptionText = model.TagDescription.StaticDescription
        //        }, userId) < 1)
        //        {
        //            error.Result("Error save description");
        //            return Ok(error.Response());
        //        }
        //    }
        //    if (model.TagAntroList.Any(item => !_tagService.AddTagLinks(item)))
        //    {
        //        error.Result("Error save tags");
        //        return Ok(error.Response());
        //    }

        //    return Ok(succes.Response());
        //}


        /// <summary>
        /// Сохранить теги персоны
        /// </summary>
        /// <param name="id"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("tags/save/{id}")]
        public IHttpActionResult SaveEventTags(int id, [FromBody] IEnumerable<TagModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = ServiceResponce.FromFailed().Result($"Error save tags");
            var succes = ServiceResponce.FromSuccess().Result("All save complete");

            return Ok(!_tagService.AddTagLinks(new EventTagModel { EventId = id, Models = models }) ? error.Response() : succes.Response());
        }
    }

    
}
