﻿using System.Data.Entity;
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
            //this.Configuration.LazyLoadingEnabled = false;
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
        /// <see cref="Entities.UserMessage" />
        public virtual DbSet<UserMessage> UserMessages { get; set; }
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

        /// <see cref="EventCategory"/>
        public virtual DbSet<EventCategory> EventCategories { get; set; }

        /// <see cref="EventDescription"/>
        public virtual DbSet<EventDescription> EventDescriptions { get; set; }

        ///// <see cref="EventDescriptionType"/>
        //public virtual DbSet<EventDescriptionType> EventDescriptionTypes { get; set; }

        /// <see cref="EventGenre"/>
        public virtual DbSet<EventGenre> EventGenres { get; set; }

        /// <see cref="EventGenreLink"/>
        public virtual DbSet<EventGenreLink> EventGenreLinks { get; set; }

        /// <see cref="EventLinkEvent"/>
        public virtual DbSet<EventLinkEvent> EventLinkEvents { get; set; }

        /// <see cref="EventLinkPerson"/>
        public virtual DbSet<EventLinkPerson> EventLinkPersons { get; set; }

        /// <see cref="EventMedia"/>
        public virtual DbSet<EventMedia> EventMedias { get; set; }

        /// <see cref="EventMediaLinkEvent"/>
        public virtual DbSet<EventMediaLinkEvent> EventMediaLinkEvents { get; set; }

        /// <see cref="EventMediaLinkPerson"/>
        public virtual DbSet<EventMediaLinkPerson> EventMediaLinkPersons { get; set; }

        /// <see cref="EventConnection"/>
        public virtual DbSet<EventConnection> EventConnections { get; set; }

        /// <see cref="EventDescriptionTizerLink"/>
        public virtual DbSet<EventDescriptionTizerLink> EventDescriptionTizerLinks { get; set; }

        /// <see cref="EventFact"/>
        public virtual DbSet<EventFact> EventFacts { get; set; }

        /// <see cref="EventFactType"/>
        public virtual DbSet<EventFactType> EventFactTypes { get; set; }

        /// <summary>
        /// Настройка сущности <see cref="Entities.PersonDescriptionTizerLink"/>
        /// </summary>
        public class EventDescriptionTizerLinkConfiguration : EntityTypeConfiguration<EventDescriptionTizerLink>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public EventDescriptionTizerLinkConfiguration()
            {
                this
                    .HasRequired(e => e.Description)
                    .WithMany()
                    .HasForeignKey(e => e.IdStaticDescription)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Tizer)
                    .WithMany()
                    .HasForeignKey(e => e.IdTizer)
                    .WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.PersonDescription"/>
        /// </summary>
        public class EventDescriptionConfiguration : EntityTypeConfiguration<EventDescription>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public EventDescriptionConfiguration()
            {
                this
                    .Ignore(o => o.StaticDescription);

            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.MediaLinkEvent"/>
        /// </summary>
        public class EventMediaLinkEventConfiguration : EntityTypeConfiguration<EventMediaLinkEvent>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public EventMediaLinkEventConfiguration()
            {
                this
                    .HasRequired(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.IdEvent)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Media)
                    .WithMany()
                    .HasForeignKey(e => e.IdMedia)
                    .WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.MediaLinkPerson"/>
        /// </summary>
        public class EventMediaLinkPersonConfiguration : EntityTypeConfiguration<EventMediaLinkPerson>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public EventMediaLinkPersonConfiguration()
            {
                this
                    .HasRequired(e => e.Person)
                    .WithMany()
                    .HasForeignKey(e => e.IdPerson)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Media)
                    .WithMany()
                    .HasForeignKey(e => e.IdMedia)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion

        #region Log Config
        /// <see cref="EventLog"/>
        public virtual DbSet<EventLog> EventLogs { get; set; }

        /// <see cref="PersonLog"/>
        public virtual DbSet<PersonLog> PersonLogs { get; set; }

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
        /// <see cref="Company"/>
        /// </summary>
        public virtual DbSet<Company> Companies { get; set; }

        /// <summary>
        /// <see cref="Entities.MediaType"/>
        /// </summary>
        public virtual DbSet<MediaType> MediaTypes { get; set; }

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
        /// <see cref="Entities.ConnectionType"/>
        /// </summary>
        public virtual DbSet<ConnectionType> ConnectionTypes { get; set; }

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
        /// <see cref="PersonDescriptionTizerLink"/>
        /// </summary>
        public virtual DbSet<PersonDescriptionTizerLink> PersonDescriptionTizerLinks { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonMedia"/>
        /// </summary>
        public virtual DbSet<PersonMedia> PersonMedia { get; set; }

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
        /// <see cref="PageSchema"/>
        /// </summary>
        public virtual DbSet<PageSchema> PageSchemas { get; set; }

        /// <summary>
        /// <see cref="PageBlock"/>
        /// </summary>
        public virtual DbSet<PageBlock> PageBlocks { get; set; }

        /// <summary>
        /// <see cref="PageBlockType"/>
        /// </summary>
        public virtual DbSet<PageBlockType> PageBlockTypes { get; set; }

        /// <summary>
        /// <see cref="UserPageCategory"/>
        /// </summary>
        public virtual DbSet<UserPageCategory> UserPageCategories { get; set; }

        /// <summary>
        /// <see cref="MediaLinkPerson"/>
        /// </summary>
        public virtual DbSet<MediaLinkPerson> MediaPersonLinks { get; set; }

        /// <summary>
        /// <see cref="MediaLinkEvent"/>
        /// </summary>
        public virtual DbSet<MediaLinkEvent> MediaEventLinks { get; set; }

        /// <summary>
        /// <see cref="AntroLinkPerson"/>
        /// </summary>
        public virtual DbSet<AntroLinkPerson> AntroPersonLinks { get; set; }

        /// <summary>
        /// <see cref="AntroLinkEvent"/>
        /// </summary>
        public virtual DbSet<AntroLinkEvent> AntroEventLinks { get; set; }

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

        /// <summary>
        /// Настройка сущности <see cref="Entities.MediaLinkEvent"/>
        /// </summary>
        public class MediaLinkEventConfiguration : EntityTypeConfiguration<MediaLinkEvent>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public MediaLinkEventConfiguration()
            {
                this
                    .HasRequired(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.IdEvent)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Media)
                    .WithMany()
                    .HasForeignKey(e => e.IdMedia)
                    .WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.MediaLinkPerson"/>
        /// </summary>
        public class MediaLinkPersonConfiguration : EntityTypeConfiguration<MediaLinkPerson>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public MediaLinkPersonConfiguration()
            {
                this
                    .HasRequired(e => e.Person)
                    .WithMany()
                    .HasForeignKey(e => e.IdPerson)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Media)
                    .WithMany()
                    .HasForeignKey(e => e.IdMedia)
                    .WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.PersonDescriptionTizerLink"/>
        /// </summary>
        public class PersonDescriptionTizerLinkConfiguration : EntityTypeConfiguration<PersonDescriptionTizerLink>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public PersonDescriptionTizerLinkConfiguration()
            {
                this
                    .HasRequired(e => e.Description)
                    .WithMany()
                    .HasForeignKey(e => e.IdStaticDescription)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Tizer)
                    .WithMany()
                    .HasForeignKey(e => e.IdTizer)
                    .WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.MediaLinkEvent"/>
        /// </summary>
        public class AntroLinkEventConfiguration : EntityTypeConfiguration<AntroLinkEvent>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public AntroLinkEventConfiguration()
            {
                this
                    .HasRequired(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.IdEvent)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Antro)
                    .WithMany()
                    .HasForeignKey(e => e.IdAntro)
                    .WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.MediaLinkPerson"/>
        /// </summary>
        public class AntroLinkPersonConfiguration : EntityTypeConfiguration<AntroLinkPerson>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public AntroLinkPersonConfiguration()
            {
                this
                    .HasRequired(e => e.Person)
                    .WithMany()
                    .HasForeignKey(e => e.IdPerson)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Antro)
                    .WithMany()
                    .HasForeignKey(e => e.IdAntro)
                    .WillCascadeOnDelete(false);
            }
        }


        /// <summary>
        /// Настройка сущности <see cref="Entities.PersonDescription"/>
        /// </summary>
        public class PersonDescriptionConfiguration : EntityTypeConfiguration<PersonDescription>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public PersonDescriptionConfiguration()
            {
                this
                    .Ignore(o => o.StaticDescription);

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

        /// <see cref="TagPersonDescriptionLink"/>
        public virtual DbSet<TagPersonDescriptionLink> TagDescriptionLinks { get; set; }

        /// <see cref="TagPersonLink"/>
        public virtual DbSet<TagPersonLink> TagPersonLinks { get; set; }

        /// <see cref="TagPersonMediaLink"/>
        public virtual DbSet<TagPersonMediaLink> TagPersonMediaLinks { get; set; }

        /// <see cref="TagEvent"/>
        public virtual DbSet<TagEvent> EventCategoryTags { get; set; }

        /// <see cref="TagEventLink"/>
        public virtual DbSet<TagEventLink> TagEventLinks { get; set; }

        /// <see cref="TagEventDescriptionLink"/>
        public virtual DbSet<TagEventDescriptionLink> TagEventDescriptionLinks { get; set; }

        /// <see cref="TagEventMediaLink"/>
        public virtual DbSet<TagEventMediaLink> TagEventMediaLinks { get; set; }

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

        #region Concert

        /// <summary>
        /// <see cref="Entities.ConcertSchedule"/>
        /// </summary>
        public virtual DbSet<ConcertSchedule> ConcertSchedules { get; set; }

        /// <summary>
        /// <see cref="Entities.ConcertDateRange"/>
        /// </summary>
        public virtual DbSet<ConcertDateRange> ConcertDateRanges { get; set; }

        /// <summary>
        /// <see cref="Entities.ConcertProgramm"/>
        /// </summary>
        public virtual DbSet<ConcertProgramm> ConcertProgramms { get; set; }

        /// <summary>
        /// <see cref="Entities.Actor"/>
        /// </summary>
        public virtual DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// <see cref="Entities.ActorGroup"/>
        /// </summary>
        public virtual DbSet<ActorGroup> ActorGroups { get; set; }

        /// <summary>
        /// <see cref="Entities.Hall"/>
        /// </summary>
        public virtual DbSet<Hall> Halls { get; set; }

        /// <summary>
        /// <see cref="Entities.ConcertPlace"/>
        /// </summary>
        public virtual DbSet<ConcertPlace> ConcertPlaces { get; set; }

        /// <summary>
        /// <see cref="Entities.SeriesName"/>
        /// </summary>
        public virtual DbSet<SeriesName> Series { get; set; }

        /// <summary>
        /// <see cref="Entities.SeriesName"/>
        /// </summary>
        public virtual DbSet<SeriesConcert> SeriesConcerts { get; set; }

        /// <summary>
        /// <see cref="Entities.ConcertTicket"/>
        /// </summary>
        public virtual DbSet<ConcertTicket> ConcertTickets { get; set; }

        ///// <see cref="Entities.ActorInProgramm"/>
        //public virtual DbSet<ActorInProgramm> ActorInProgramms { get; set; }

        /// <summary>
        /// Настройка сущности <see cref="Entities.SeriesConcert"/>
        /// </summary>
        public class SeriesEventConfiguration : EntityTypeConfiguration<SeriesConcert>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public SeriesEventConfiguration()
            {
                this
                    .HasRequired(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.EventId)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(e => e.Series)
                    .WithMany()
                    .HasForeignKey(e => e.SeriesId)
                    .WillCascadeOnDelete(false);
            }
        }


        public class ProgrammConfiguration : EntityTypeConfiguration<Actor>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public ProgrammConfiguration()
            {
                this
                    .HasMany(cr => cr.Programms)
                    .WithMany(c => c.Actors)
                    .Map(x => {
                        x.MapLeftKey("IdActor");
                        x.MapRightKey("IdProgramm");
                        x.ToTable("ActorInProgramms");
                    });
            }
        }

        /// <summary>
        /// Настройка сущности <see cref="Entities.PersonDescriptionTizerLink"/>
        /// </summary>
        //public class ProgrammConfiguration : EntityTypeConfiguration<ConcertProgramm>
        //{
        //    /// <summary>
        //    /// Конструктр
        //    /// </summary>
        //    public ProgrammConfiguration()
        //    {
        //        this
        //            .HasMany(e => e.Actors)
        //            .WithRequired()
        //            .WillCascadeOnDelete(true);
        //    }
        //}

        /// <summary>
        /// Настройка сущности <see cref="Entities.PersonDescriptionTizerLink"/>
        /// </summary>
        public class ActorConfiguration : EntityTypeConfiguration<Actor>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public ActorConfiguration()
            {
                this
                    .HasMany(e => e.Programms)
                    .WithRequired()
                    .WillCascadeOnDelete(true);
            }
        }
        /// <summary>
        /// Настройка сущности <see cref="Entities.Event"/>
        /// </summary>
        public class EventConfiguration : EntityTypeConfiguration<Event>
        {
            /// <summary>
            /// Конструктр
            /// </summary>
            public EventConfiguration()
            {
                this
                    .HasMany(o => o.Series)
                    .WithRequired(o => o.Event)
                    .HasForeignKey(o => o.EventId)
                    .WillCascadeOnDelete(false);
                this
                    .HasRequired(ic => ic.Tickets)
                    .WithRequiredPrincipal(t => t.Event)
                    .WillCascadeOnDelete(true);
                this
                    .HasMany(ic => ic.Calendar)
                    .WithRequired(t => t.Event)
                    .HasForeignKey(o => o.IdEvent)
                    .WillCascadeOnDelete(true);
                //this
                //    .HasRequired(ic => ic.Hall)
                //    .WithRequiredPrincipal()
                //    .WillCascadeOnDelete(false);
                //this
                //    .HasRequired(ic => ic.ConcertPlace)
                //    .WithRequiredPrincipal()
                //    .WillCascadeOnDelete(false);
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
            modelBuilder.Configurations.Add(new EventDescriptionConfiguration());
            modelBuilder.Configurations.Add(new EventDescriptionTizerLinkConfiguration());
            modelBuilder.Configurations.Add(new EventLogConfiguration());
            modelBuilder.Configurations.Add(new PersonDescriptionTizerLinkConfiguration());
            modelBuilder.Configurations.Add(new PersonDescriptionConfiguration());
            modelBuilder.Configurations.Add(new MediaLinkPersonConfiguration());
            modelBuilder.Configurations.Add(new MediaLinkEventConfiguration());
            modelBuilder.Configurations.Add(new AntroLinkPersonConfiguration());
            modelBuilder.Configurations.Add(new AntroLinkEventConfiguration());
            modelBuilder.Configurations.Add(new EventMediaLinkPersonConfiguration());
            modelBuilder.Configurations.Add(new EventMediaLinkEventConfiguration());
            modelBuilder.Configurations.Add(new SeriesEventConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new ProgrammConfiguration());
            //modelBuilder.Configurations.Add(new ActorConfiguration());

        }
    }
}
