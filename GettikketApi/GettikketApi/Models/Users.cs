//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GettikketApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string LastEnter { get; set; }
        public string UserPhone { get; set; }
        public string UserMail { get; set; }
        public string UserRank { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Nullable<bool> Lock { get; set; }
    }
}
