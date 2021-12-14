using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    /// <summary>
    /// 金额支出审批表
    /// </summary>
    public class OutlayInfo : BaseEntity
    {
        /// <summary>
        /// 审批人
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string CheckPerson { get; set; }

        /// <summary>
        /// 审批理由
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string Reason { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        //[Column(TypeName = "varchar(36)")]
        public OutlayReviewStatusEnum Status { get; set; }


    }

    public enum OutlayReviewStatusEnum
    {
        未审批 = 1,
        已驳回 = 2,
        已同意 = 3,
        已失效 = 4
    }

}
