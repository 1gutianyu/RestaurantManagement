using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 原料进货记录表
    /// </summary>
    public class PurchaseInfo : BaseDeleteEntity
    {

        /// <summary>
        /// 原料Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string MaterialId { get; set; }

        /// <summary>
        /// 进货数量
        /// </summary>
        [Column(TypeName = "float")]
        public double Number { get; set; }

        /// <summary>
        /// 进货人(外键UserId)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Buyer { get; set; }


    }
}
