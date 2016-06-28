using Getticket.Web.API.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Attributes
{
    /// <summary>
    /// Проверяет поле на соответствие формату
    /// Российского номера мобильного телефона;
    /// Для проверки на то что поле не пусто использовать [Required]
    /// </summary>
    [AttributeUsage(AttributeTargets.Property |
     AttributeTargets.Field, AllowMultiple = false)]
    public class CustomPhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (String.IsNullOrEmpty((string) value))
            {
                return true;
            }
            return PhoneService.IsPhoneValid((string) value);
        }
    }
}