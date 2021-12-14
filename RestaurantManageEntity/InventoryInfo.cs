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
    /// 原料库存信息实体
    /// </summary>
    public class InventoryInfo : BaseDeleteEntity
    {
        /// <summary>
        /// 原料名
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        [Required]
        public string MaterialName { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>

        public int Number { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Unit { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 库存警告
        /// </summary>
        public int Warning { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Describtion { get; set; }
        ///// <summary>
        ///// 添加时间
        ///// </summary>
        //public DateTime CreateTime { get; set; }

    }
}
