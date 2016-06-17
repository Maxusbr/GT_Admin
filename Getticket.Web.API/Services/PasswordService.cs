using Getticket.Web.API.Properties;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Getticket.Web.API.Services
{
    public class PasswordService
    {

        /// <summary>
        /// Генерирует пароль длиной maxSize(PasswordMaxLength)
        /// используя набор PasswordAcceptableSymbols
        /// </summary>
        /// <param name="maxSize"></param>
        /// <returns>пароль</returns>
        public static string GeneratePasswordString()
        {
            return GeneratePasswordString(Settings.Default.PasswordMaxLength);
        }
        public static string GeneratePasswordString(int maxSize)
        {
            char[] chars = new char[62];
            chars = Settings.Default.PasswordAcceptableSymbols.ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Генерирует MD5 Hash для пароля OriginalPas, если
        /// переданная строка пустая или null используется
        /// GeneratePasswordString
        /// </summary>
        /// <param name="OriginalPass">строка в кодировке UTF8</param>
        /// <returns>возвращает MD5 от пароля</returns>
        public static string GeneratePasswordHash(string OriginalPass)
        {
            if (String.IsNullOrEmpty(OriginalPass))
            {
                return OriginalPass;
            }
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(OriginalPass);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Проверяет является ли пароль введенный пользователем допустимым
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool IsPasswordAcceptable(string Password)
        {
            string regex = "[" + Settings.Default.PasswordAcceptableSymbols + "]{"
                + Settings.Default.PasswordMinLength + "," + Settings.Default.PasswordMaxLength + "}$";
            Regex testPass = new Regex(regex);
            return testPass.IsMatch(Password);
        }



        [Obsolete]
        // Метод больше не используется
        // TODO удалить метод после очисти ссылок на него
        public static string CheckPassAndHashIt(string OriginalPass = null, int maxSize = 20)
        {
            if (String.IsNullOrEmpty(OriginalPass))
            {
                OriginalPass = GeneratePasswordString(maxSize);
            }

            return GeneratePasswordHash(OriginalPass);
        }
    }
}