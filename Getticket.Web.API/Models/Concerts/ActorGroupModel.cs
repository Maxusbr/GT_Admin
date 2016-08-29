using System.Collections.Generic;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Состав
    /// </summary>
    public class ActorGroupModel : BaseModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Состав участников
        /// </summary>
        public virtual IEnumerable<ActorModel> Actors  { get; set; }
    }
}
