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
    /// 餐桌信息实体
    /// </summary>
    public class MealInfo : BaseEntity
    {
        /// <summary>
        /// 餐桌名
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        [Required]
        public string TableName { get; set; }
    }
}
