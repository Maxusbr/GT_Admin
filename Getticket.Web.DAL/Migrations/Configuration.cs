using System;

namespace Getticket.Web.DAL.Migrations
{
    using Entities;
    using Enums;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GetticketDBContext>
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
            // teest:    ccfcb5961cb870496289a62c2a6f728c78feb49f448972daf0a6f098a903be08
            // deleted:  1185f37d33b0f89e331f101a51bb8e51165c7efda15950b86a3ebcbb363f898e
            // admin:    8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918

            User user1 = new User()
            {
                UserName = "teest@admin.su",
                Phone = "+79063332211",
                PasswordHash = "ccfcb5961cb870496289a62c2a6f728c78feb49f448972daf0a6f098a903be08",
                AccessRoleId = 1,
                UserStatus = new UserStatus() { Name="seed", Description="", Status=UserStatusType.System},
                UserInfo = new UserInfo() { Id = 1, Name = "Тест", LastName = "Админ"}
            };

            User user2 = new User()
            {
                UserName = "deleted@admin.su",
                Phone = "+79153332211",
                PasswordHash = "1185f37d33b0f89e331f101a51bb8e51165c7efda15950b86a3ebcbb363f898e",
                AccessRoleId = 1,
                UserStatus = new UserStatus() { Name = "seed", Description = "deleted", Status = UserStatusType.MarkDeleted },
                UserInfo = new UserInfo() { Id = 2, Name = "deleted", LastName = "Админ"}
            };

            User user3 = new User()
            {
                UserName = "admin@admin.su",
                Phone = "+79159998877",
                PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                AccessRoleId = 1,
                UserStatus = new UserStatus() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 3, Name = "admin", LastName = "Админ"}
            };

            context.Users.AddOrUpdate(u => u.Id, user1);
            context.Users.AddOrUpdate(u => u.Id, user2);
            context.Users.AddOrUpdate(u => u.Id, user3);

            context.Sex.AddOrUpdate(o => o.Id, new Sex {Id=1, Name = "мужской"});
            context.Sex.AddOrUpdate(o => o.Id, new Sex {Id=2,  Name = "женский" });

            var country1 = new Country { Id = 1, Name = "Россия" };
            var country2 = new Country { Id = 2, Name = "США" };
            var place1 = new CountryPlace { Id = 1, Name = "Москва", id_Country = 1 };
            var place2 = new CountryPlace { Id = 2, Name = "Санкт-Петербург", id_Country = 1 };
            var place3 = new CountryPlace { Id = 3, Name = "Теннесси", id_Country = 2 };

            context.Country.AddOrUpdate(country1);
            context.Country.AddOrUpdate(country2);
            context.CountryPlaces.AddOrUpdate(place1);
            context.CountryPlaces.AddOrUpdate(place2);
            context.CountryPlaces.AddOrUpdate(place3);

            var pers1 = new Person { Name = "Светлана", LastName = "Абакачева", id_Sex  = 2, Id = 1, Bithday = new DateTime(1990, 5, 16), id_Bithplace = 1};
            var pers2 = new Person { Name = "Джастин", LastName = "Тимберлейк", NameLatin = "Justin", LastNameLatin = "Timberlake", id_Sex = 1, Id = 2, Bithday = new DateTime(1985, 11, 5), id_Bithplace = 3};
            var pers3 = new Person { Name = "Анна", LastName = "Сидорова", Patronymic = "Владимировна", NameLatin = "Anna", LastNameLatin = "Sidorova", PatronymicLatin = "Vladimirova", id_Sex  = 2, Id = 3, Bithday = new DateTime(1995, 3, 14), id_Bithplace = 2};

            context.Person.AddOrUpdate(pers1);
            context.Person.AddOrUpdate(pers2);
            context.Person.AddOrUpdate(pers3);



            context.SaveChanges();
        }
    }
}