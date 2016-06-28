using System;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using System.Linq;

namespace Getticket.Web.DAL.Repository
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
        /// <see cref="IInviteCodeRepository.Save(InviteCode)" />
        public override InviteCode Save(InviteCode Entity)
        {
            return base.Save(Entity);
        }
    }
}
