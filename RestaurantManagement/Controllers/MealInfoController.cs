using IRestaurantManageBLL;
using Microsoft.AspNetCore.Mvc;
using RestaurantManageEntity;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    /// <summary>
    /// 餐桌表控制器
    /// </summary>
    public class MealInfoController : Controller
    {
        private IMealBll _mealBll;

        public MealInfoController(IMealBll mealBll)
        {
            _mealBll = mealBll;
        }

        /// <summary>
        /// 支付方式视图
        /// </summary>
        /// <returns></returns>
        public IActionResult MealInfoListView()
        {
            return View();
        }

        public IActionResult MealInfoList(int page, int limit)
        {
            int count;
            object Order = _mealBll.GetMealInfoListByPage(page, limit, out count);
            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = Order
            });
        }

        /// <summary>
        /// 支付方式视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddMealInfoView()
        {
            return View();
        }

        public IActionResult AddMealInfo(MealInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (string.IsNullOrEmpty(model.TableName))
            {
                res.Msg = "餐桌号不能为空";
                return Json(res);
            }

            MealInfo mealInfo = new MealInfo()
            {
                ID = Guid.NewGuid().ToString(),
                TableName = model.TableName,
            };

            bool isSuccess = _mealBll.AddSingleData(mealInfo);
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
        public IActionResult UpdateMealInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取支付方式数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateMealInfo(string MealId)
        {
            CustomActionResult res = new CustomActionResult();
            //获取点餐表信息
            MealInfo mealInfo = _mealBll.GetSingleEntityData(MealId);

            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = mealInfo;
            return Json(res);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateMealInfo(MealInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (_mealBll.UpdateOrderInfo(model.ID, model.TableName))
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
        /// 删除支付方式
        /// </summary>
        /// <returns></returns>
        public IActionResult DelectMealInfo(string MealId)
        {
            CustomActionResult res = new CustomActionResult();
            if (_mealBll.DeleteSingleData(MealId))
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
