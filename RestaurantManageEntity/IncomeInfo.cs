using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 收入管理实体
    /// </summary>
    public class IncomeInfo : BaseEntity
    {
        /// <summary>
        /// 点餐Id(外键)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string OrderId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Column(TypeName = "decimal")]
        public double PutMoney { get; set; }

        /// <summary>
        /// 负责员工(外键)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string JobId { get; set; }


    }
}
