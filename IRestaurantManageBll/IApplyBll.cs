using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IApplyBll : IBaseBll<ApplyInfo>
    {
        /// <summary>
        /// 获取支出申请表数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        object GetapplyInfoListByPage(int page, int limit, out int count);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="putMoney"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        bool UpdateapplyInfo(string iD, double putMoney, string reason);
    }
}
