using IRestaurantManageBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManageEntity;
using RestaurantManagement.Extensions;
using RestaurantManagement.Models;
using RestaurantManagement.Models.MenuInfoViewModel;
using RestaurantManagement.ResultModel.MenuInfoResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class MenuInfoController : Controller
    {
        //依赖注入
        private IMenuInfoBll _menuInfoBll;
        public MenuInfoController(IMenuInfoBll menuInfoBll)
        {
            _menuInfoBll = menuInfoBll;
        }


        #region 获取数据

        /// <summary>
        /// 获取首页菜单集合
        /// </summary>
        /// <returns></returns>
        public IActionResult GetInitMenus()
        {
            var res = new GetInitMenusResultModel();
            //根据登录用户获取当前用户拥有的角色
            //string userInfoJson = HttpContext.Session.GetString("UserInfo");
            //UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(userInfoJson);
            UserInfo userInfo = this.GetSessionUserInfo();
            if (userInfo != null)
            {
                //获取菜单集合信息
                List<MenuInfoResultModel> menus = _menuInfoBll.GetInitMenus(userInfo);

                res.SetMenuData(menus);
            }


            return Json(res);
        }

        /// <summary>
        /// 菜单数据列表页面
        /// </summary>
        /// <returns></returns>
        public IActionResult MenuInfoListView()
        {
            return View();
        }

        /// <summary>
        /// 获取菜单集合
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public IActionResult GetMenuInfoListPage(int page, int limit, string title)
        {
            int count;

            object menuInfos = _menuInfoBll.GetMenuListPage(page, limit, out count, title);

            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = menuInfos
            });
        }


        #endregion


        #region 添加数据

        /// <summary>
        /// 添加菜单数据页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddMenuInfoView()
        {
            return View();
        }

        /// <summary>
        /// 添加菜单数据接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMenuInfo(AddMenuInfoViewModel model)
        {
            CustomActionResult res = new CustomActionResult();

            if (string.IsNullOrEmpty(model.Title))
            {
                res.Msg = "菜单标题不能为空";
                return Json(res);
            }

            //判断数据库有没有相同账号
            if (_menuInfoBll.IsHadMenuInfo(model.Title))
            {
                res.Msg = "当前添加菜单已存在";
                return Json(res);
            }
            else
            {
                MenuInfo entity = new MenuInfo()
                {
                    ID = Guid.NewGuid().ToString(),
                    Title = model.Title,
                    Target = model.Target,
                    Icon = model.Icon,
                    Href = model.Href,
                    Level = model.Level,
                    Sort = model.Sort,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    CreateTime = DateTime.Now,
                    IsDelete = false
                };

                bool isSuccess = _menuInfoBll.AddSingleData(entity);
                if (isSuccess)
                {
                    res.IsSuccess = true;
                    res.Status = 1;
                    res.Msg = "添加成功";
                    return Json(res);
                }
                else
                {
                    return Json(res);
                }
            }
        }

        #endregion


        #region 删除数据

        #endregion


        #region 更改数据

        #endregion
    }
}
