using IRestaurantManageBLL;
using Microsoft.AspNetCore.Mvc;
using RestaurantManageEntity;
using RestaurantManagement.Models;
using RestaurantManagement.Models.InventoryInfoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CanteenProject.Controllers
{
    /// <summary>
    /// 原料控制器
    /// </summary>
    public class InventoryInfoController : Controller
    {
        private IInventoryInfoBll _inventoryInfoBll;

        public InventoryInfoController(IInventoryInfoBll inventoryInfoBll)
        {
            _inventoryInfoBll = inventoryInfoBll;
        }
        /// <summary>
        /// 原料数据列表视图
        /// </summary>
        /// <returns></returns>
        public IActionResult InventoryInfoListView()
        {
            return View();
        }
        /// <summary>
        /// 添加原料页面
        /// </summary>
        /// <returns></returns>
       public IActionResult AddInventoryInfoView()
        {
            return View();
        }

        /// <summary>
        /// 添加原料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddInventoryInfo(AddInventoryInfoViewModel model)
        {
            CustomActionResult res = new CustomActionResult();

            if (string.IsNullOrEmpty(model.MaterialName))
            {
                res.Msg = "原料名不能为空";
                return Json(res);
            }
            bool had = _inventoryInfoBll.IsHadInventoryInfo(model.MaterialName);
            if (had)
            {
                res.Msg = "耗材名称已存在";
                return Json(res);
            }

            InventoryInfo entity = new InventoryInfo()
            {
                ID = Guid.NewGuid().ToString(),
                MaterialName = model.MaterialName,
                Unit = model.nuit,
                Price = model.price,
                Warning = model.Warning,
                Describtion = model.describe,
                CreateTime = DateTime.Now
            };
            bool isSuccess = _inventoryInfoBll.AddInventoryInfo(entity);
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
        /// 修改原料视图页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateInventoryInfoView()
        {
            return View();
        }
        /// <summary>
        /// 获取更新原料页面信息
        /// </summary>
        /// <param name="MaterialId"></param>
        /// <returns></returns>
        public IActionResult GetUpdateInventoryInfo(string MaterialId)
        {
            CustomActionResult res = new CustomActionResult();
            InventoryInfo inventoryInfo = _inventoryInfoBll.GetInventoryInfo(MaterialId);
            res.IsSuccess = true;
            res.Msg = "成功";
            res.Status = 1;
            res.Datas = inventoryInfo;

            return Json(res);            
        }

        /// <summary>
        /// 更新原料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateInventoryInfo(UpdateInventoryInfoViewModel model)
        {
            CustomActionResult res = new CustomActionResult();
            if (_inventoryInfoBll.UpdateInventoryInfo(model.ID, model.MaterialName, model.nuit, model.price, model.Warning, model.describe))
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
        /// 删除原料
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteInventoryInfo(string materialId)
        {
            CustomActionResult res = new CustomActionResult();
         
            if(_inventoryInfoBll.DeleteInventoryInfo(materialId))
            {
                res.Status = 1;
                res.IsSuccess = true;
                res.Msg = "成功";
                return Json(res);
            }
            else
            {
                res.Msg = "失败";
                return Json(res);
            }
        }
        /// <summary>
        /// 获取原料集合
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="materialName"></param>
        /// <returns></returns>
        public IActionResult GetInventoryInfoList(int page,int limit,string materialName)
        {
            int count;
            object inventoryInfos = _inventoryInfoBll.GetInventoryInfoListByPage(page, limit, out count , materialName);
            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = inventoryInfos
            });
        }
    }
}
