using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Схема размещения описания персоны
    /// </summary>
    public class PageSchema : BaseEntity
    {
        /// <summary>
        /// Стрраница перехода
        /// </summary>
        public PageTypes? Page { get; set; }
        
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        public int? IdPerson { get; set; }
        
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        public int? IdEvent { get; set; }
        
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Hall"/>
        /// </summary>
        public int? IdHall { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

    }
}
