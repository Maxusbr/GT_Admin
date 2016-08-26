using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Участник концерта
    /// </summary>
    public class Actor : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="Entities.Person"/>
        /// </summary>
        public int IdPerson { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// <see cref="ActorGroup"/>
        /// </summary>
        public virtual ActorGroup Group  { get; set; }

        /// <summary>
        /// <see cref="ConcertProgramm"/>
        /// </summary>
        public virtual ConcertProgramm Programm { get; set; }
    }
}
