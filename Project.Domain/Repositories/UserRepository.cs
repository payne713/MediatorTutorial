using Microsoft.EntityFrameworkCore;
using Project.Domain.AggregateModels;
using Project.Domain.Repositories.Contacts;
using Project.Domain.SeedWorks;
using System;
using System.Threading.Tasks;

namespace Project.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Initialize

        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion Initialize

        #region Services

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<AppUser> GetAppUserInfo(string account, string password)
        {
            using (_context)
            {
                var appUser = await _context.AppUsers
                    .FirstOrDefaultAsync(i => i.Account.Equals(account) && i.Password.Equals(password));

                return appUser;
            }
        }

        #endregion Services
    }
}