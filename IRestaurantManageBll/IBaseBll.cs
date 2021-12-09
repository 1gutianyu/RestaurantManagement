using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IBaseBll<T>
    {
        /// <summary>
        /// 添加单条实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool AddSingleData(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entityDatas"></param>
        /// <returns></returns>
        bool AddDatas(List<T> entityDatas);

        /// <summary>
        /// 硬删除单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteSingleData(string Id);

        /// <summary>
        /// 批量硬删除
        /// </summary>
        /// <param name="Ids"></param>
        void DeleteDatas(List<T> Ids);

        /// <summary>
        /// 更改单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateSingleData(T entity);

        /// <summary>
        /// 根据Id获取单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetSingleEntityData(string Id);


    }
}
