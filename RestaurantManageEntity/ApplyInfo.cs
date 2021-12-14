using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 支出申请表
    /// </summary>
    public class ApplyInfo : BaseEntity
    {
        /// <summary>
        /// 申请金额
        /// </summary>
        [Column(TypeName = "decimal")]
        public double ApplyMoney { get; set; }

        /// <summary>
        /// 申请人(工号)
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string JobPerson { get; set; }

        /// <summary>
        /// 申请理由
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string Reason { get; set; }

    }

}
