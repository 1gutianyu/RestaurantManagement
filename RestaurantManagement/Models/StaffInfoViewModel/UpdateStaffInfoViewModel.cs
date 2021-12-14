using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models.StaffInfoViewModel
{
    public class UpdateStaffInfoViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        /// 
        public int JobID { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

      

        /// <summary>
        /// 电话
        /// </summary>
       
        public string Phone { get; set; }

      
        /// <summary>
        /// 地址
        /// </summary>
       
        public string Address { get; set; }
    }
}
