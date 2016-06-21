using Getticket.Web.API.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
     AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CustomPhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                // Если поле пусто говорим что поле прошло проверку,
                // т.к. на пустоту должен проверять [Required]
                return true;
            }
            return PhoneService.IsPhoneValid((string) value);
        }
    }
}