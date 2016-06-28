using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Базовый класс сущности содержащий идентификатор
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
