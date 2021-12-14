using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    public class Stasff_RoleInfo : BaseEntity
    {
        /// <summary>
        /// 员工Id
        /// </summary>
        public string StaffId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId { get; set; }
    }
}
