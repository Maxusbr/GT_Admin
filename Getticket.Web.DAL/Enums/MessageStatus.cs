namespace Getticket.Web.DAL.Enums
{
    /// <summary>
    /// Статус сообщения пользователя
    /// </summary>
    public enum MessageStatus
    {
        /// <summary>
        /// Новый
        /// </summary>
        New = 0,
        /// <summary>
        /// Отправлено
        /// </summary>
        Send = 1,
        /// <summary>
        /// Сбой отправки
        /// </summary>
        ErrorSend = 2,
        /// <summary>
        /// Прочитано
        /// </summary>
        Reed = 3
    }
}
