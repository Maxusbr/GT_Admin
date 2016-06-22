using Getticket.Web.API.Properties;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис создания, проверки и хеширования паролей
    /// </summary>
    public class PasswordService
    {

        /// <summary>
        /// Генерирует пароль длиной PasswordMaxLength
        /// используя набор PasswordAcceptableSymbols
        /// </summary>
        /// <returns>Сгенерированный пароль</returns>
        public static string GeneratePasswordString()
        {
            return GeneratePasswordString(Settings.Default.PasswordMaxLength);
        }

        /// <summary>
        /// Генерирует пароль длиной <paramref name="size"/>
        /// используя набор PasswordAcceptableSymbols
        /// </summary>
        /// <param name="size">кол-во символов не менее PasswordMinLength</param>
        /// <returns>Сгенерированный пароль</returns>
        public static string GeneratePasswordString(int size)
        {
            if (size < Settings.Default.PasswordMinLength)
            {
                size = Settings.Default.PasswordMinLength;
            }
            char[] chars = new char[62];
            chars = Settings.Default.PasswordAcceptableSymbols.ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Генерирует MD5 Hash для пароля <paramref name="OriginalPass"/>, если
        /// переданная строка <c>null</c> сгенерируется хеш от пустой строки
        /// GeneratePasswordString
        /// </summary>
        /// <param name="OriginalPass">строка в кодировке UTF8</param>
        /// <returns>возвращает MD5 от пароля</returns>
        public static string GeneratePasswordHash(string OriginalPass)
        {
            if (OriginalPass == null)
            {
                OriginalPass = String.Empty;
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
            if (Password == null)
            {
                return false;
            }
            string regex = "[" + Settings.Default.PasswordAcceptableSymbols + "]{"
                + Settings.Default.PasswordMinLength + "," + Settings.Default.PasswordMaxLength + "}$";
            Regex testPass = new Regex(regex);
            return testPass.IsMatch(Password);
        }
    }
}