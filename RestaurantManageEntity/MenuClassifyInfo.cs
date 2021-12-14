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
    /// 菜品分类信息实体
    /// </summary>
    public class MenuClassifyInfo : BaseEntity
    {
        [Column(TypeName = "varchar(36)")]
        [Required]
        public string ClassName { get; set; }


        /// <summary>
        /// 菜品分类描述
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Description { get; set; }
    }
}
