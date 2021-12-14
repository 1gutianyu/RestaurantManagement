using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    [Table("UserInfo")]
    public class UserInfo:BaseDeleteEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string PassWord { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        [Required]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string Email { get; set; }
    }
}
