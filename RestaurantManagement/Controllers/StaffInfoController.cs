using IRestaurantManageBLL;
using Microsoft.AspNetCore.Mvc;
using RestaurantManageEntity;
using RestaurantManagement.Models;
using RestaurantManagement.Models.StaffInfoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class StaffInfoController : Controller
    {
        private IStaffInfoBll _staffInfoBll;
        private IDepartmentInfoBll _departmentInfoBll;
        public StaffInfoController(IStaffInfoBll staffInfoBll, IDepartmentInfoBll departmentInfoBll)
        {
            _staffInfoBll = staffInfoBll;
            _departmentInfoBll = departmentInfoBll;
        }



        CustomActionResult res = new CustomActionResult();

        /// <summary>
        /// 添加员工视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddStaffInfoView()
        {
            return View();
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddStaffInfo(AddStaffInfoViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                res.Msg = "名字不能为空";
                return Json(res);
            }
            else if (string.IsNullOrEmpty(model.PassWord))
            {
                res.Msg = "密码不能为空";
                return Json(res);
            }


            //判断员工工号是否重复
            if (_staffInfoBll.IsHadStaffInfo(model.JobID))
            {
                res.Msg = "工号已存在";
                return Json(res);
            }
            else
            {

                StaffInfo entity = new StaffInfo()
                {
                    ID = Guid.NewGuid().ToString(),
                    StaffName = model.Name,
                    JobID = model.JobID.ToString(),
                    Phone = model.Phone,
                    Sex = model.Sex,
                    PassWord = model.PassWord,
                    Address = model.Address,
                    Health = model.Health,
                    CreateTime = DateTime.Now,
                    IsDelete = false,
                    DepartmentID=model.DepartmentInfoID
                };

                bool isSuccess = _staffInfoBll.AddSingleData(entity);
                if (isSuccess)
                {
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
        /// 修改员工视图
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateStaffInfoView()
        {
            return View();
        }


        /// <summary>
        /// 获取修改员工信息
        /// </summary>
        /// <param name="staffInfoId"></param>
        /// <returns></returns>
        public IActionResult GetUpdateStaffInfo(string staffInfoId)
        {
            //获取员工信息
            StaffInfo staffInfo = _staffInfoBll.GetSingleEntityData(staffInfoId);
            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = staffInfo;

            return Json(res);
        }

        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateStaffInfo(UpdateStaffInfoViewModel model)
        {

            if (_staffInfoBll.UpdateStaffInfo(model.ID, model.Name, model.Sex, model.Phone, model.Address))
            {
                res.IsSuccess = true;
                res.Msg = "成功";
                res.Status = 1;
                return Json(res);
            }
            else
            {
                return Json(res);
            }
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="staffInfoId"></param>
        /// <returns></returns>
        public IActionResult DeleteStaffInfo(string staffInfoId)
        {

            if (_staffInfoBll.SoftDeleteSingleData(staffInfoId))
            {
                res.Status = 1;
                res.Msg = "成功";
                res.IsSuccess = true;
                return Json(res);
            }
            else
            {
                return Json(res);
            }
        }


        /// <summary>
        /// 软删除多个员工
        /// </summary>
        /// <param name="staffInfoIds"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteStaffInfos(List<string> staffInfoIds)
        {

            if (staffInfoIds == null || staffInfoIds.Count == 0)
            {
                res.Msg = "请选择要删除的数据";
            }
            else
            {
                _staffInfoBll.SoftDeleteDatas(staffInfoIds);
                res.Status = 1;
                res.Msg = "成功";
                res.IsSuccess = true;
            }

            return Json(res);
        }

        /// <summary>
        /// 根据Id获取员工
        /// </summary>
        /// <returns></returns>
        public IActionResult GetStaffInfo(string staffInfoId)
        {
            StaffInfo staffInfo = _staffInfoBll.GetSingleEntityData(staffInfoId);
            if (staffInfo == null)
            {
                return Json(res);
            }
            else
            {
                res.Status = 1;
                res.Msg = "成功";
                res.IsSuccess = true;
                res.Datas = staffInfo;
                return Json(res);
            }
        }

        /// <summary>
        /// 获取员工列表视图
        /// </summary>
        /// <returns></returns>
        public IActionResult StaffInfoListView()
        {
            return View();
        }

        /// <summary>
        /// 获取员工数据列表（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public IActionResult GetStaffInfoList(int page, int limit, string name, string phone)
        {
            int count;

            object staffInfos = _staffInfoBll.GetStaffInfoListByPage(page, limit, out count, name, phone);

            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = staffInfos
            });
        }

        /// <summary>
        /// 获取部门下拉选数据集
        /// </summary>
        /// <returns></returns>
        public IActionResult GetDepartmentSelectOption()
        {
            //查询部门信息下拉选数据
            object options = _departmentInfoBll.GetDeparmentSelectOptions();

            res.Status = 1;
            res.IsSuccess = true;
            res.Msg = "成功";
            res.Datas = options;
            return Json(res);
        }
    }
}
