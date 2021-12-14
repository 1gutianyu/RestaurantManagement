using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 点餐信息表
    /// </summary>
    public class OrderInfo : BaseEntity
    {
        /// <summary>
        /// 菜品Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DishesId { get; set; }

        /// <summary>
        /// 餐费合计
        /// </summary>
        [Column(TypeName = "decimal")]
        public double TotalMoney { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public OrderPayMethodEnum PayMethod { get; set; }

        /// <summary>
        /// 负责员工(外键 UserId)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string JobId { get; set; }

        /// <summary>
        /// 餐桌号 外键(TableId)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string TableNumber { get; set; }

    }

    /// <summary>
    /// 支付方式枚举
    /// </summary>
    public enum OrderPayMethodEnum
    {
        支付宝 = 1,
        微信 = 2,
        现金 = 3,
        银行卡 = 4
    }

}
