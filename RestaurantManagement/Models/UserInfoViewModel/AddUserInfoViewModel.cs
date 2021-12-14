using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models.UserInfoViewModel
{
    public class AddUserInfoViewModel : Controller
    {

        /// <summary>
        /// 用户名
        /// </summary>

        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 账号
        /// </summary>

        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>

        public string PassWord { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>

        public string PhoneNum { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>

        public string Email { get; set; }
    }
}

