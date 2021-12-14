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
    /// 点餐表控制器
    /// </summary>
    public class OrderInfoController : Controller
    {
        private IOrderBll _orderBll;
        public IMealBll _mealBll;

        public OrderInfoController(IOrderBll orderBll, IMealBll mealBll)
        {
            _orderBll = orderBll;
            _mealBll = mealBll;
        }

        /// <summary>
        /// 点餐表视图
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderLIstView()
        {
            return View();
        }

        /// <summary>
        /// 获取点餐数据和搜索功能
        /// </summary>
        /// <param name="JobId"></param>
        /// <param name="TableNumber"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IActionResult OrderLIst(string JobId, string TableNumber, int page, int limit)
        {
            int count;
            object Order = _orderBll.GetOrderInfoListByPage(JobId, TableNumber, page, limit, out count);
            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = Order
            });
        }

        /// <summary>
        /// 添加点餐视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddOrderView()
        {
            return View();
        }

        /// <summary>
        /// 添加点餐信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AddOrder(OrderInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (string.IsNullOrEmpty(model.DishesId))
            {
                res.Msg = "菜名不能为空";
                return Json(res);
            }
            else if (model.TotalMoney==0)
            {
                res.Msg = "金额不能为0";
                return Json(res);
            }
            else if (string.IsNullOrEmpty(model.TableNumber))
            {
                res.Msg = "请选择就餐餐桌";
                return Json(res);
            }

            //这里项目合并的时候要加一个默认获取当前员工Id的方法

            OrderInfo orderInfo = new OrderInfo()
            {
                ID = Guid.NewGuid().ToString(),
                DishesId = model.DishesId,
                TotalMoney = model.TotalMoney,
                PayMethod = model.PayMethod,
                CreateTime = DateTime.Now,
                JobId = "后期自动获取",//后期要改成自动获取，与上问题一致
                TableNumber = model.TableNumber
            };

            bool isSuccess = _orderBll.AddSingleData(orderInfo);
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
        /// 获取支付方式和餐桌下拉框数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetPaywayInfo()
        {
            CustomActionResult res = new CustomActionResult();
            //查询餐桌下拉选数据
            var meal = _mealBll.GetStatusSelectOption();
            //支付方式下拉框
           var orde= _orderBll.GetStatusSelectOption3();

            res.Datas = new {
                meal= meal,
                orde= orde
            };
            res.IsSuccess = true;
            res.Status = 1;
            return Json(res);
        }

        /// <summary>
        /// 修改点餐视图
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateOrderView()
        {
            return View();
        }
        
        /// <summary>
        /// 获取修改点餐数据信息
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateOrderInfo(string OrderId)
        {
            CustomActionResult res = new CustomActionResult();
            //获取点餐表信息
            OrderInfo orderInfo = _orderBll.GetSingleEntityData(OrderId);

            //查询餐桌下拉选数据
            var meal = _mealBll.GetStatusSelectOption();

            var orde = _orderBll.GetStatusSelectOption3();
            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = new
            {
                OrderInfo = orderInfo,
                meal = meal,
                orde = orde
            };
            return Json(res);
        }

        /// <summary>
        /// 更新点餐表
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateOrderInfo(OrderInfo model)
        {
            CustomActionResult res = new CustomActionResult();
            if (_orderBll.UpdateOrderInfo(model.ID,model.DishesId,model.TotalMoney,model.PayMethod,model.TableNumber))
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
        /// 删除点餐信息
        /// </summary>
        /// <returns></returns>
        public IActionResult DelectOrderInfo(string OrderId)
        {
            CustomActionResult res = new CustomActionResult();
            if (_orderBll.DeleteSingleData(OrderId))
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
