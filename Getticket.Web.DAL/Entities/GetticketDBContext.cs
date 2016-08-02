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
            // PROD disable it
            this.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }

        #region User Config
        /// <see cref="User" />
        public virtual DbSet<User> Users { get; set; }
        /// <see cref="UserInfo" />
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        /// <see cref="Entities.AccessRoles" />
        public virtual DbSet<AccessRoles> AccessRoles { get; set; }
        /// <see cref="Entities.UserStatuses" />
        public virtual DbSet<UserStatuses> UserStatuses { get; set; }

        /// <summary>
        /// Настройки сущности <see cref="User"/>
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
                    .HasRequired(u => u.UserStatuses)
                    .WithRequiredPrincipal(us => us.User)
                    .WillCascadeOnDelete(true);

                this
                    .HasRequired(u => u.AccessRoles)
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
        /// Настройки сущности <see cref="InviteCode"/>
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

        #region Events Config
        /// <see cref="Event"/>
        public virtual DbSet<Event> Events { get; set; }
        /// <see cref="EventType"/>
        public virtual DbSet<EventType> EventTypes { get; set; }
        /// <summary>
        /// Настройка сущности <see cref="Event"/>
        /// </summary>
        public class EventConfiguration : EntityTypeConfiguration<Event>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public EventConfiguration()
            {

            }
        }
        #endregion

        #region EventsLog Config
        /// <see cref="EventLog"/>
        public virtual DbSet<EventLog> EventLogs { get; set; }

        /// <summary>
        /// Настройка сущности <see cref="EventLog"/>
        /// </summary>
        public class EventLogConfiguration : EntityTypeConfiguration<EventLog>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public EventLogConfiguration()
            {
                this
                    .HasRequired(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.EventId)
                    .WillCascadeOnDelete(false);

                this
                    .HasRequired(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion

        /// <summary>
        /// <see cref="Entities.Country"/>
        /// </summary>
        public virtual DbSet<Country> Country { get; set; }

        /// <summary>
        /// <see cref="CountryPlace"/>
        /// </summary>
        public virtual DbSet<CountryPlace> CountryPlaces { get; set; }

        /// <summary>
        /// <see cref="Entities.Sex"/>
        /// </summary>
        public virtual DbSet<Sex> Sex { get; set; }


        #region Person Config

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        public virtual DbSet<Person> Person { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonAntro"/>
        /// </summary>
        public virtual DbSet<PersonAntro> PersonAntro { get; set; }

        /// <summary>
        /// <see cref="PersonAntroName"/>
        /// </summary>
        public virtual DbSet<PersonAntroName> PersonAntroNames { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonChangeParam"/>
        /// </summary>
        public virtual DbSet<PersonChangeParam> PersonChangeParam { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonChangeLog"/>
        /// </summary>
        public virtual DbSet<PersonChangeLog> PersonChangeLog { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonConnectionType"/>
        /// </summary>
        public virtual DbSet<PersonConnectionType> PersonConnectionType { get; set; }

        /// <summary>
        /// <see cref="PersonConnection"/>
        /// </summary>
        public virtual DbSet<PersonConnection> PersonConnections { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonDescriptionType"/>
        /// </summary>
        public virtual DbSet<PersonDescriptionType> PersonDescriptionType { get; set; }

        /// <summary>
        /// <see cref="PersonDescription"/>
        /// </summary>
        public virtual DbSet<PersonDescription> PersonDescriptions { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonMedia"/>
        /// </summary>
        public virtual DbSet<PersonMedia> PersonMedia { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonMediaType"/>
        /// </summary>
        public virtual DbSet<PersonMediaType> PersonMediaType { get; set; }

        /// <summary>
        /// <see cref="PersonSocialLinkType"/>
        /// </summary>
        public virtual DbSet<PersonSocialLinkType> PersonSocialLinkTypes { get; set; }

        /// <summary>
        /// <see cref="PersonSocialLink"/>
        /// </summary>
        public virtual DbSet<PersonSocialLink> PersonSocialLinks { get; set; }

        /// <summary>
        /// <see cref="PersonFactType"/>
        /// </summary>
        public virtual DbSet<PersonFactType> PersonFactTypes { get; set; }

        /// <summary>
        /// <see cref="PersonFact"/>
        /// </summary>
        public virtual DbSet<PersonFact> PersonFacts { get; set; }

        /// <summary>
        /// Настройка сущности <see cref="Entities.Person"/>
        /// </summary>
        public class PersonConfiguration : EntityTypeConfiguration<Person>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public PersonConfiguration()
            {

            }
        }
        #endregion

        #region Tags
        /// <see cref="Tag"/>
        public virtual DbSet<Tag> Tags { get; set; }

        /// <see cref="TagAntro"/>
        public virtual DbSet<TagAntro> TagAntros { get; set; }

        /// <see cref="TagAntroLink"/>
        public virtual DbSet<TagAntroLink> TagAntroLinks { get; set; }

        /// <see cref="TagDescriptionLink"/>
        public virtual DbSet<TagDescriptionLink> TagDescriptionLinks { get; set; }

        /// <see cref="TagLink"/>
        public virtual DbSet<TagLink> TagLinks { get; set; }

        /// <summary>
        /// Настройки сущности <see cref="Tag"/>
        /// </summary>
        public class TagConfiguration : EntityTypeConfiguration<Tag>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public TagConfiguration()
            {
                
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
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new EventLogConfiguration());
        }
    }
}
