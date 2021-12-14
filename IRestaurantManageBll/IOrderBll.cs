using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IOrderBll : IBaseBll<OrderInfo>
    {
        /// <summary>
        /// 获取点餐数据列表
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="tableNumber"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        object GetOrderInfoListByPage(string jobId, string tableNumber, int page, int limit, out int count);
        /// <summary>
        /// 更新点餐信息
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="dishesId"></param>
        /// <param name="money"></param>
        /// <param name="method"></param>
        /// <param name="tableNumber"></param>
        /// <returns></returns>
        bool UpdateOrderInfo(string iD, string dishesId, double money, OrderPayMethodEnum method, string tableNumber);
        object GetStatusSelectOption3();
    }
}
