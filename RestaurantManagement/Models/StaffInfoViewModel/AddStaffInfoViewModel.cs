using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models.StaffInfoViewModel
{
    public class AddStaffInfoViewModel
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
       
        public string Name { get; set; }

        /// <summary>
        /// 员工工号
        /// </summary>
        public string JobID { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        ///密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public int Health { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentInfoID { get; set; }
    }
}
