using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 角色实体
    /// </summary>
    [Table("RoleInfo")]
    public class RoleInfo:BaseDeleteEntity
    {
        ///// <summary>
        ///// 角色名
        ///// </summary>
        //[Column(TypeName = "varchar(36)")]
        public string RoleName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Description { get; set; }

    }
}
