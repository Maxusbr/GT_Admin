using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;

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
    }
}