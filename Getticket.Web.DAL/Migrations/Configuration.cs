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
            AccessRoles admin = new AccessRoles() { Name = "Admin", Desciption = "Full access", Id = 1, Role = Enums.AccessRoleType.Admin };
            context.AccessRoles.AddOrUpdate(ar => ar.Id, admin);
            context.AccessRoles.AddOrUpdate(ar => ar.Id, new AccessRoles {Desciption = "Default role", Id = 2, Name = "User", Role = AccessRoleType.User});
            context.SaveChanges();

            // md5 are:
            // teest:    ccfcb5961cb870496289a62c2a6f728c78feb49f448972daf0a6f098a903be08
            // deleted:  1185f37d33b0f89e331f101a51bb8e51165c7efda15950b86a3ebcbb363f898e
            // admin:    8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918

            User user1 = new User()
            {
                UserName = "teest@admin.su",
                UserPhone = "+79063332211",
                Password = "ccfcb5961cb870496289a62c2a6f728c78feb49f448972daf0a6f098a903be08",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 1, Name = "����", LastName = "�����" }
            };

            User user2 = new User()
            {
                UserName = "deleted@admin.su",
                UserPhone = "+79153332211",
                Password = "1185f37d33b0f89e331f101a51bb8e51165c7efda15950b86a3ebcbb363f898e",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "deleted", Status = UserStatusType.MarkDeleted },
                UserInfo = new UserInfo() { Id = 2, Name = "deleted", LastName = "�����" }
            };

            User user3 = new User()
            {
                UserName = "admin@admin.su",
                UserPhone = "+79159998877",
                Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 3, Name = "admin", LastName = "�����" }
            };
            var user4 = new User()
            {
                UserName = "max_73@inbox.ru",
                UserPhone = "+79788701877",
                Password = "65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5",
                AccessRoleId = 1,
                UserStatuses = new UserStatuses() { Name = "seed", Description = "", Status = UserStatusType.System },
                UserInfo = new UserInfo() { Id = 3, Name = "admin", LastName = "�����" }
            };
            context.Users.AddOrUpdate(u => u.Id, user1);
            context.Users.AddOrUpdate(u => u.Id, user2);
            context.Users.AddOrUpdate(u => u.Id, user3);
            context.Users.AddOrUpdate(u => u.Id, user4);

            context.Sex.AddOrUpdate(o => o.Id, new Sex { Id = 1, Name = "�������" });
            context.Sex.AddOrUpdate(o => o.Id, new Sex { Id = 2, Name = "�������" });

            var country1 = new Country { Id = 1, Name = "������" };
            var country2 = new Country { Id = 2, Name = "���" };
            var place1 = new CountryPlace { Id = 1, Name = "������", id_Country = 1 };
            var place2 = new CountryPlace { Id = 2, Name = "�����-���������", id_Country = 1 };
            var place3 = new CountryPlace { Id = 3, Name = "��������", id_Country = 2 };

            context.Country.AddOrUpdate(o => o.Id, country1);
            context.Country.AddOrUpdate(o => o.Id, country2);
            context.CountryPlaces.AddOrUpdate(o => o.Id, place1);
            context.CountryPlaces.AddOrUpdate(o => o.Id, place2);
            context.CountryPlaces.AddOrUpdate(o => o.Id, place3);

            var pers1 = new Person { Name = "��������", LastName = "���������", id_Sex = 2, Id = 1, Bithday = new DateTime(1990, 5, 16), id_Bithplace = 1 };
            var pers2 = new Person { Name = "�������", LastName = "����������", NameLatin = "Justin", LastNameLatin = "Timberlake", id_Sex = 1, Id = 2, Bithday = new DateTime(1985, 11, 5), id_Bithplace = 3 };
            var pers3 = new Person { Name = "����", LastName = "��������", Patronymic = "������������", NameLatin = "Anna", LastNameLatin = "Sidorova", PatronymicLatin = "Vladimirova", id_Sex = 2, Id = 3, Bithday = new DateTime(1995, 3, 14), id_Bithplace = 2 };
            var pers4 = new Person { Name = "��������", LastName = "�������", id_Sex = 2, Id = 4, Bithday = new DateTime(1989, 8, 12), id_Bithplace = 2 };
            var pers5 = new Person { Name = "�����", LastName = "�������", id_Sex = 2, Id = 5, Bithday = new DateTime(1986, 7, 10), id_Bithplace = 2 };
            var pers6 = new Person { Name = "�����", LastName = "�������", id_Sex = 2, Id = 5, Bithday = new DateTime(1986, 7, 10), id_Bithplace = 2 };

            context.Person.AddOrUpdate(o => o.Id, pers1);
            context.Person.AddOrUpdate(o => o.Id, pers2);
            context.Person.AddOrUpdate(o => o.Id, pers3);
            context.Person.AddOrUpdate(o => o.Id, pers4);
            context.Person.AddOrUpdate(o => o.Id, pers5);

            context.EventTypes.AddOrUpdate(o => o.Id, new EventType { Id = 1, Name = "�����" });
            context.EventTypes.AddOrUpdate(o => o.Id, new EventType { Id = 2, Name = "�����" });
            context.EventTypes.AddOrUpdate(o => o.Id, new EventType { Id = 3, Name = "������" });

            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 1, Name = "����", Description = "1/5 ��� �� ������ �������� ���� �� ����� � ������������ ���� �� ������ WBA ����� �����...", id_EventType = 1 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 2, Name = "�������� �������", Description = "3 ��������� ���� �� ��������� �������", id_EventType = 1 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 3, Name = "������ ������", Description = "1/2 ���� ����� � ���-���� \"����� ������� � �� ������...\"", id_EventType = 3 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 4, Name = "����", Description = "8 �.�����, �.����, �. ���� ���� ����� � ���� ������. \"��� ����� ����������� �����\"", id_EventType = 3 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 5, Name = "�������� ���", id_EventType = 2 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 6, Name = "��������� �����", id_EventType = 2 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 7, Name = "�����������", id_EventType = 2 });
            context.Events.AddOrUpdate(o => o.Id, new Event { Id = 8, Name = "Justified", id_EventType = 3 });

            context.PersonConnectionType.AddOrUpdate(o => o.Id, new PersonConnectionType { Id = 1, Name = "�������" });
            context.PersonConnectionType.AddOrUpdate(o => o.Id, new PersonConnectionType { Id = 2, Name = "�����������" });
            context.PersonConnectionType.AddOrUpdate(o => o.Id, new PersonConnectionType { Id = 3, Name = "�������" });

            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 1, id_ConnectionType = 3, id_Person = 1, id_Event = 7, Description = "������" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 2, id_ConnectionType = 3, id_Person = 2, id_Event = 8, Description = "�����(����)" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 3, id_ConnectionType = 3, id_Person = 3, id_Event = 2, Description = "���� ������� (�������� ����)" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 4, id_ConnectionType = 3, id_Person = 4, id_Event = 5, Description = "������" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 5, id_ConnectionType = 3, id_Person = 5, id_Event = 6, Description = "������ (���� �����)" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 6, id_ConnectionType = 1, id_Person = 5, id_PersonConnectTo = 4, Description = "�������" });
            context.PersonConnections.AddOrUpdate(o => o.Id, new PersonConnection { Id = 7, id_ConnectionType = 1, id_Person = 5, id_PersonConnectTo = 3, Description = "�������" });

            context.PersonDescriptionType.AddOrUpdate(o => o.Id, new PersonDescriptionType { Id = 1, Name = "�����" });
            context.PersonDescriptionType.AddOrUpdate(o => o.Id, new PersonDescriptionType { Id = 2, Name = "��������" });

            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription { Id = 1, id_DescriptionType = 1, id_Person = 1, DescriptionText = "� 2008 � ������� ������������� ������, 3 ����������� ������.� 2011 �������� ���� ������� ������.", Status = "�A: ����� ����������� ������� �� ������� ��������" });
            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription { Id = 2, id_DescriptionType = 1, id_Person = 1, DescriptionText = "������ ���� ������� ������. ��������� �� ������ ����������� ������������, �� � ����� ������������������.", Status = "�A: ����� ����������� ������� �� ������� ��������" });
            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription { Id = 3, id_DescriptionType = 2, id_Person = 1, DescriptionText = "�������� � ������ 6 ������� 1991 ����. � �������� 6 ��� ��� �������� ���������� �������� �������� � ����� ����, � ����� �������� �� �������� ����� ��������, ��� �� ����������� ���������� ������ �����������. ������� ���� � ���������� ���������� ������, � 2000 �� 2005 � ����� No73, � � 2005 �� 2008 � ����� No1304. �� �������� ������� ��������� ����������� ��������� ������������, ������� ����� ��������, ��� �� ����� ��� ������������ � ��� �� ���� � �� ����� ����������. �� ������ ����, ��� �� ����� ��������. ��� ������ ������� ������, � ������� � ������ �����, ���-���� ����� ���������� � ���������� �� �� ��� ���, ���� ����� �� ���� �������� ��� ������� ����� � �� �����...", Status = "�A: ����� ����������� ������� �� ������� ��������" });
            context.PersonDescriptions.AddOrUpdate(o => o.Id, new PersonDescription { Id = 4, id_DescriptionType = 2, id_Person = 1, DescriptionText = "���������� �������� ��������. �������� �� �������� ����� ��������, ��� �� ����������� ���������� ������ �����������.������� ���� � ���������� ���������� ������, � 2000 �� 2005 � ����� No73, � � 2005 �� 2008 � ����� No1304.� ����� ����� ����� ���������� � ���������� �� �� ��� ���, ���� ����� �� ���� �������� ��� ������� ����� � �� �����.", Status = "�A: ����� ����������� ������� �� ������� ��������" });

            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 1, Name = "����� \\ ����" });
            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 2, Name = "����� \\ ������" });
            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 3, Name = "����" });
            context.PersonAntroNames.AddOrUpdate(o => o.Id, new PersonAntroName { Id = 4, Name = "���" });

            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 1, id_Person = 1, id_Antro = 1, Value = "�������" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 2, id_Person = 1, id_Antro = 2, Value = "39" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 3, id_Person = 1, id_Antro = 3, Value = "170" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 4, id_Person = 1, id_Antro = 4, Value = "72" });

            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 5, id_Person = 2, id_Antro = 1, Value = "�����" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 6, id_Person = 2, id_Antro = 2, Value = "41" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 7, id_Person = 3, id_Antro = 3, Value = "175" });
            context.PersonAntro.AddOrUpdate(o => o.Id, new PersonAntro { Id = 8, id_Person = 3, id_Antro = 4, Value = "65" });

            context.PersonMediaType.AddOrUpdate(o => o.Id, new PersonMediaType { Id = 1, Name = "�����" });
            context.PersonMediaType.AddOrUpdate(o => o.Id, new PersonMediaType { Id = 2, Name = "����" });

            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 1, id_Person = 1, id_MediaType = 1, MediaLink = "http://localhost:36049/app-content/images/flag_ru.gif", Description = "��������� ������ �� �������� ������, ������, �� ��������� 3 ������� 2011 // ���������� �������, �������� ���� + ��������"});
            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 2, id_Person = 1, id_MediaType = 1, MediaLink = "http://localhost:36049/app-content/images/flag_ru.jpg", Description = "��������� ������ �� �������� ������, ������, �� ��������� 3 ������� 2011 // ���������� �������, �������� ���� + ��������" });
            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 3, id_Person = 1, id_MediaType = 2, MediaLink = "http://localhost:36049/app-content/images/logo-fullsize.png", Description = "��������� ������ �� �������� ������, ������, �� ��������� 3 ������� 2011 // ���������� �������, �������� ���� + ��������" });
            context.PersonMedia.AddOrUpdate(o => o.Id, new PersonMedia { Id = 4, id_Person = 1, id_MediaType = 2, MediaLink = "http://localhost:36049/app-content/images/logo-small.png", Description = "��������� ������ �� �������� ������, ������, �� ��������� 3 ������� 2011 // ���������� �������, �������� ���� + ��������" });

            context.PersonSocialLinkTypes.AddOrUpdate(o => o.Id, new PersonSocialLinkType { Id = 1, Name = "instagram" });
            context.PersonSocialLinkTypes.AddOrUpdate(o => o.Id, new PersonSocialLinkType { Id = 2, Name = "facebook" });

            context.PersonSocialLinks.AddOrUpdate(o => o.Id, new PersonSocialLink { id_Person = 1, id_SocialLinkType = 1, Link = "https://instagram.com/curlme_anna", Description = "instagram.com/curlme_anna" });
            context.PersonSocialLinks.AddOrUpdate(o => o.Id, new PersonSocialLink { id_Person = 1, id_SocialLinkType = 2, Link = "https://www.facebook.com/fakeacc_curl", Description = "https://www.facebook.com/fakeacc_curl" });

            context.PersonFactTypes.AddOrUpdate(o => o.Id, new PersonFactType { Id = 1, Name = "���", Descript = "���"});
            context.PersonFactTypes.AddOrUpdate(o => o.Id, new PersonFactType { Id = 2, Name = "�������", Descript = " ����� ��������"});
            context.PersonFactTypes.AddOrUpdate(o => o.Id, new PersonFactType { Id = 3, Name = "�������" });

            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact {Id = 1, id_FactType = 1, id_Person = 1, FactText = "�������� � ������ 6 ������� 1991 ����. � �������� 6 ��� ��� �������� ���������� �������� �������� � ����� ����, � ����� �������� �� �������� ����� ��������, ��� �� ����������� ���������� ������ �����������. ������� ���� � ���������� ���������� ������, � 2000 �� 2005 � ����� No73, � � 2005 �� 2008 � ����� No1304. �� �������� ������� ��������� ����������� ��������� ������������, ������� ����� ��������, ��� �� ����� ��� ������������ � ��� �� ���� � �� ����� ����������. �� ������ ����, ��� �� ����� ��������. ��� ������ ������� ������, � ������� � ������ �����, ���-���� ����� ���������� � ���������� �� �� ��� ���, ���� ����� �� ���� �������� ��� ������� ����� � �� �����..." });
            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact {Id = 2, id_FactType = 2, id_Person = 1, FactText = "���������� �������� ��������. �������� �� �������� ����� ��������, ��� �� ����������� ���������� ������ �����������. ������� ���� � ���������� ���������� ������, � 2000 �� 2005 � ����� No73, � � 2005 �� 2008 � ����� No1304. � ����� ����� ����� ���������� � ���������� �� �� ��� ���, ���� ����� �� ���� �������� ��� ������� ����� � �� �����." });
            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact {Id = 3, id_FactType = 3, id_Person = 1, FactText = "� 2008 � ������� ������������� ������, 3 ����������� ������.� 2011 �������� ���� ������� ������." });
            context.PersonFacts.AddOrUpdate(o => o.Id, new PersonFact {Id = 4, id_FactType = 3, id_Person = 1, FactText = "������ ���� ������� ������. ��������� �� ������ ����������� ������������, �� � ����� ������������������." });

            context.SaveChanges();
        }
    }
}