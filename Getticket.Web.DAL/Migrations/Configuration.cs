namespace Getticket.Web.DAL.Migrations
{
    using Entities;
    using Enums;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Getticket.Web.DAL.Entities.GetticketDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // Migration command
        // Update-Database -ProjectName Getticket.Web.DAL -StartUpProjectName Getticket.Web.API -Force -Verbose
        protected override void Seed(GetticketDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            AccessRole admin = new AccessRole() { Name = "Admin", Desciption = "Full access", Id = 1, Role = Enums.AccessRoleType.Admin };
            context.AccessRoles.AddOrUpdate(ar => ar.Id, admin);
            context.SaveChanges();

            // md5 are:
            // test:    098f6bcd4621d373cade4e832627b4f6
            // deleted: da602f0b162fccbf6b150cfcfc7a7379
            // admin:   21232f297a57a5a743894a0e4a801fc3

            User user1 = new User()
            {
                UserName = "test@admin.su",
                Phone = "+79063332211",
                PasswordHash = "21232f297a57a5a743894a0e4a801fc3",
                AccessRoleId = 1,
                UserStatus = new UserStatus() { Name="seed", Description="", Status=UserStatusType.System},
                UserInfo = new UserInfo() { Id = 1, Name = "Тест", LastName = "Админ"}
            };

            User user2 = new User()
            {
                UserName = "deleted@admin.su",
                Phone = "+79153332211",
                PasswordHash = "da602f0b162fccbf6b150cfcfc7a7379",
                AccessRoleId = 1,
                UserStatus = new UserStatus() { Name = "seed", Description = "deleted", Status = UserStatusType.MarkDeleted },
                UserInfo = new UserInfo() { Id = 2, Name = "deleted", LastName = "Админ"}
            };

            User user3 = new User()
            {
                UserName = "admin@admin.su",
                Phone = "+79159998877",
                PasswordHash = "21232f297a57a5a743894a0e4a801fc3",
                AccessRoleId = 1,
                UserStatus = new UserStatus() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 3, Name = "admin", LastName = "Админ"}
            };

            context.Users.AddOrUpdate(u => u.Id, user1);
            context.Users.AddOrUpdate(u => u.Id, user2);
            context.Users.AddOrUpdate(u => u.Id, user3);

            context.SaveChanges();
        }
    }
}