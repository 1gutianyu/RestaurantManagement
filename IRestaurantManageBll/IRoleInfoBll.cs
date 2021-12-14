using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IRoleInfoBll : IBaseDeleteBll<RoleInfo>
    {
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        bool UpdateRoleInfo(string roleInfoId, string name,string description);

        /// <summary>
        /// 获取角色列表数据（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        object GetRoleInfoListByPage(int page, int limit, out int count, string name);

        /// <summary>
        /// 判断角色名昰否重复
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool IsHadRoleInfo(string roleName);


        /// <summary>
        /// 获取当前角色已绑定的员工id集合
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <returns></returns>
        List<string> GetBindStaffInfoIds(string roleInfoId);

        /// <summary>
        /// 绑定员工
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <param name="staffInfoIds"></param>
        void BindStaffInfo(string roleInfoId, List<string> staffInfoIds);
        List<string> GetBindMenuInfoIds(string roleInfoId);
        void BindMenuInfoId(string roleInfoId, List<string> menuInfoIds);
    }
}
