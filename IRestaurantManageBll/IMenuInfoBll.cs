using RestaurantManageEntity;
using RestaurantManagement.ResultModel.MenuInfoResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    /// <summary>
    /// 菜单业务逻辑接口层
    /// </summary>
    public interface IMenuInfoBll:IBaseDeleteBll<MenuInfo>
    {
        /// <summary>
        /// 获取菜单集合信息
        /// </summary>
        /// <returns></returns>
        List<MenuInfoResultModel> GetInitMenus(UserInfo userInfoId);

        /// <summary>
        /// 获取菜单数据列表，分页，模糊查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        object GetMenuListPage(int page, int limit, out int count, string title);

        /// <summary>
        /// 判断是否存在同名菜单
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        bool IsHadMenuInfo(string title);


        /// <summary>
        /// 获取菜单信息下拉列表数据
        /// </summary>
        /// <returns></returns>
        object GetMenuSelectOptions();
    }
}
