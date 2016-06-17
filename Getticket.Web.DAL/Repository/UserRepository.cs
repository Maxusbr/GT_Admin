using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Repository
{
    public class UserRepository
    {
        private GetticketDBContext db;

        public UserRepository()
        {
            this.db = new GetticketDBContext();
        }

       
    }
}
