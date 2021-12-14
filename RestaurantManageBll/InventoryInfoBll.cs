using IRestaurantManageBLL;
using IRestaurantManageDAL;
using RestaurantManageBLL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenBLL
{
    public class InventoryInfoBll : BaseDeleteBll<InventoryInfo>,IInventoryInfoBll
    {
        private IInventoryInfoDal _inventoryInfoDal;


        public InventoryInfoBll(IInventoryInfoDal inventoryInfoDal):base(inventoryInfoDal)
        {
            _inventoryInfoDal = inventoryInfoDal;
        }
        /// <summary>
        /// 添加原料信息
        /// </summary>
        /// <param name="inventoryInfo"></param>
        /// <returns></returns>
       public bool AddInventoryInfo(InventoryInfo inventoryInfo)
        {
            return _inventoryInfoDal.AddSingleData(inventoryInfo);
        }
        /// <summary>
        /// 删除原料信息
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public bool DeleteInventoryInfo(string materialId)
        {
            return _inventoryInfoDal.DeleteSingleData(materialId);
        }
        /// <summary>
        /// 根据ID获取原料信息
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
       public InventoryInfo GetInventoryInfo(string materialId)
        {
            return _inventoryInfoDal.GetSingleEntityData(materialId);
        }
        /// <summary>
        /// 分页获取数据集合
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="materialName"></param>
        /// <returns></returns>
        public object GetInventoryInfoListByPage(int page,int limit,out int count,string materialName)
        {
            var inventoryInfos = _inventoryInfoDal.GetEntityListDb().Where(u => u.IsDelete == false);

            if (!string.IsNullOrEmpty(materialName))
            {
                inventoryInfos = inventoryInfos.Where(u => u.MaterialName.Contains(materialName));
            }

            count = inventoryInfos.Count();

            var allInventoryInfos = _inventoryInfoDal.GetEntityListDb().Where(u => u.IsDelete == false);

            var res = inventoryInfos.OrderBy(d => d.CreateTime).Skip((page - 1) * limit).Take(limit).ToList().Select(u =>
            {
                return new
                {
                    u.ID,
                    u.MaterialName,
                    u.Number,
                    u.Unit,
                    u.Price,
                    u.Warning,
                    u.Describtion,
                    CreateTime = u.CreateTime.ToString("yyy-MM-dd HH:mm:ss")
                };
            });
            return res;
        }

      public bool UpdateInventoryInfo(InventoryInfo inventoryInfo)
        {
            return _inventoryInfoDal.UpdateSingleData(inventoryInfo);
        }
        /// <summary>
        /// 判断是否有重复的原料名称
        /// </summary>
        /// <param name="materialName"></param>
        /// <returns></returns>
        public bool IsHadInventoryInfo(string materialName)
        {
            return _inventoryInfoDal.GetEntityListDb().Where(c => c.IsDelete && c.MaterialName == materialName).Count() > 0;
        }
        /// <summary>
        /// 更新耗材信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="materialName"></param>
        /// <param name="nuit"></param>
        /// <param name="price"></param>
        /// <param name="Warning"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
       public  bool UpdateInventoryInfo(string id, string materialName, string nuit, decimal price, int Warning, string describr)
        {
            InventoryInfo inventoryInfo = _inventoryInfoDal.GetSingleEntityData(id);
            if (inventoryInfo != null)
            {
                inventoryInfo.MaterialName = materialName;
                inventoryInfo.Unit = nuit;
                inventoryInfo.Price = price;
                inventoryInfo.Warning = Warning;
                inventoryInfo.Describtion = describr;
                return _inventoryInfoDal.UpdateSingleData(inventoryInfo);
            }
            else
            {
                return false;
            }
        }
    }
}
