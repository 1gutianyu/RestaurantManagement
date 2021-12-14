using RestaurantManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRestaurantManageBLL;
using RestaurantManageEntity;

namespace RestaurantManagement.Controllers
{
    /// <summary>
    /// 支出申请表控制器
    /// </summary>
    public class applyInfoController : Controller
    {
        private IApplyBll _iapplyBll;

        public applyInfoController(IApplyBll iapplyBll)
        {
            _iapplyBll = iapplyBll;
        }

        /// <summary>
        /// 视图
        /// </summary>
        /// <returns></returns>
        public IActionResult applyInfoListView()
        {
            return View();
        }

        public IActionResult applyInfoList(int page, int limit)
        {
            int count;
            object Order = _iapplyBll.GetapplyInfoListByPage(page, limit, out count);
            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = Order
            });
        }

        /// <summary>
        /// 视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddapplyInfoView()
        {
            return View();
        }

        public IActionResult AddapplyInfo(ApplyInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (model.ApplyMoney == 0)
            {
                res.Msg = "金额不能为空";
                return Json(res);
            }

            ApplyInfo applyInfo = new ApplyInfo()
            {
                ID = Guid.NewGuid().ToString(),
                ApplyMoney = model.ApplyMoney,
                JobPerson = "自动获取",
                Reason = model.Reason,
                CreateTime = DateTime.Now
            };

            bool isSuccess = _iapplyBll.AddSingleData(applyInfo);
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

        /// <summary>
        /// 更新数据视图
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateapplyInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateapplyInfo(string applyId)
        {
            CustomActionResult res = new CustomActionResult();
            //获取信息
            ApplyInfo applyInfo = _iapplyBll.GetSingleEntityData(applyId);

            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = applyInfo;
            return Json(res);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateapplyInfo(ApplyInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (_iapplyBll.UpdateapplyInfo(model.ID, model.ApplyMoney,model.Reason))
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
        /// 删除
        /// </summary>
        /// <returns></returns>
        public IActionResult DelectapplyInfo(string applyId)
        {
            CustomActionResult res = new CustomActionResult();
            if (_iapplyBll.DeleteSingleData(applyId))
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
    }
}
