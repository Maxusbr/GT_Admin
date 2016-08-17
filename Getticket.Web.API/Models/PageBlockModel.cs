using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Блоки страницы
    /// </summary>
    public class PageBlockModel : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для <see cref="PageSchemaModel"/>
        /// </summary>
        public int IdPage { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="PageBlockTypeModel"/>
        /// </summary>
        public int? IdBlockType { get; set; }

        /// <summary>
        /// <see cref="PageSchemaModel"/>
        /// </summary>
        public PageSchemaModel Page { get; set; }

        /// <summary>
        /// <see cref="PageBlockTypeModel"/>
        /// </summary>
        public PageBlockTypeModel Type { get; set; }

        /// <summary>
        /// Источник
        /// </summary>
        public int? UserPageCategoryId { get; set; }
        /// <summary>
        /// Источник
        /// </summary>
        public string UserPageCategory { get; set; }
    }
}
