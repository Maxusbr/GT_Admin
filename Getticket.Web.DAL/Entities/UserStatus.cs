using Getticket.Web.DAL.Enums;
using System;

namespace Getticket.Web.DAL.Entities
{
    public class UserStatus : BaseEntity
    {
        public UserStatus(){}

        public UserStatusType Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateTime { get; set; }

        public User User { get; set; }
    }

}
