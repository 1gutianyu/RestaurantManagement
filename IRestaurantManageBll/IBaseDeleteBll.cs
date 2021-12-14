using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IBaseDeleteBll<T> : IBaseBll<T>
    {
        /// <summary>
        /// 软删除单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool SoftDeleteSingleData(string Id);

        /// <summary>
        /// 批量软删除数据
        /// </summary>
        /// <param name="Ids"></param>
        void SoftDeleteDatas(List<string> Ids);

        /// <summary>
        /// 获取下拉列表数据(有删除字段)
        /// </summary>
        /// <returns></returns>
        //object GetDeleteSelectOptions();
    }
}
