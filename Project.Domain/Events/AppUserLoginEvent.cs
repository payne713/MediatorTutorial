using MediatR;

namespace Project.Domain.Events
{
    public class AppUserLoginEvent : INotification
    {
        public string Account { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="account"></param>
        public AppUserLoginEvent(string account)
        {
            Account = account;
        }
    }
}