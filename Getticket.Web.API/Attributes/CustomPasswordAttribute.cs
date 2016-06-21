using Getticket.Web.API.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
     AttributeTargets.Field, AllowMultiple = false)]
    public class CustomPasswordAttribute : ValidationAttribute
    {
        public string PasswordErrorMessage = "Passwod must be from 5 to 20 english characters with numbers";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty((string) value) || !PasswordService.IsPasswordAcceptable((string)value))
            {
                return new ValidationResult(PasswordErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}