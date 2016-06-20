namespace Getticket.Web.DAL.Migrations
{
    using API.Helpers;
    using Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Getticket.Web.DAL.Entities.GetticketDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // Migration command
        // Update-Database -ProjectName Getticket.Web.DAL -StartUpProjectName Getticket.Web.API -Force -Verbose
        protected override void Seed(Getticket.Web.DAL.Entities.GetticketDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            AccessRole admin = new AccessRole() { Name = "Admin", Desciption = "Full access", Id = 1, Role = Enums.AccessRoleType.Admin };
            context.AccessRoles.AddOrUpdate(ar => ar.Id, admin);
            context.SaveChanges();

            User user1 = new User()
            {
                UserName = "test@admin.su",
                AccessRoleId = 1,
                UserStatus = UserStatusHelper.SystemSeed(),
                UserInfo = new UserInfo() { Id = 1, Name = "Тест", LastName = "Админ", Phone = "+79063332211"}
            };

            User user2 = new User()
            {
                UserName = "deleted@admin.su",
                AccessRoleId = 1,
                UserStatus = UserStatusHelper.Deleted(),
                UserInfo = new UserInfo() { Id = 2, Name = "deleted", LastName = "Админ", Phone = "+79153332211" }
            };

            context.Users.AddOrUpdate(u => u.Id, user1);
            context.Users.AddOrUpdate(u => u.Id, user2);

            context.SaveChanges();
        }
    }
}