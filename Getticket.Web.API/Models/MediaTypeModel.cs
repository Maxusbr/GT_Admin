using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// ��� �����
    /// </summary>
    public class MediaTypeModel : BaseModel
    {
        /// <summary>
        /// ���
        /// </summary>
        [Required]public string Name { get; set; }

    }
}
