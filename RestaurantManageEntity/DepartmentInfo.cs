using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    public class DepartmentInfo : BaseDeleteEntity
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        [Required]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }

        /// <summary>
        /// 领导ID(UserInfoId)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string LeaderID { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ParentID { get; set; }

    }
}
