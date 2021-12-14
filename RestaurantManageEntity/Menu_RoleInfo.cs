using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    public class Menu_RoleInfo : BaseEntity
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string MenuId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }
    }
}
