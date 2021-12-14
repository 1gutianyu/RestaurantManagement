using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.ResultModel.MenuInfoResultModel
{
    /// <summary>
    /// 获取菜单信息返回值model
    /// </summary>
    public class GetInitMenusResultModel
    {
        public object homeInfo { get; set; } = new
        {
            title = "首页",
            href = ""
        };

        public object logoInfo { get; set; } = new
        {
            image = "../../layuimini/images/logo.png",
            title = "仓库管理系统",
            href = ""
        };

        public List<MenuInfoResultModel> menuInfo { get; set; } = new List<MenuInfoResultModel>()
                {
                    new MenuInfoResultModel()
                    {
                        title = "常规管理",
                        icon = "fa fa-address-book",
                        href = "",
                        target = "_self"
                    }
                };

        public void SetMenuData(List<MenuInfoResultModel> child)
        {
            var menu = menuInfo.FirstOrDefault();
            if (menu != null)
            {
                menu.child = child;
            }
        }
    }
}
