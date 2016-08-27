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
        public virtual IList<ActorModel> Actors  { get; set; }
    }
}
