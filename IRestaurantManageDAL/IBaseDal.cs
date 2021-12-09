using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace IRestaurantManageDAL
{
    public interface IBaseDal<T> where T : class
    {
        #region 添加数据

        /// <summary>
        /// 添加单条实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool AddSingleData(T entity);

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="addEntityDatas"></param>
        /// <returns></returns>
        int AddDatas(List<T> addEntityDatas);

        #endregion



        #region 删除

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
        /// <returns></returns>
        int DeleteDatas(List<T> Ids);

        #endregion


        #region 更改数据

        /// <summary>
        /// 更改单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateSingleData(T entity);

        /// <summary>
        /// 批量更改数据
        /// </summary>
        /// <param name="entityIds"></param>
        /// <returns></returns>
        int UpdateDatas(List<T> Ids);

        #endregion



        #region 获取数据

        /// <summary>
        /// 根据Id获取单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetSingleEntityData(string Id);


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetEntityListDb();

        #endregion
    }
}
