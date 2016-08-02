using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Persons;


namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Ключевые слова
    /// </summary>
    public class TagAntroModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagAntroModel(){}

        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int IdPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int IdAntroName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public int Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMoreThan { get; set; }
        /// <summary>
        /// Где используется
        /// </summary>

        public PersonAntroNameModel AntroName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PersonModel Person { get; set; }
    }
}
