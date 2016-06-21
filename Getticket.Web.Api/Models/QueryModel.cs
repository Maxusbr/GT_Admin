using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    public class QueryModel<T>
    {
        [Required]
        public AuthModel Credentails { get; set; }
        public T Payload { get; set; }
    }
}