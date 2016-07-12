using System.Text.RegularExpressions;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис проверки и конвертации телефонного номера
    /// </summary>
    public static class PhoneService
    {
        /// <summary>
        /// Проверяет номер телефона на соответствие 
        /// Российскому мобильному номеру телефона
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsPhoneValid(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return false;
            }
            Regex regEx = new Regex("^((8|\\+7)[\\- ]?)?[(]?[0-9]{3}[)]?[\\- ]?[0-9]{3}[\\- ]?[0-9]{2}[\\- ]?[0-9]{2}$");
            return regEx.Match(phone).Success;
        }

        /// <summary>
        /// Преобразует Российский мобильный номер телефона
        /// к виду +7[0-9]{10}
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string PhoneConvert(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return phone;
            }
            phone = Regex.Replace(phone, "[-)( ]", "");
            if (phone.StartsWith("+7"))
            {
                return phone;
            }

            if (phone.Length == 10)
            {
                return phone.Insert(0, "+7");
            }
            return Regex.Replace(phone, "^8", "+7");
        }
    }
}