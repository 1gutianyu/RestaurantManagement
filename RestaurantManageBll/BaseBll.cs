using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManageBll
{
    public class BaseBll<T> where T:BaseEntity
    {
        //依赖注入
        private IBaseDal<T> _baseDal;
        public BaseBll(IBaseDal<T> baseDal)
        {
            _baseDal = baseDal;
        }

        /// <summary>
        /// 添加单条实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddSingleData(T entity)
        {
            return _baseDal.AddSingleData(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entityDatas"></param>
        /// <returns></returns>
        public bool AddDatas(List<T> entityDatas)
        {
            var count = _baseDal.AddDatas(entityDatas);
            return count > 0;
        }

        /// <summary>
        /// 硬删除单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteSingleData(string Id)
        {
            return _baseDal.DeleteSingleData(Id);
        }

        /// <summary>
        /// 批量硬删除
        /// </summary>
        /// <param name="Ids"></param>
        public void DeleteDatas(List<T> Ids)
        {
            _baseDal.DeleteDatas(Ids);
        }

        /// <summary>
        /// 更改单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateSingleData(T entity)
        {
            return _baseDal.UpdateSingleData(entity);
        }

        /// <summary>
        /// 根据Id获取单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetSingleEntityData(string Id)
        {
            return _baseDal.GetSingleEntityData(Id);
        }

        /// <summary>
        /// 获取数据集合  未筛选数据
        /// </summary>
        /// <returns></returns>
        public List<T> DataInfoList()
        {
            return _baseDal.GetEntityListDb().ToList();
        }

    }
}
