﻿using System.Data.Entity;

namespace Getticket.Web.DAL.Entities
{
    public class GetticketDBContext : DbContext
    {
        public GetticketDBContext() : base("name=Getticket.Web.API.Properties.Settings.GetticketConection")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<User>()
               .HasRequired(u => u.UserInfo)
               .WithRequiredPrincipal()
               .WillCascadeOnDelete(true);

            modelBuilder
               .Entity<User>()
               .HasRequired(u => u.AccessRole)
               .WithRequiredPrincipal()
               .WillCascadeOnDelete(true);

            modelBuilder
               .Entity<User>()
               .HasRequired(u => u.UserStatus)
               .WithRequiredPrincipal()
               .WillCascadeOnDelete(true);
        }
    }
}
