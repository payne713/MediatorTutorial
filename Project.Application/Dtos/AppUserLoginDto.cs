using System.ComponentModel.DataAnnotations;

namespace Project.Application.Dtos
{
    /// <summary>
    /// 用户登录数据传输对象
    /// </summary>
    public class AppUserLoginDto
    {
        #region Attributes

        /// <summary>
        /// 账户
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string VerificationCode { get; set; }

        #endregion Attributes
    }
}