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
            TempDb(context);

            context.Tags.AddOrUpdate(o => o.Id, new Tag { Id = 1, Name = "Ноги" });
            context.Tags.AddOrUpdate(o => o.Id, new Tag { Id = 2, Name = "Длинные" });
            context.Tags.AddOrUpdate(o => o.Id, new Tag { Id = 3, Name = "Теннис" });
            context.Tags.AddOrUpdate(o => o.Id, new Tag { Id = 4, Name = "Стройные" });

            context.SaveChanges();
        }

        void TempDb(GetticketDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            AccessRoles admin = new AccessRoles() { Name = "Admin", Desciption = "Full access", Id = 1, Role = Enums.AccessRoleType.Admin };
            context.AccessRoles.AddOrUpdate(ar => ar.Id, admin);
            context.AccessRoles.AddOrUpdate(ar => ar.Id, new AccessRoles { Desciption = "Default role", Id = 2, Name = "User", Role = AccessRoleType.User });
            context.SaveChanges();

            // md5 are:
            // teest:    ccfcb5961cb870496289a62c2a6f728c78feb49f448972daf0a6f098a903be08
            // deleted:  1185f37d33b0f89e331f101a51bb8e51165c7efda15950b86a3ebcbb363f898e
            // admin:    8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918

            User user1 = new User()
            {
                Id = 1,
                UserName = "teest@admin.su",
                UserPhone = "+79063332211",
                Password = "ccfcb5961cb870496289a62c2a6f728c78feb49f448972daf0a6f098a903be08",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 1, Name = "Тест", LastName = "Админ" }
            };

            User user2 = new User()
            {
                Id = 2,
                UserName = "deleted@admin.su",
                UserPhone = "+79153332211",
                Password = "1185f37d33b0f89e331f101a51bb8e51165c7efda15950b86a3ebcbb363f898e",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "deleted", Status = UserStatusType.MarkDeleted },
                UserInfo = new UserInfo() { Id = 2, Name = "deleted", LastName = "Админ" }
            };

            User user3 = new User()
            {
                Id = 3,
                UserName = "admin@getticket.ru",
                UserPhone = "+79153332258",
                Password = "e71a2ec101b9eb9d9d242881522528c91005a9d4d87d9e0ace54b79005bd7a97",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "admin", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 3, Name = "gtadmin", LastName = "Админ" }
            };


            var user4 = new User()
            {
                Id = 4,
                UserName = "max_73@inbox.ru",
                UserPhone = "+79788701877",
                Password = "65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 4, Name = "admin", LastName = "Админ" }
            };
            context.Users.AddOrUpdate(u => u.Id, user1);
            context.Users.AddOrUpdate(u => u.Id, user2);
            context.Users.AddOrUpdate(u => u.Id, user3);
            context.Users.AddOrUpdate(u => u.Id, user4);

            //context.Sex.AddOrUpdate(o => o.Id, new Sex { Id = 1, Name = "мужской" });
            //context.Sex.AddOrUpdate(o => o.Id, new Sex { Id = 2, Name = "женский" });

            //var country1 = new Country { Id = 1, Name = "Россия" };
            //var country2 = new Country { Id = 2, Name = "США" };
            //var place1 = new CountryPlace { Id = 1, Name = "Москва", id_Country = 1 };
            //var place2 = new CountryPlace { Id = 2, Name = "Санкт-Петербург", id_Country = 1 };
            //var place3 = new CountryPlace { Id = 3, Name = "Теннесси", id_Country = 2 };

            //context.Country.AddOrUpdate(o => o.Id, country1);
            //context.Country.AddOrUpdate(o => o.Id, country2);
            //context.CountryPlaces.AddOrUpdate(o => o.Id, place1);
            //context.CountryPlaces.AddOrUpdate(o => o.Id, place2);
            //context.CountryPlaces.AddOrUpdate(o => o.Id, place3);

            var pers1 = new Person { Id = 1, Name = "Светлана", LastName = "Абакачева", Sex = Sex.Female, Bithday = new DateTime(1990, 5, 16), id_Bithplace = 2295 };
            var pers2 = new Person { Id = 2, Name = "Джастин", LastName = "Тимберлейк", NameLatin = "Justin", LastNameLatin = "Timberlake", Sex = Sex.Male, Bithday = new DateTime(1985, 11, 5), id_Bithplace = 177329 };
            var pers3 = new Person { Id = 3, Name = "Анна", LastName = "Сидорова", Patronymic = "Владимировна", NameLatin = "Anna", LastNameLatin = "Sidorova", PatronymicLatin = "Vladimirova", Sex = Sex.Female, Bithday = new DateTime(1995, 3, 14), id_Bithplace = 2295 };
            var pers4 = new Person { Id = 4, Name = "Вероника", LastName = "Абасова", Sex = Sex.Female, Bithday = new DateTime(1989, 8, 12), id_Bithplace = 2296 };
            var pers5 = new Person { Id = 5, Name = "Алена", LastName = "Бабенко", Sex = Sex.Female, Bithday = new DateTime(1986, 7, 10), id_Bithplace = 2296 };
            var pers6 = new Person { Id = 5, Name = "Алена", LastName = "Бабенко", Sex = Sex.Female, Bithday = new DateTime(1986, 7, 10), id_Bithplace = 5 };

            context.Person.AddOrUpdate(o => o.Id, pers1);
            context.Person.AddOrUpdate(o => o.Id, pers2);
            context.Person.AddOrUpdate(o => o.Id, pers3);
            context.Person.AddOrUpdate(o => o.Id, pers4);
            context.Person.AddOrUpdate(o => o.Id, pers5);

            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 1, Name = "Спорт" });
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 2, Name = "Театр" });
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 3, Name = "Музыка" });
            context.SaveChanges();
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 4, Name = "Бокс", IdParent = 1 });
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 5, Name = "Фигурное катание", IdParent = 1 });
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 6, Name = "Концерт", IdParent = 3 });
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 7, Name = "Спектакль", IdParent = 2 });
            context.EventCategories.AddOrUpdate(o => o.Id, new EventCategory { Id = 8, Name = "Балет", IdParent = 2 });
            context.SaveChanges();

            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 1, Name = "Бокс", IdCategory = 4, Description = "1/5 Бой за звание чемпиона мира по боксу в супертяжелом весе по версии WBA Лукас Браун..." });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 2, Name = "Фигурное катание", IdCategory = 5, Description = "3 Чемпионат мира по фигурному катанию" });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 3, Name = "Весёлые бабури", IdCategory = 6, Description = "1/2 Петр Налич и биг-бенд \"Песни Утесова и не только...\"" });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 4, Name = "Джаз", IdCategory = 6, Description = "8 А.Кролл, Л.Ролл, М. Волл День джаза в Доме музыки. \"Все цвета московского джаза\"" });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 5, Name = "Вишневый сад", IdCategory = 7 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 6, Name = "Лебединое озеро", IdCategory = 8 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 7, Name = "Современник", IdCategory = 7 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 8, Name = "Justified", IdCategory = 6 });
            context.SaveChanges();

            context.ConnectionTypes.AddOrUpdate(o => o.Id, new ConnectionType { Id = 1, Name = "Персона" });
            context.ConnectionTypes.AddOrUpdate(o => o.Id, new ConnectionType { Id = 2, Name = "Мероприятие" });
            context.ConnectionTypes.AddOrUpdate(o => o.Id, new ConnectionType { Id = 3, Name = "Событие" });
            context.SaveChanges();

            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 1, id_ConnectionType = 3, id_Person = 1, id_Event = 5, Description = "Артист" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 2, id_ConnectionType = 3, id_Person = 2, id_Event = 8, Description = "Певец(соло)" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 3, id_ConnectionType = 3, id_Person = 3, id_Event = 2, Description = "Член команды (основной скип)" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 4, id_ConnectionType = 3, id_Person = 4, id_Event = 5, Description = "Артист" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 5, id_ConnectionType = 3, id_Person = 5, id_Event = 5, Description = "Артист (Граф Орлов)" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 6, id_ConnectionType = 1, id_Person = 5, id_PersonConnectTo = 1, Description = "Подруга" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 7, id_ConnectionType = 1, id_Person = 5, id_PersonConnectTo = 3, Description = "Подруга" });
            context.SaveChanges();

            context.PersonDescriptionType.AddOrUpdate(o => o.Id, new PersonDescriptionType { Id = 1, Name = "Тизер", Type = DescriptionTypes.Tizer });
            context.PersonDescriptionType.AddOrUpdate(o => o.Id, new PersonDescriptionType { Id = 2, Name = "Описание", Type = DescriptionTypes.Description });
            context.SaveChanges();

            context.PageSchemas.AddOrUpdate(o => o.Id, new PageSchema { Id = 1, IdPerson = 1, Page = PageTypes.Person });
            context.SaveChanges();
            context.PageBlockTypes.AddOrUpdate(o => o.Id, new PageBlockType { Id = 1, Name = "Другие персоны подборки" });
            context.SaveChanges();
            context.PageBlocks.AddOrUpdate(o => o.Id, new PageBlock { Id = 1, IdPage = 1, IdBlockType = 1 });
            context.SaveChanges();

            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription { Id = 1, id_DescriptionType = 2, id_Person = 1, DescriptionText = "Родилась в Москве 6 февраля 1991 года. В возрасте 6 лет она начинает заниматься фигурным катанием в школе ЦСКА, а позже каталась на стадионе «Юных Пионеров», где ее тренировала Федерченко Любовь Анатольевна. Училась Анна в нескольких московских школах, с 2000 по 2005 в школе No73, а с 2005 по 2008 в школе No1304. Из учителей будущей чемпионке запомнилась Екатерина Владимировна, которая часто говорила, что за сорок лет преподавания у нее не было и не будет отличников. По словам Анны, это ее очень закалило. Она всегда училась хорошо, а перейдя в другую школу, все-таки стала отличницей и оставалась ею до тех пор, пока спорт не стал занимать все большее место в ее жизни...", Status = "КA: Нужно ранжировать награды по степени важности" });
            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription { Id = 2, id_DescriptionType = 2, id_Person = 1, DescriptionText = "Занималась фигурным катанием. Каталась на стадионе “Юных Пионеров”, где ее тренировала Федерченко Любовь Анатольевна.Училась Анна в нескольких московских школах, с 2000 по 2005 в школе No73, а с 2005 по 2008 в школе No1304.К концу учебы стала отличницей и оставалась ею до тех пор, пока спорт не стал занимать все большее место в ее жизни.", Status = "КA: Нужно ранжировать награды по степени важности" });
            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription
            {
                Id = 3,
                id_DescriptionType = 1,
                id_Person = 1,
                DescriptionText = "Лучший скип сборной России. Знаменита не только спортивными достижениями, но и своей привлекательностью.",
                Status = "КA: Нужно ранжировать награды по степени важности"
            });
            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription
            {
                Id = 4,
                id_DescriptionType = 1,
                RequiredStaticDescription = true,
                IdBlock = 1,
                id_Person = 1,
                DescriptionText = "С 2008 в составе международных команд, 3 олимпийских бронзы.С 2011 основной скип сборной России.",
                Status = "КA: Нужно ранжировать награды по степени важности"
            });
            context.SaveChanges();

            context.PersonDescriptionTizerLinks.AddOrUpdate(new PersonDescriptionTizerLink {IdTizer = 4, IdStaticDescription = 1});
            context.SaveChanges();

            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 1, Name = "Глаза \\ Цвет" });
            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 2, Name = "Стопа \\ Размер" });
            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 3, Name = "Рост" });
            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 4, Name = "Вес" });
            context.SaveChanges();

            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 1, id_Person = 1, id_Antro = 1, Value = "Зеленые" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 2, id_Person = 1, id_Antro = 2, Value = "39" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 3, id_Person = 1, id_Antro = 3, Value = "170" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 4, id_Person = 1, id_Antro = 4, Value = "72" });
            context.SaveChanges();

            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 5, id_Person = 2, id_Antro = 1, Value = "Карие" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 6, id_Person = 2, id_Antro = 2, Value = "41" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 7, id_Person = 3, id_Antro = 3, Value = "175" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 8, id_Person = 3, id_Antro = 4, Value = "65" });
            context.SaveChanges();

            context.MediaTypes.AddOrUpdate(o => o.Id, new MediaType { Id = 1, Name = "Видео" });
            context.MediaTypes.AddOrUpdate(o => o.Id, new MediaType { Id = 2, Name = "Фото" });
            context.SaveChanges();

            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 1, id_Person = 1, id_MediaType = 1, MediaLink = "http://localhost:36049/app-content/images/flag_ru.gif", Description = "Чемпионат Европы по керлингу Россия, Москва, ДС Мегаспорт 3 декабря 2011 // Прививкова Людмила, Сидорова Анна + описание" });
            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 2, id_Person = 1, id_MediaType = 1, MediaLink = "http://localhost:36049/app-content/images/flag_ru.jpg", Description = "Чемпионат Европы по керлингу Россия, Москва, ДС Мегаспорт 3 декабря 2011 // Прививкова Людмила, Сидорова Анна + описание" });
            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 3, id_Person = 1, id_MediaType = 2, MediaLink = "http://localhost:36049/app-content/images/logo-fullsize.png", Description = "Чемпионат Европы по керлингу Россия, Москва, ДС Мегаспорт 3 декабря 2011 // Прививкова Людмила, Сидорова Анна + описание" });
            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 4, id_Person = 1, id_MediaType = 2, MediaLink = "http://localhost:36049/app-content/images/logo-small.png", Description = "Чемпионат Европы по керлингу Россия, Москва, ДС Мегаспорт 3 декабря 2011 // Прививкова Людмила, Сидорова Анна + описание" });
            context.SaveChanges();

            context.PersonSocialLinkTypes.AddOrUpdate(o => o.Id, new PersonSocialLinkType { Id = 1, Name = "instagram" });
            context.PersonSocialLinkTypes.AddOrUpdate(o => o.Id, new PersonSocialLinkType { Id = 2, Name = "facebook" });
            context.SaveChanges();

            context.PersonSocialLinks.AddOrUpdate(o => o.Id, new PersonSocialLink { Id = 1, Destination = DestinationTypes.Public, id_Person = 1, id_SocialLinkType = 1, Link = "https://instagram.com/curlme_anna", Description = "instagram.com/curlme_anna" });
            context.PersonSocialLinks.AddOrUpdate(o => o.Id, new PersonSocialLink { Id = 2, Destination = DestinationTypes.Local, id_Person = 1, id_SocialLinkType = 2, Link = "https://www.facebook.com/fakeacc_curl", Description = "https://www.facebook.com/fakeacc_curl" });
            context.SaveChanges();

            context.PersonFactTypes.AddOrUpdate(o => o.Id, new PersonFactType { Id = 1, Name = "БИО", Descript = "ФИО" });
            context.PersonFactTypes.AddOrUpdate(o => o.Id, new PersonFactType { Id = 2, Name = "Событие", Descript = " Место рождения" });
            context.PersonFactTypes.AddOrUpdate(o => o.Id, new PersonFactType { Id = 3, Name = "Событие" });
            context.SaveChanges();

            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact { Id = 1, id_FactType = 1, id_Person = 1, FactText = "Родилась в Москве 6 февраля 1991 года. В возрасте 6 лет она начинает заниматься фигурным катанием в школе ЦСКА, а позже каталась на стадионе «Юных Пионеров», где ее тренировала Федерченко Любовь Анатольевна. Училась Анна в нескольких московских школах, с 2000 по 2005 в школе No73, а с 2005 по 2008 в школе No1304. Из учителей будущей чемпионке запомнилась Екатерина Владимировна, которая часто говорила, что за сорок лет преподавания у нее не было и не будет отличников. По словам Анны, это ее очень закалило. Она всегда училась хорошо, а перейдя в другую школу, все-таки стала отличницей и оставалась ею до тех пор, пока спорт не стал занимать все большее место в ее жизни..." });
            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact { Id = 2, id_FactType = 2, id_Person = 1, FactText = "Занималась фигурным катанием. Каталась на стадионе “Юных Пионеров”, где ее тренировала Федерченко Любовь Анатольевна. Училась Анна в нескольких московских школах, с 2000 по 2005 в школе No73, а с 2005 по 2008 в школе No1304. К концу учебы стала отличницей и оставалась ею до тех пор, пока спорт не стал занимать все большее место в ее жизни." });
            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact { Id = 3, id_FactType = 3, id_Person = 1, FactText = "С 2008 в составе международных команд, 3 олимпийских бронзы.С 2011 основной скип сборной России." });
            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact { Id = 4, id_FactType = 3, id_Person = 1, FactText = "Лучший скип сборной России. Знаменита не только спортивными достижениями, но и своей привлекательностью." });

            context.SaveChanges();
        }
    }
}