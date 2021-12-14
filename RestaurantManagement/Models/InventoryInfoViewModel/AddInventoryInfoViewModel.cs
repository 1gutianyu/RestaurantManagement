using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models.InventoryInfoViewModel
{
    public class AddInventoryInfoViewModel
    {
        /// <summary>
        /// 原料名称
        /// </summary>
        public string MaterialName { get; set; }
        ///// <summary>
        ///// 库存数量
        ///// </summary>
        //public string number { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string nuit { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal   price { get; set; }
        /// <summary>
        /// 库存警告
        /// </summary>
        public int  Warning { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string describe { get; set; }
    }
}
