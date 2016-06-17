using System.Data.Entity;

namespace Getticket.Web.DAL.Entities
{
    class GetticketDBContext : DbContext
    {
        public GetticketDBContext() : base("name=Getticket.Web.API.Properties.Settings.getticketConection")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
