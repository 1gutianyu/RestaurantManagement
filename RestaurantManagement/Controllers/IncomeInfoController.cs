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
    /// 收入管理表控制器
    /// </summary>
    public class IncomeInfoController : Controller
    {
        private IIncomeBll _incomeBll;

        public IncomeInfoController(IIncomeBll incomeBll)
        {
            _incomeBll = incomeBll;
        }
        /// <summary>
        /// 收入管理表视图
        /// </summary>
        /// <returns></returns>
        public IActionResult IncomeInfoListView()
        {
            return View();
        }

        public IActionResult IncomeInfoList(int page, int limit)
        {
            int count;
            object Order = _incomeBll.GetIncomeInfoListByPage(page, limit, out count);
            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = Order
            });
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddIncomeInfoView()
        {
            return View();
        }

        public IActionResult AddIncomeInfo(IncomeInfo model)
        {
            CustomActionResult res = new CustomActionResult();


            IncomeInfo incomeInfo = new IncomeInfo()
            {
                ID = Guid.NewGuid().ToString(),
                OrderId="从点餐表获取",
                PutMoney=model.PutMoney,
                JobId= "后期自动获取",
                CreateTime =DateTime.Now
            };

            bool isSuccess = _incomeBll.AddSingleData(incomeInfo);
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
        public IActionResult UpdateIncomeInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateIncomeInfo(string IncomeId)
        {
            CustomActionResult res = new CustomActionResult();
            //获取信息
            IncomeInfo incomeInfo = _incomeBll.GetSingleEntityData(IncomeId);

            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = incomeInfo;
            return Json(res);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateIncomeInfo(IncomeInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (_incomeBll.UpdateIncomeInfo(model.ID, model.PutMoney))
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
        public IActionResult DelectIncomeInfo(string IncomeId)
        {
            CustomActionResult res = new CustomActionResult();
            if (_incomeBll.DeleteSingleData(IncomeId))
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
