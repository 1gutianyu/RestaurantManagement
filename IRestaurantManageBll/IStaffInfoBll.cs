using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IStaffInfoBll : IBaseDeleteBll<StaffInfo>
    {
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="staffInfoId"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        bool UpdateStaffInfo(string staffInfoId, string name, int sex, string phone, string address);

        /// <summary>
        /// 获取员工列表数据（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        object GetStaffInfoListByPage(int page, int limit, out int count, string name, string phone);

        /// <summary>
        /// 判断员工工号角色名是否重复
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        bool IsHadStaffInfo(string jobId);

        /// <summary>
        /// 获取员工下拉列表数据
        /// </summary>
        /// <returns></returns>
        object GetStaffSelectOptions();
    }
}
