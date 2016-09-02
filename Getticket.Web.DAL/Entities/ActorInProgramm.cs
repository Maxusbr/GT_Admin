using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Участник концерта
    /// </summary>
    public class ActorInProgramm
    {
        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="Entities.Actor"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdActor { get; set; }

        /// <summary>
        /// <see cref="Entities.Actor"/>
        /// </summary>
        [ForeignKey("IdActor")]
        public virtual Actor Actor { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="Entities.ConcertProgramm"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdProgramm { get; set; }

        /// <summary>
        /// <see cref="ConcertProgramm"/>
        /// </summary>
        [ForeignKey("IdProgramm")]
        public virtual ConcertProgramm Programm { get; set; }
    }
}
