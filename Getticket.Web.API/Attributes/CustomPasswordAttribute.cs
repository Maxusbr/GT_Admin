using Getticket.Web.API.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Attributes
{
    /// <summary>
    /// Проверяет поле на соответствие формату пароля
    /// Для проверки на то что поле не пусто использовать [Required]
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CustomPasswordAttribute : ValidationAttribute
    {
        private string PasswordErrorMessage = "Password must be from 5 to 20 english characters with numbers";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!String.IsNullOrEmpty((string) value) && !PasswordService.IsPasswordAcceptable((string) value))
            {
                return new ValidationResult(PasswordErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}