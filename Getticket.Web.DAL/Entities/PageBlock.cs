using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Блоки страницы
    /// </summary>
    public class PageBlock : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.PageSchema"/>
        /// </summary>
        public int IdPage { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.PageBlockType"/>
        /// </summary>
        public int? IdBlockType { get; set; }

        /// <summary>
        /// <see cref="Entities.PageSchema"/>
        /// </summary>
        [ForeignKey("IdPage")]
        public virtual PageSchema Page { get; set; }

        /// <summary>
        /// <see cref="Entities.PageBlockType"/>
        /// </summary>
        [ForeignKey("IdBlockType")]
        public virtual PageBlockType Type { get; set; }



    }
}
