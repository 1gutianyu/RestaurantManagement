using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IIncomeBll : IBaseBll<IncomeInfo>
    {
        /// <summary>
        /// 获取收入管理列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        object GetIncomeInfoListByPage(int page, int limit, out int count);
        //修改
        bool UpdateIncomeInfo(string iD, double putMoney);
    }
}
