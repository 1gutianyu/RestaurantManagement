using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models.DepartmentInfoModels
{
    public class AddDepartmentInfoModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        //[Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 领导ID(UserInfoId)
        /// </summary>
        public string LeaderID { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        public string ParentID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
