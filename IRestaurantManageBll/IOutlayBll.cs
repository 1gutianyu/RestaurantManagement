using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IOutlayBll : IBaseBll<OutlayInfo>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        object GetOutlayInfoListByPage(int page, int limit, out int count);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="reason"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        bool UpdateOutlayInfo(string iD, string reason, OutlayReviewStatusEnum status);
    }
}
