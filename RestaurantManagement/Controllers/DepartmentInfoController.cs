using IRestaurantManageBLL;
using IRestaurantManageDAL;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class DepartmentInfoController : Controller
    {
        //依赖注入
        private IDepartmentInfoBll _departmentInfoBll;
        private IUserInfoBll _userInfoBll;

        public DepartmentInfoController(IDepartmentInfoBll departmentInfoBll, IUserInfoBll userInfoBll)
        {
            _departmentInfoBll = departmentInfoBll;
            _userInfoBll = userInfoBll;
        }


        #region 获取数据

        /// <summary>
        /// 部门信息展示页面
        /// </summary>
        /// <returns></returns>
        public IActionResult DepartmentInfoListView()
        {
            return View();
        }


        /// <summary>
        /// 获取部门信息业务
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="departmentName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public IActionResult GetDepartmentInfoListPage(int page, int limit, string departmentName, string description)
        {
            int count;
            object departmentInfos = _departmentInfoBll.GetDepartmentInfoListPage(page, limit, out count, departmentName, description);

            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = departmentInfos
            });
        }

        /// <summary>
        /// 获取部门领导下拉列表数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSelectOptions()
        {
            CustomActionResult res = new CustomActionResult();
            //查询用户下拉列表数据
            object userInfoOptions = _userInfoBll.GetUserSelectOptions();

            //父级部门下拉列表数据
            object departmentInfoOptions = _departmentInfoBll.GetDeparmentSelectOptions();

            res.IsSuccess = true;
            res.Msg = "成功";
            res.Status = 1;
            res.Datas = new
            {
                UserInfoOptions = userInfoOptions,
                DepartmentInfoOptions = departmentInfoOptions
            };

            return Json(res);
        }

        #endregion



        #region 添加数据

        /// <summary>
        /// 添加部门信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddDepartmentInfoView()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult AddDepartmentInfo()
        {
            CustomActionResult res = new CustomActionResult();
            return Json(res);
        }

        #endregion


        #region 删除数据

        /// <summary>
        /// 删除部门数据业务
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteDepartmentInfo()
        {
            CustomActionResult res = new CustomActionResult();
            return Json(res);
        }

        #endregion



        #region 修改数据

        /// <summary>
        /// 更改部门数据视图
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateDepartmentInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取所要更改部门的对应数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateDepartmentInfoOptions()
        {
            CustomActionResult res = new CustomActionResult();
            return Json(res);
        }

        /// <summary>
        /// 更改部门数据业务
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateDepartmentInfo()
        {
            CustomActionResult res = new CustomActionResult();
            return Json(res);
        }

        #endregion

    }
}
