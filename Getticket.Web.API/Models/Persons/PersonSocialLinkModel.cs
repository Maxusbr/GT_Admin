﻿using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Ссылка на соц. сети
    /// </summary>
    public class PersonSocialLinkModel : BaseModel
    {
        /// <summary>
        /// Ссылка
        /// </summary>
        [Required]public string Link { get; set; }
        public string Description { get; set; }

        public int id_Person { get; set; }
        public int Destination { get; set; }
        [Required]public int IdSocialLinkType { get; set; }
        public string PersonSocialLinkType { get; set; }
        public LastChangeModel LastChange { get; set; }
    }
}
