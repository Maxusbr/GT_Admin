﻿using System;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using System.Linq;

namespace Getticket.Web.DAL.Repositories
{
    /// <summary>
    /// <see cref="IInviteCodeRepository" />
    /// </summary>
    public class InviteCodeRepository : BaseRepository<InviteCode>, IInviteCodeRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InviteCodeRepository() : base()
        {
            // Отключаем ленивую загрузку в репозитории
            this.db.Configuration.LazyLoadingEnabled = false;
        }

        /// <see cref="IInviteCodeRepository.Add(InviteCode)" />
        public bool Add(InviteCode invite)
        {
            if (invite.Id != 0 || invite.User.Id != 0)
            {
                return false;
            }
            db.InviteCodes.Add(invite);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IInviteCodeRepository.Update(InviteCode)" />
        public bool Update(InviteCode invite)
        {
            if (invite.Id == 0 || invite.User.Id == 0)
            {
                return false;
            }
            db.Entry(invite).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        /// <see cref="IInviteCodeRepository.FindOneByCode(string)" />
        public InviteCode FindOneByCode(string code)
        {
            IQueryable<InviteCode> query = db.InviteCodes.Where(ic => ic.Code.Equals(code));
            InviteCode invite = GetOne(query);
            if (invite != null)
            {
                db.Entry(invite).Reference(ic => ic.User).Load();
            }
            return invite;
        }

        /// <see cref="IInviteCodeRepository.Delete(int)" />
        public bool Delete(int Id)
        {
            if (Id < 1)
            {
                return false;
            }
            IQueryable<InviteCode> query = db.InviteCodes.Where(i => i.Id == Id);
            if (!query.Any())
            {
                return false;
            }
            InviteCode invite = query.First();
            db.InviteCodes.Remove(invite);
            db.SaveChanges();
            return true;
        }
    }
}
