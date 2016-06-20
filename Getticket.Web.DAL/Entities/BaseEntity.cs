using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.DAL.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
