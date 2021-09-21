using MediatR;
using Project.Application.Commands;
using Project.Domain.Repositories.Contacts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.CommandHandlers
{
    /// <summary>
    /// 用户登录请求处理
    /// </summary>
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
    {
        #region Initizalize

        /// <summary>
        /// 仓储实例
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mediator"></param>
        public UserLoginCommandHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion Initizalize

        /// <summary>
        /// Command Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            // 1、判断验证码是否正确
            if (string.IsNullOrEmpty(request.VerificationCode))
                return false;

            // 2、验证登录密码是否正确
            var appUser = await _userRepository.GetAppUserInfo(request.Account.Trim(), request.Password.Trim());
            if (appUser == null)
                return false;

            // 3、记录登录事件
            appUser.SetUserLoginRecord(_mediator);

            return true;
        }
    }
}