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
    /// 员工实体
    /// </summary>
    [Table("StaffInfo")]
    public class StaffInfo:BaseDeleteEntity
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        [Required]
        public string StaffName { get; set; }


        /// <summary>
        /// 员工工号
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string JobID { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        ///密码
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string PassWord { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Phone { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DepartmentID { get; set; }



        /// <summary>
        /// 健康状况
        /// </summary>
        public int Health { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Address { get; set; }
    }
}
