using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Getticket.Web.DAL.Entities
{
    public class GetticketDBContext : DbContext
    {
        public GetticketDBContext() : base("name=Getticket.Web.API.Properties.Settings.GetticketConection")
        {
            // For logging queries for db in Debug window
            this.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<AccessRole> AccessRoles { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                this
                    .HasRequired(u => u.UserInfo)
                    .WithRequiredPrincipal(ui => ui.User)
                    .WillCascadeOnDelete(true);

                this
                    .HasRequired(u => u.UserStatus)
                    .WithRequiredPrincipal(us => us.User)
                    .WillCascadeOnDelete(true);

                this
                    .HasRequired(u => u.AccessRole)
                    .WithMany(ar => ar.Users)
                    .HasForeignKey(u => u.AccessRoleId)
                    .WillCascadeOnDelete(false);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
