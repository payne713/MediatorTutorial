﻿using MediatR;

namespace Project.Application.Commands
{
    /// <summary>
    /// 用户登录请求
    /// </summary>
    public class UserLoginCommand : IRequest<bool>
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="verificationCode">验证码</param>
        public UserLoginCommand(string account, string password, string verificationCode)
        {
            Account = account;
            Password = password;
            VerificationCode = verificationCode;
        }
    }
}