using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class GetticketDBContext : DbContext
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public GetticketDBContext() : base("name=Getticket.Web.API.Properties.Settings.GetticketConection")
        {
            // For logging queries for db in Debug window
            this.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }

        #region User Config
        /// <see cref="User" />
        public virtual DbSet<User> Users { get; set; }
        /// <see cref="UserInfo" />
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        /// <see cref="AccessRole" />
        public virtual DbSet<AccessRole> AccessRoles { get; set; }
        /// <see cref="UserStatus" />
        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        /// <summary>
        /// Настройки сущности User
        /// </summary>
        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
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
        #endregion

        #region Invites Config
        /// <see cref="InviteCode" />
        public virtual DbSet<InviteCode> InviteCodes { get; set; }

        /// <summary>
        /// Настройки сущности InviteCode
        /// </summary>
        public class InviteCodeConfiguration : EntityTypeConfiguration<InviteCode>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public InviteCodeConfiguration()
            {
                this
                    .HasRequired(ic => ic.User)
                    .WithRequiredDependent()
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion

        /// <summary>
        /// Настройка БД через Fluent API
        /// Имеет приоритет над Code First
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new InviteCodeConfiguration());
        }
    }
}
