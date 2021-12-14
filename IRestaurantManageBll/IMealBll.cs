using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IMealBll : IBaseBll<MealInfo>
    {
        /// <summary>
        /// 获取餐桌下拉列表
        /// </summary>
        /// <returns></returns>
        object GetStatusSelectOption();
        /// <summary>
        /// 获取餐桌表数据
        /// </summary>
        /// <returns></return
        object GetMealInfoListByPage(int page, int limit, out int count);
        /// <summary>
        /// 修改餐桌数据
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="tableId"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        bool UpdateOrderInfo(string iD, string tableId);
    }
}
