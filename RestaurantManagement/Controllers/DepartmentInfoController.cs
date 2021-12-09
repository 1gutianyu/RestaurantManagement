using IRestaurantManageDAL;
using Microsoft.AspNetCore.Mvc;
using RepositorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class DepartmentInfoController : Controller
    {
        //依赖注入
        private IDepartmentInfoDal _departmentInfoDal;
        public DepartmentInfoController(IDepartmentInfoDal departmentInfoDal)
        {
            _departmentInfoDal = departmentInfoDal;
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
        /// <returns></returns>
        public IActionResult GetDepartmentInfoListPage()
        {
            CustomActionResult res = new CustomActionResult();
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
