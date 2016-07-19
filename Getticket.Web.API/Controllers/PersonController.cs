using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.API.Services;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с Person
    /// </summary>
    [RoutePrefix("persons")]
    [Authorize]
    public class PersonController : ApiController
    {
        private readonly PersonService _personService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personService"></param>
        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        #region Person

        /// <see cref="PersonService.GetAll" />
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_personService.GetAll());
        }

        /// <summary>
        /// <see cref="PersonService.GetPersons" />
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        public IHttpActionResult Get(int pageNumber, int pageSize, [FromBody] PersonSearchParams searchParams = null)
        {
            return Ok(_personService.GetPersons(pageNumber, pageSize, searchParams));
        }

        /// <summary>
        /// <see cref="PersonService.GetPerson" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_personService.GetPerson(id));
        }

        /// <summary>
        /// Add person entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_personService.SavePerson(model).Response());
        }

        /// <summary>
        /// Update person entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [HttpPut]
        [Route("update/{id}")]
        public IHttpActionResult Put(int id, [FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.Id = id;
            return Ok(_personService.SavePerson(model).Response());
        }

        /// <summary>
        /// Delete person entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_personService.DeletePerson(id).Response());
        }

        #endregion


        #region Antro

        /// <see cref="PersonService.GetAntroNames" />
        [HttpGet]
        [Route("antro/names")]
        public IHttpActionResult GetAntroNames()
        {
            return Ok(_personService.GetAntroNames());
        }

        /// <see cref="PersonService.GetPersonAntros" />
        [HttpGet]
        [Route("antro/{id}")]
        public IHttpActionResult GetAntro(int id)
        {
            return Ok(_personService.GetPersonAntros(id));
        }

        /// <see cref="PersonService.UpdateAntroNames" />
        [HttpPost]
        [Route("antro/updatenames")]
        public IHttpActionResult UpdateAntroNames([FromBody] IEnumerable<PersonAntroNameModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateAntroNames(models).Response());
        }

        /// <see cref="PersonService.DeleteAntroNames" />
        [HttpDelete]
        [Route("antro/delnames/{id}")]
        public IHttpActionResult DeleteAntroNames(int id)
        {
            return Ok(_personService.DeleteAntroNames(id).Response());
        }

        /// <see cref="PersonService.UpdateAntros" />
        [HttpPost]
        [Route("antro/update/{id}")]
        public IHttpActionResult UpdateAntro(int id, [FromBody] IEnumerable<PersonAntroModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateAntros(id, models).Response());
        }

        /// <see cref="PersonService.DeleteAntros" />
        [HttpDelete]
        [Route("antro/delete/{id}")]
        public IHttpActionResult DeleteAntro(int id, [FromBody] IEnumerable<PersonAntroModel> models)
        {
            return Ok(_personService.DeleteAntros(id, models).Response());
        }
        #endregion


        #region Connection

        /// <see cref="PersonService.GetConnection" />
        [HttpGet]
        [Route("connection/{id}")]
        public IHttpActionResult GetConnection(int id)
        {
            return Ok(_personService.GetConnection(id));
        }

        /// <see cref="PersonService.GetConnectionTypes" />
        [HttpGet]
        [Route("connection/types")]
        public IHttpActionResult GetConnectionTypes()
        {
            return Ok(_personService.GetConnectionTypes());
        }


        /// <see cref="PersonService.UpdateConnectionTypes" />
        [HttpPost]
        [Route("connection/updatetypes")]
        public IHttpActionResult UpdateConnectionTypes([FromBody] IEnumerable<PersonConnectionTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateConnectionTypes(models).Response());
        }

        /// <see cref="PersonService.DeleteConnectionTypes" />
        [HttpDelete]
        [Route("connection/deltypes")]
        public IHttpActionResult DeleteConnectionTypes([FromBody] IEnumerable<PersonConnectionTypeModel> models)
        {
            return Ok(_personService.DeleteConnectionTypes(models).Response());
        }

        /// <see cref="PersonService.UpdateConnection" />
        [HttpPost]
        [Route("connection/update/{id}")]
        public IHttpActionResult UpdateConnection(int id, [FromBody] IEnumerable<PersonConnectionModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateConnection(id, models).Response());
        }

        /// <see cref="PersonService.DeleteConnection" />
        [HttpDelete]
        [Route("connection/delete/{id}")]
        public IHttpActionResult DeleteConnection(int id, [FromBody] IEnumerable<PersonConnectionModel> models)
        {
            return Ok(_personService.DeleteConnection(id, models).Response());
        }

        #endregion


        #region SocialLinks

        /// <see cref="PersonService.GetSocialLinkTipes" />
        [HttpGet]
        [Route("social/types")]
        public IHttpActionResult GetSocialLinkTipes()
        {
            return Ok(_personService.GetSocialLinkTipes());
        }

        /// <see cref="PersonService.GetSocialLinks" />
        [HttpGet]
        [Route("social/{id}")]
        public IHttpActionResult GetSocialLinks(int id)
        {
            return Ok(_personService.GetSocialLinks(id));
        }

        /// <see cref="PersonService.UpdateSocialLinkTypes" />
        [HttpPost]
        [Route("social/updatetypes")]
        public IHttpActionResult UpdateSocialLinkTypes([FromBody] IEnumerable<PersonSocialLinkTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateSocialLinkTypes(models).Response());
        }

        /// <see cref="PersonService.DeleteSocialLinkTypes" />
        [HttpDelete]
        [Route("social/deltypes")]
        public IHttpActionResult DeleteSocialLinkTypes([FromBody] IEnumerable<PersonSocialLinkTypeModel> models)
        {
            return Ok(_personService.DeleteSocialLinkTypes(models).Response());
        }

        /// <see cref="PersonService.UpdateSocialLink" />
        [HttpPost]
        [Route("social/update/{id}")]
        public IHttpActionResult UpdateSocialLink(int id, [FromBody] IEnumerable<PersonSocialLinkModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateSocialLink(id, models).Response());
        }

        /// <see cref="PersonService.DeleteSocialLink" />
        [HttpDelete]
        [Route("social/delete")]
        public IHttpActionResult DeleteSocialLink([FromBody] IEnumerable<PersonSocialLinkModel> models)
        {
            return Ok(_personService.DeleteSocialLink(models).Response());
        }
        #endregion


        #region Media

        /// <see cref="PersonService.GetMediaTypes" />
        [HttpGet]
        [Route("media/types")]
        public IHttpActionResult GetMediaTypes()
        {
            return Ok(_personService.GetMediaTypes());
        }

        /// <see cref="PersonService.GetMedia" />
        [HttpGet]
        [Route("media/{id}")]
        public IHttpActionResult GetMedia(int id)
        {
            return Ok(_personService.GetMedia(id));
        }

        /// <see cref="PersonService.UpdateMediaTypes" />
        [HttpPost]
        [Route("media/updatetypes")]
        public IHttpActionResult UpdateMediaTypes([FromBody] IEnumerable<PersonMediaTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateMediaTypes(models).Response());
        }

        /// <see cref="PersonService.DeleteMediaTypes" />
        [HttpDelete]
        [Route("media/deltypes")]
        public IHttpActionResult DeleteMediaTypes([FromBody] IEnumerable<PersonMediaTypeModel> models)
        {
            return Ok(_personService.DeleteMediaTypes(models).Response());
        }

        /// <see cref="PersonService.UpdateMedia" />
        [HttpPost]
        [Route("media/update/{id}")]
        public IHttpActionResult UpdateMedia(int id, [FromBody] IEnumerable<PersonMediaModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateMedia(id, models).Response());
        }

        /// <see cref="PersonService.DeleteMedia" />
        [HttpDelete]
        [Route("media/delete")]
        public IHttpActionResult DeleteMedia([FromBody] IEnumerable<PersonMediaModel> models)
        {
            return Ok(_personService.DeleteMedia(models).Response());
        }
        #endregion


        #region Descriptions

        /// <see cref="PersonService.GetDescriptions" />
        [HttpGet]
        [Route("description/{id}")]
        public IHttpActionResult GetDescriptions(int id)
        {
            return Ok(_personService.GetDescriptions(id));
        }

        /// <see cref="PersonService.GetDescriptionTypes" />
        [HttpGet]
        [Route("description/types")]
        public IHttpActionResult GetDescriptionTypes()
        {
            return Ok(_personService.GetDescriptionTypes());
        }

        /// <see cref="PersonService.UpdateDescriptionTypes" />
        [HttpPost]
        [Route("description/updatetypes")]
        public IHttpActionResult UpdateDescriptionTypes([FromBody] IEnumerable<PersonDescriptionTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateDescriptionTypes(models).Response());
        }

        /// <see cref="PersonService.DeleteDescriptionTypes" />
        [HttpDelete]
        [Route("description/deltypes")]
        public IHttpActionResult DeleteDescriptionTypes([FromBody] IEnumerable<PersonDescriptionTypeModel> models)
        {
            return Ok(_personService.DeleteDescriptionTypes(models).Response());
        }

        /// <see cref="PersonService.UpdateDescriptions" />
        [HttpPost]
        [Route("description/update/{id}")]
        public IHttpActionResult UpdateDescriptions(int id, [FromBody] IEnumerable<PersonDescriptionModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateDescriptions(id, models).Response());
        }

        /// <see cref="PersonService.DeleteDescriptions" />
        [HttpDelete]
        [Route("description/delete")]
        public IHttpActionResult DeleteDescriptions([FromBody] IEnumerable<PersonDescriptionModel> models)
        {
            return Ok(_personService.DeleteDescriptions(models).Response());
        }
        #endregion



    }
}
