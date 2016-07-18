using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Infrastructure
{
    /// <summary>
    /// Информация о странице
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public PageInfo()
        {
            PageNumber = 1;
            PageSize = 20;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PageInfo(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        /// <summary>
        /// Пропустить
        /// </summary>
        public int Skip => (PageNumber - 1) * PageSize;
    }
}
