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
    /// 菜品信息实体
    /// </summary>
    public class MenuSheetInfo : BaseEntity
    {
        /// <summary>
        /// 菜名
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        //[Required]
        public string DisheName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Column(TypeName = "decimal")]
        public double Price { get; set; }


        /// <summary>
        /// 菜品分类Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string CategoryID { get; set; }
    }
}
