using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Log Helper
    /// </summary>
    public static class PageModelHelper
    {
        public static PageBlockModel GetPageBlockModel(PageBlock block)
        {
            return block != null ? new PageBlockModel
            {
                Id = block.Id,
                IdBlockType = block.IdBlockType,
                IdPage = block.IdPage,
                Name = block.Name,
                Type = GetPageBlockTypeModel(block.Type),
                Page = GetPageModel(block.Page)
            }
            : null;
        }

        public static PageSchemaModel GetPageModel(PageSchema page)
        {
            if (page == null) return null;
            var result = new PageSchemaModel {Id =  page.Id, IdPerson = page.IdPerson, IdEvent = page.IdEvent, IdHall = page.IdHall,
                PageType = (int)page.Page};
            if (result.IdPerson != null) result.Person = PersonModelHelper.GetPersonModel(page.Person);
            if (result.IdEvent != null) result.Event = EventModelHelper.GetEventModel(page.Event);
            //TODO get Hall model
            return result;
        }

        public static PageBlockTypeModel GetPageBlockTypeModel(PageBlockType type)
        {
            return type != null ? new PageBlockTypeModel {Id = type.Id, Name = type.Name} : null;
        }

        public static PageBlock GetPageBlock(PageBlockModel model)
        {
            return model != null ? new PageBlock
            {
                Id = model.Id,
                IdBlockType = model.Type?.Id,
                IdPage = model.IdPage,
                Name = model.Name,
                Page = GetPage(model.Page)
            }
            : null;
        }

        public static PageSchema GetPage(PageSchemaModel model)
        {
            if (model == null) return null;
            var result = new PageSchema
            {
                Id = model.Id,
                Page = (PageTypes?)model.PageType
            };
            if (result.Page == PageTypes.Person) result.IdPerson = model.IdPerson;
            if (result.Page == PageTypes.Event) result.IdEvent = model.IdEvent;
            if (result.Page == PageTypes.Halls) result.IdHall = model.IdHall;
            return result;
        }
    }
}