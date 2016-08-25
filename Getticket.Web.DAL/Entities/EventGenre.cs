using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Сущность для жанра
    /// </summary>
    public class EventGenre : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

    }
}
