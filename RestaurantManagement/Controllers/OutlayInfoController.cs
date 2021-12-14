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
    /// 金额支出审核表控制器
    /// </summary>
    public class OutlayInfoController : Controller
    {
        private IOutlayBll _outlayBll;

        public OutlayInfoController(IOutlayBll outlayBll)
        {
            _outlayBll = outlayBll;
        }

        /// <summary>
        /// 视图
        /// </summary>
        /// <returns></returns>
        public IActionResult OutlayInfoListView()
        {
            return View();
        }

        public IActionResult OutlayInfoList(int page, int limit)
        {
            int count;
            object Order = _outlayBll.GetOutlayInfoListByPage(page, limit, out count);
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
        public IActionResult AddOutlayInfoView()
        {
            return View();
        }

        public IActionResult AddOutlayInfo(OutlayInfo model)
        {
            CustomActionResult res = new CustomActionResult();


            OutlayInfo OutlayInfo = new OutlayInfo()
            {
                ID = Guid.NewGuid().ToString(),
                CheckPerson="自动获取",
                Reason=model.Reason,
                Status= OutlayReviewStatusEnum.未审批
            };

            bool isSuccess = _outlayBll.AddSingleData(OutlayInfo);
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
        public IActionResult UpdateOutlayInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateOutlayInfo(string OutlayId)
        {
            CustomActionResult res = new CustomActionResult();
            //获取信息
            OutlayInfo OutlayInfo = _outlayBll.GetSingleEntityData(OutlayId);

            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = OutlayInfo;
            return Json(res);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateOutlayInfo(OutlayInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (_outlayBll.UpdateOutlayInfo(model.ID, model.Reason, model.Status))
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
        public IActionResult DelectOutlayInfo(string OutlayId)
        {
            CustomActionResult res = new CustomActionResult();
            if (_outlayBll.DeleteSingleData(OutlayId))
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
