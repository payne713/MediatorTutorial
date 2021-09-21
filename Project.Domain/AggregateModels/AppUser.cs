﻿using MediatR;
using Project.Domain.Events;
using System;

namespace Project.Domain.AggregateModels
{
    public class AppUser
    {
        /// <summary>
        /// ctor
        /// </summary>
        public AppUser()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="name">姓名</param>
        /// <param name="age">年龄</param>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="email">电子邮箱</param>
        /// <param name="phone">手机号码</param>
        /// <param name="gender">性别</param>
        /// <param name="address">地址</param>
        /// <param name="isEnabled">是否启用</param>
        public AppUser(Guid id, string name, short age, string account, string password,
            string email, string phone, bool gender, Address address, bool isEnabled)
        {
            Id = id;
            Name = name;
            Age = age;
            Account = account;
            Password = password;
            Email = email;
            Phone = phone;
            Gender = gender;
            Address = address;
            IsEnabled = isEnabled;
        }

        #region Attributes

        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public short Age { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion Attributes

        #region Events

        /// <summary>
        ///
        /// </summary>
        public void SetUserLoginRecord(IMediator mediator)
        {
            mediator.Publish(new AppUserLoginEvent(Account));
        }

        #endregion Events
    }
}