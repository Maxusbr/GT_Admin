using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Программа концерта
    /// </summary>
    public class ActorProgrammModel
    {
        public ConcertProgrammModel Programm { get; set; }
        /// <summary>
        /// Участники <see cref="ActorModel"/>
        /// </summary>
        public virtual IEnumerable<ActorModel> Actors { get; set; }


        public IEnumerable<ActorGroupModel> Group { get; set; }
    }
}
