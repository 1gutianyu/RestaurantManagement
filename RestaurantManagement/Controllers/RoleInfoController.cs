using IRestaurantManageBLL;
using Microsoft.AspNetCore.Mvc;
using RestaurantManageEntity;
using RestaurantManagement.Models;
using RestaurantManagement.Models.RoleInfoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class RoleInfoController : Controller
    {

        public IRoleInfoBll _roleInfoBll;
        public IStaffInfoBll  _staffInfoBll;
        public IMenuInfoBll _menuInfoBll  ;
        public RoleInfoController(IRoleInfoBll roleInfoBll, IStaffInfoBll staffInfoBll, IMenuInfoBll menuInfoBll)
        {
            _roleInfoBll = roleInfoBll;
            _staffInfoBll = staffInfoBll;
            _menuInfoBll = menuInfoBll;
        }

        CustomActionResult res = new CustomActionResult();

        /// <summary>
        /// 添加角色界面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AddRoleInfoView()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddRoleInfo(AddRoleInfoViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                res.Msg = "角色名不能为空";
                return Json(res);
            }


            //判断角色名是否重复
            if (_roleInfoBll.IsHadRoleInfo(model.Name))
            {
                res.Msg = "角色名已存在";
                return Json(res);
            }
            else
            {
                RoleInfo entity = new RoleInfo()
                {
                    ID = Guid.NewGuid().ToString(),
                    RoleName = model.Name,
                    Description = model.Description,
                    CreateTime = DateTime.Now,
                    IsDelete = false
                };

                bool isSuccess = _roleInfoBll.AddSingleData(entity);
                if (isSuccess)
                {
                    res.Status = 1;
                    res.IsSuccess = true;
                    res.Msg = "添加成功";
                    return Json(res);
                }
                else
                {
                    return Json(res);
                }
            }
        }



        /// <summary>
        /// 更新角色界面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateRoleInfoView()
        {
            return View();
        }


        /// <summary>
        /// 获取更新数据
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <returns></returns>
        public IActionResult GetUpdateRoleInfo(string roleInfoId)
        {
            //获取角色信息
            RoleInfo roleInfo = _roleInfoBll.GetSingleEntityData(roleInfoId);
            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = roleInfo;
            return Json(res);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult UpdateRoleInfo(UpdateRoleInfoViewModel model)
        {
            if (_roleInfoBll.UpdateRoleInfo(model.ID, model.Name, model.Description))
            {
                res.IsSuccess = true;
                res.Msg = "修改成功";
                res.Status = 1;
                return Json(res);
            }
            else
            {
                return Json(res);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult DeleteRoleInfo(string roleInfoId)
        {
            if (_roleInfoBll.SoftDeleteSingleData(roleInfoId))
            {
                res.Status = 1;
                res.IsSuccess = true;
                res.Msg = "成功";
                return Json(res);
            }
            else
            {
                return Json(res);
            }
        }

        /// <summary>
        /// 软删除多个角色
        /// </summary>
        /// <param name="roleInfoIds"></param>
        /// <returns></returns>
        public IActionResult DeleteRoleInfos(List<string> roleInfoIds)
        {
            _roleInfoBll.SoftDeleteDatas(roleInfoIds);
            if (roleInfoIds == null || roleInfoIds.Count == 0)
            {
                res.Msg = "请选择要删除的角色";
            }
            else
            {
                res.Msg = "成功";
                res.IsSuccess = true;
                res.Status = 1;
            }
            return Json(res);
        }

        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="roeInfoId"></param>
        /// <returns></returns>
        public IActionResult GetRoleInfo(string roeInfoId)
        {
            RoleInfo roleInfo = _roleInfoBll.GetSingleEntityData(roeInfoId);
            if (roleInfo == null)
            {
                return Json(res);
            }
            else
            {
                res.Status = 1;
                res.IsSuccess = true;
                res.Msg = "成功";
                res.Datas = roleInfo;
                return Json(res);
            }
        }


        /// <summary>
        /// 获取角色集合界面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult RoleInfoListView()
        {
            return View();
        }

        /// <summary>
        /// 获取角色集合（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public IActionResult GetRoleInfoList(int page, int limit, string name)
        {
            int count;

            object roleInfos = _roleInfoBll.GetRoleInfoListByPage(page, limit, out count, name);

            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = roleInfos
            });
        }

        /// <summary>
        /// 绑定员工视图
        /// </summary>
        /// <returns></returns>
        public IActionResult BindStaffInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取备选员工数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetBindStaffInfo(string roleInfoId)
        {
            //查询员工信息下拉选数据
            object staffInfoOptions = _staffInfoBll.GetStaffSelectOptions();

            //获取当前角色已绑定的员工id集合
            List<string> staffInfoIds = _roleInfoBll.GetBindStaffInfoIds(roleInfoId);

            _roleInfoBll.GetBindStaffInfoIds(roleInfoId);
            res.Status = 1;
            res.Msg = "成功";
            res.IsSuccess = true;
            res.Datas = new
            {
                StaffInfoOptions = staffInfoOptions,
                StaffInfoIds = staffInfoIds
            };
            return Json(res);
        }


        /// <summary>
        /// 绑定员工
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <param name="staffInfoIds"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BindStaffInfo(string roleInfoId, List<string> staffInfoIds)
        {
            _roleInfoBll.BindStaffInfo(roleInfoId, staffInfoIds);

            res.Status = 1;
            res.Msg = "绑定成功";
            res.IsSuccess = true;
            return Json(res);
        }



        /// <summary>
        /// 绑定权限视图
        /// </summary>
        /// <returns></returns>
        public IActionResult BindMenuInfoView()
        {
            return View();
        }


        /// <summary>
        /// 获取备选菜单数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetBindMenuInfo(string roleInfoId)
        {
            //查询菜单信息下拉选数据
            object menuInfoOptions = _menuInfoBll.GetMenuSelectOptions();

            //获取当前角色已绑定的用户id集合
            List<string> menuInfoIds = _roleInfoBll.GetBindMenuInfoIds(roleInfoId);

            _roleInfoBll.GetBindMenuInfoIds(roleInfoId);

            res.IsSuccess = true;
            res.Msg = "成功";
            res.Status = 1;
            res.Datas = new
            {
                MenuInfoOptions = menuInfoOptions,
                MenuInfoIds = menuInfoIds
            };
            return Json(res);
        }


        [HttpPost]
        public IActionResult BindMenuInfo(string roleInfoId, List<string> menuInfoIds)
        {
            _roleInfoBll.BindMenuInfoId(roleInfoId, menuInfoIds);
            res.IsSuccess = true;
            res.Msg = "绑定成功";
            res.Status = 1;
            return Json(res);
        }
    }
}
