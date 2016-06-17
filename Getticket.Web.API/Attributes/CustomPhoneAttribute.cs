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
            bool result = false;
            if (PhoneService.PhoneValidate((string)value))
            {
                result = true;
            }
            return result;
        }
    }
}