using Project.Domain.AggregateModels;
using System.Threading.Tasks;

namespace Project.Domain.Repositories.Contacts
{
    public interface IUserRepository
    {
        #region Services

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<AppUser> GetAppUserInfo(string account, string password);

        #endregion Services
    }
}