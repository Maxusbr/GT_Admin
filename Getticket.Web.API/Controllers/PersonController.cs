using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.API.Services;
using Microsoft.AspNet.Identity;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с Person
    /// </summary>
    [RoutePrefix("persons")]
    [Authorize]
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly ITagService _tagService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personService"></param>
        /// <param name="tagService"></param>
        public PersonController(IPersonService personService, ITagService tagService)
        {
            _personService = personService;
            _tagService = tagService;
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
        [HttpPost]
        [Route("{pageNumber}/{pageSize}")]
        public IHttpActionResult Get(int pageNumber, int pageSize, [FromBody] PersonSearchParams searchParams)
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
        /// <see cref="PersonService.GetCounts" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("counts/{id}")]
        public IHttpActionResult GetCounts(int id)
        {
            return Ok(_personService.GetCounts(id));
        }

        /// <summary>
        /// Add person entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post(PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.IdBithplace == null)
            {
                if (string.IsNullOrEmpty(model.Country))
                {
                    ModelState.AddModelError("Country", "Укажите название страны");
                    return BadRequest("Укажите название страны");
                }

                model.IdBithplace = _personService.UpdatePlace(model.Country, model.Place);
            }
            var userId = User.Identity.GetUserId<int>();
            return Ok(_personService.SavePerson(model, userId).Response());
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
            var userId = User.Identity.GetUserId<int>();
            return Ok(_personService.SavePerson(model, userId).Response());
        }

        /// <summary>
        /// Delete person entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
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
        [HttpPost]
        [Route("antro/delnames/{id}")]
        public IHttpActionResult DeleteAntroNames(int id)
        {
            return Ok(_personService.DeleteAntroNames(id).Response());
        }

        ///// <see cref="PersonService.UpdateAntros" />
        //[HttpPost]
        //[Route("antro/update/{id}")]
        //public IHttpActionResult UpdateAntro(int id, [FromBody] IEnumerable<PersonAntroModel> models)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var userId = User.Identity.GetUserId<int>();
        //    return Ok(_personService.UpdateAntros(id, models, userId).Response());
        //}

        /// <see cref="IPersonService.UpdateAntros(PersonAntroModel, int)" />
        [HttpPost]
        [Route("antro/update/{id}")]
        public IHttpActionResult UpdateAntro(int id, [FromBody] PersonAntroModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            return Ok(_personService.UpdateAntros(model, userId));
        }

        /// <see cref="PersonService.DeleteAntros" />
        [HttpPost]
        [Route("antro/delete")]
        public IHttpActionResult DeleteAntro([FromBody] IEnumerable<PersonAntroModel> models)
        {
            return Ok(_personService.DeleteAntros(models).Response());
        }

        /// <see cref="IPersonService.LinkAntroPerson" />
        [HttpPost]
        [Route("antro/{id}/link/person/{idPerson}")]
        public IHttpActionResult AntroLinkPerson(int id, int idPerson)
        {
            var succes = ServiceResponce.FromSuccess().Result("Link save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save link");
            return Ok(_personService.LinkAntroPerson(id, idPerson) ? succes.Response() : error.Response());
        }

        /// <see cref="IPersonService.LinkMediaEvent" />
        [HttpPost]
        [Route("antro/{id}/link/event/{idEvent}")]
        public IHttpActionResult AntroLinkEvent(int id, int idEvent)
        {
            var succes = ServiceResponce.FromSuccess().Result("Link save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save link");
            return Ok(_personService.LinkAntroEvent(id, idEvent) ? succes.Response() : error.Response());
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
        [HttpPost]
        [Route("connection/deltypes")]
        public IHttpActionResult DeleteConnectionTypes([FromBody] IEnumerable<PersonConnectionTypeModel> models)
        {
            return Ok(_personService.DeleteConnectionTypes(models).Response());
        }

        ///// <see cref="PersonService.UpdateConnection" />
        //[HttpPost]
        //[Route("connection/update/{id}")]
        //public IHttpActionResult UpdateConnection(int id, [FromBody] IEnumerable<PersonConnectionModel> models)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var userId = User.Identity.GetUserId<int>();
        //    return Ok(_personService.UpdateConnection(id, models, userId).Response());
        //}

        /// <see cref="PersonService.UpdateConnection(PersonConnectionModel, int)" />
        [HttpPost]
        [Route("connection/update/{id}")]
        public IHttpActionResult UpdateConnection(int id, [FromBody] PersonConnectionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            return Ok(_personService.UpdateConnection(model, userId));
        }

        /// <see cref="PersonService.DeleteConnection" />
        [HttpPost]
        [Route("connection/delete")]
        public IHttpActionResult DeleteConnection([FromBody] IEnumerable<PersonConnectionModel> models)
        {
            return Ok(_personService.DeleteConnection(models).Response());
        }

        #endregion


        #region SocialLinks

        /// <see cref="PersonService.GetSocialLinkTypes" />
        [HttpGet]
        [Route("social/types")]
        public IHttpActionResult GetSocialLinkTipes()
        {
            return Ok(_personService.GetSocialLinkTypes());
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
        [HttpPost]
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
            var userId = User.Identity.GetUserId<int>();
            return Ok(_personService.UpdateSocialLink(id, models, userId).Response());
        }

        /// <see cref="PersonService.DeleteSocialLink" />
        [HttpPost]
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
        public IHttpActionResult UpdateMediaTypes([FromBody] IEnumerable<MediaTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateMediaTypes(models).Response());
        }

        /// <see cref="PersonService.DeleteMediaTypes" />
        [HttpPost]
        [Route("media/deltypes")]
        public IHttpActionResult DeleteMediaTypes([FromBody] IEnumerable<MediaTypeModel> models)
        {
            return Ok(_personService.DeleteMediaTypes(models).Response());
        }

        ///// <see cref="PersonService.UpdateMedia(int, IEnumerable{PersonMediaModel}, int)" />
        //[HttpPost]
        //[Route("media/update/{id}")]
        //public IHttpActionResult UpdateMedia(int id, [FromBody] IEnumerable<PersonMediaModel> models)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var list = models as IList<PersonMediaModel> ?? models.ToList();
        //    var userId = User.Identity.GetUserId<int>();
        //    var succes = ServiceResponce.FromSuccess().Result("All save complete");
        //    var error = ServiceResponce.FromFailed().Result($"Error save media");
        //    if (!_personService.UpdateMedia(id, list, userId)) return Ok(error.Response());
        //    error = ServiceResponce.FromFailed().Result($"Error save tags");
        //    return Ok(list.Any(item => !_tagService.AddTagLinks(new TagsPersonMediaModel { IdMedia = item.Id, Tags = item.Tags })) ?
        //        error.Response() : succes.Response());
        //}

        /// <see cref="PersonService.UpdateMedia(PersonMediaModel, int)" />
        [HttpPost]
        [Route("media/update/{id}")]
        public IHttpActionResult UpdateMedia(int id, [FromBody] PersonMediaModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            var succes = ServiceResponce.FromSuccess().Result("All save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save media");
            return Ok(_personService.UpdateMedia(model, userId));
        }

        /// <see cref="PersonService.DeleteMedia" />
        [HttpPost]
        [Route("media/delete")]
        public IHttpActionResult DeleteMedia([FromBody] IEnumerable<PersonMediaModel> models)
        {
            return Ok(_personService.DeleteMedia(models).Response());
        }

        /// <see cref="IPersonService.LinkMediaPerson" />
        [HttpPost]
        [Route("media/{id}/link/person/{idPerson}")]
        public IHttpActionResult MediaLinkPerson(int id, int idPerson)
        {
            var succes = ServiceResponce.FromSuccess().Result("Link save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save link");
            return Ok(_personService.LinkMediaPerson(id, idPerson) ? succes.Response(): error.Response());
        }

        /// <see cref="IPersonService.LinkMediaEvent" />
        [HttpPost]
        [Route("media/{id}/link/event/{idEvent}")]
        public IHttpActionResult MediaLinkEvent(int id, int idEvent)
        {
            var succes = ServiceResponce.FromSuccess().Result("Link save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save link");
            return Ok(_personService.LinkMediaEvent(id, idEvent) ? succes.Response(): error.Response());
        }

        #endregion


        #region Descriptions

        /// <see cref="PersonService.GetDescriptions" />
        [HttpGet]
        [Route("description/{id}")]
        public IHttpActionResult GetDescriptions(int id)
        {
            return Ok(_personService.GetListDescriptions(id));
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
        [HttpPost]
        [Route("description/deltypes")]
        public IHttpActionResult DeleteDescriptionTypes([FromBody] IEnumerable<PersonDescriptionTypeModel> models)
        {
            return Ok(_personService.DeleteDescriptionTypes(models).Response());
        }

        /// <see cref="IPersonService.UpdateDescriptions(PersonDescriptionModel, int)" />
        [HttpPost]
        [Route("description/update/{id}")]
        public IHttpActionResult UpdateDescriptions(int id, [FromBody] PersonDescriptionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            var descrId = _personService.UpdateDescriptions(model, userId);
            if (id <= 0 && descrId > 0) return Ok(descrId);
            if (descrId <= 0 || !_personService.LinkDescriptions(id, descrId))
                return Ok(ServiceResponce.FromFailed().Result($"Error save description").Response());
            return Ok(descrId);
        }

        /// <see cref="PersonService.DeleteDescriptions" />
        [HttpPost]
        [Route("description/delete")]
        public IHttpActionResult DeleteDescriptions([FromBody] IEnumerable<PersonDescriptionModel> models)
        {
            return Ok(_personService.DeleteDescriptions(models).Response());
        }

        /// <see cref="IPersonService.SaveDescriptionSchema"/>
        [HttpPost]
        [Route("description/{id}/schema/save/{pesonId}")]
        public IHttpActionResult SaveDescriptionSchema(int id, int pesonId, [FromBody] PageBlockModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = ServiceResponce.FromFailed().Result($"Error save schema");
            var succes = ServiceResponce.FromSuccess().Result("Schema save complete");
            return Ok(_personService.SaveDescriptionSchema(id, model, pesonId) ? succes.Response() : error.Response());
        }
        #endregion


        #region Facts

        /// <see cref="IPersonService.GetFacts" />
        [HttpGet]
        [Route("fact/{id}")]
        public IHttpActionResult GetFacts(int id)
        {
            return Ok(_personService.GetFacts(id));
        }

        /// <see cref="IPersonService.GetFactsTypes" />
        [HttpGet]
        [Route("fact/types")]
        public IHttpActionResult GetFactsTypes()
        {
            return Ok(_personService.GetFactsTypes());
        }

        /// <see cref="IPersonService.UpdateFactTypes" />
        [HttpPost]
        [Route("fact/updatetypes")]
        public IHttpActionResult UpdateFactTypes([FromBody] IEnumerable<PersonFactTypeModel> models)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_personService.UpdateFactTypes(models).Response());
        }

        /// <see cref="IPersonService.DeleteFactTypes" />
        [HttpPost]
        [Route("fact/deltypes")]
        public IHttpActionResult DeleteFactTypes([FromBody] IEnumerable<PersonFactTypeModel> models)
        {
            return Ok(_personService.DeleteFactTypes(models).Response());
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
        public IHttpActionResult UpdateFacts(int id, [FromBody] PersonFactModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.Identity.GetUserId<int>();
            return Ok(_personService.UpdateFacts(model, userId));
        }

        /// <see cref="IPersonService.DeleteFacts" />
        [HttpPost]
        [Route("fact/delete")]
        public IHttpActionResult DeleteFacts([FromBody] IEnumerable<PersonFactModel> models)
        {
            return Ok(_personService.DeleteFacts(models).Response());
        }
        #endregion


        /// <see cref="IPersonService.GetCountries" />
        [HttpGet]
        [Route("country/{found}")]
        public IHttpActionResult GetCountries(string found)
        {
            return Ok(_personService.GetCountries(found));
        }
        /// <see cref="IPersonService.GetCountries" />
        [HttpGet]
        [Route("country/")]
        public IHttpActionResult GetCountries()
        {
            return Ok(_personService.GetCountries(string.Empty));
        }

        /// <see cref="IPersonService.GetCountryPlaces" />
        [HttpGet]
        [Route("place/{found}")]
        public IHttpActionResult GetPlaces(string found)
        {
            return Ok(_personService.GetCountryPlaces(found));
        }

        /// <see cref="IPersonService.GetCountryPlaces" />
        [HttpGet]
        [Route("place/")]
        public IHttpActionResult GetPlaces()
        {
            return Ok(_personService.GetCountryPlaces(string.Empty));
        }

        /// <see cref="ITagService.GeTags()" />
        [HttpGet]
        [Route("tags")]
        public IHttpActionResult GeTags()
        {
            return Ok(_tagService.GeTags());
        }

        /// <see cref="ITagService.GePersonTags" />
        [HttpGet]
        [Route("tags/person/{id}")]
        public IHttpActionResult GePersonTags(int id)
        {
            return Ok(_tagService.GePersonTags(id));
        }

        /// <see cref="ITagService.GePersonTags" />
        [HttpGet]
        [Route("tags/tizer/{id}")]
        public IHttpActionResult GeTizerTags(int id)
        {
            return Ok(_tagService.GeDescriptionTags(id));
        }

        /// <see cref="ITagService.GePersonTags" />
        [HttpGet]
        [Route("tags/media/{id}")]
        public IHttpActionResult GeMediaTags(int id)
        {
            return Ok(_tagService.GePersonMediaTags(id));
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
        //    var id = _personService.UpdateDescriptions(model.TagDescription.Tizer, userId);
        //    if (id < 1) return Ok(error.Response());
        //    model.TagDescription.Tizer.Id = id;
        //    if (!_tagService.AddTagLinks(model.TagDescription))
        //    {
        //        error.Result("Error save tags");
        //        return Ok(error.Response());
        //    }
        //    if (model.TagDescription.ExistDescription)
        //    {
        //        if (_personService.UpdateDescriptions(new PersonDescriptionModel
        //        {
        //            id_DescriptionType = 2,
        //            id_Person = model.IdPerson,
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
        [Route("tags/save/person/{id}")]
        public IHttpActionResult SavePersonTags(int id, [FromBody] IEnumerable<TagModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = ServiceResponce.FromFailed().Result($"Error save tags");
            var succes = ServiceResponce.FromSuccess().Result("All save complete");

            return Ok(!_tagService.AddTagLinks(new PersonTagModel { personId = id, models = models }) ? error.Response() : succes.Response());
        }

        /// <summary>
        /// Сохранить теги персоны
        /// </summary>
        /// <param name="id"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("tags/save/tizer/{id}")]
        public IHttpActionResult SaveTizerTags(int id, [FromBody] IEnumerable<TagModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = ServiceResponce.FromFailed().Result($"Error save tags");
            var succes = ServiceResponce.FromSuccess().Result("All save complete");

            return Ok(!_tagService.AddTagLinks(new TagsTizerModel { IdTizer = id, Tags = models.ToList() }) ? error.Response() : succes.Response());
        }


        /// <see cref="IPersonService.GetUserPageCategory" />
        [HttpGet]
        [Route("userpagecategory")]
        public IHttpActionResult GetUserPageCategory()
        {
            return Ok(_personService.GetUserPageCategory());
        }

        [HttpPost]
        [Route("upload/image")]
        public IHttpActionResult Upload()
        {
            var img = WebImage.GetImageFromRequest();
            if (img == null)
            {
                return BadRequest("Image is null.");
            }
            var error = ServiceResponce.FromFailed().Result($"Error upload image");
            var succes = ServiceResponce.FromSuccess().Result("Image updated successfully.");
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = identity.Claims.Where(c => c.Type == ClaimTypes.Email)
                   .Select(c => c.Value).SingleOrDefault();
            var filename = email + img.FileName;

            string fullPath = HttpContext.Current.Server.MapPath("~/images/uploaded/") + filename;
            try
            {
                img.Save(fullPath);
            }
            catch (Exception ex)
            {
                error.Add("errorsave", ex);
                return Ok(error.Response());
            }
            succes.Add("path", $"images/uploaded/{filename}");
            return Ok(succes.Response());
        }
    }
}
