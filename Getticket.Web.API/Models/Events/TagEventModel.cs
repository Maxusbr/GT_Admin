using System.Collections.Generic;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Теги/подкатегории
    /// </summary>
    public class TagEventModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Где используется
        /// </summary>
        public virtual IList<string> UsesType { get; set; } = new List<string>();
    }
}
