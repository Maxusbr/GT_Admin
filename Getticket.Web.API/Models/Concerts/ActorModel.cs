using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Участник концерта
    /// </summary>
    public class ActorModel : BaseModel
    {
        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="PersonModel"/>
        /// </summary>
        public int IdPerson { get; set; }

        /// <summary>
        /// <see cref="PersonModel"/>
        /// </summary>
        public virtual PersonModel Person { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="ActorGroupModel"/>
        /// </summary>
        public int IdGroup { get; set; }

        /// <summary>
        /// <see cref="ActorGroupModel"/>
        /// </summary>
        public virtual ActorGroupModel Group  { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="ConcertProgrammModel"/>
        /// </summary>
        public int IdProgramm { get; set; }

        /// <summary>
        /// <see cref="ConcertProgrammModel"/>
        /// </summary>
        public virtual ConcertProgrammModel Programm { get; set; }
    }
}
