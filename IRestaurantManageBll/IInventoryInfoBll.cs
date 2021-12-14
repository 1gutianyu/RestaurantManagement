using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    /// <summary>
    /// 原料信息业务访问层接口
    /// </summary>
   public  interface IInventoryInfoBll:IBaseDeleteBll<InventoryInfo>
    {
        /// <summary>
        /// 添加原料信息
        /// </summary>
        /// <param name="inventoryInfo"></param>
        /// <returns></returns>
        bool AddInventoryInfo(InventoryInfo inventoryInfo);
        /// <summary>
        /// 删除原料信息
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        bool DeleteInventoryInfo(string materialId);
        /// <summary>
        /// 更新原料信息
        /// </summary>
        /// <param name="inventoryInfo"></param>
        /// <returns></returns>
        bool UpdateInventoryInfo(InventoryInfo inventoryInfo);
        /// <summary>
        /// 根据ID获取原料信息
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        InventoryInfo GetInventoryInfo(string materialId);

        /// <summary>
        /// 分页获取原料信息集合
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="materialName"></param>
        /// <returns></returns>
        object GetInventoryInfoListByPage(int page, int limit, out int count, string materialName);

        /// <summary>
        /// 判断是否有重复得原料名称
        /// </summary>
        /// <param name="materialName"></param>
        /// <returns></returns>
        bool IsHadInventoryInfo(string materialName);

        bool UpdateInventoryInfo(string id,string materialName, string nuit, decimal price, int  Warning,string describe);
    }
}
