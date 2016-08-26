using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Состав
    /// </summary>
    public class ActorGroup : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Состав участников
        /// </summary>
        public virtual IList<Actor> Actors  { get; set; }
    }
}
