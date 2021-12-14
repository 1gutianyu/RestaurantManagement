using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IUserInfoBll : IBaseDeleteBll<UserInfo>
    {
        object GetUserInfoListByPage(int page, int limit, out int count, string userName, string phoneNum);
        bool UpdateUserInfo(string userInfoId, string userName, int sex, string phoneNum);

        /// <summary>
        /// 根据账号密码获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserInfo GetUserInfoByLogin(string account, string password);

        /// <summary>
        /// 获取客户下拉列表数据
        /// </summary>
        /// <returns></returns>
        object GetUserSelectOptions();
    }
}
