using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    public class QueryModel<T>
    {
        [Required]
        public AuthModel Credentails { get; set; }
        public T Payload { get; set; }
    }
}