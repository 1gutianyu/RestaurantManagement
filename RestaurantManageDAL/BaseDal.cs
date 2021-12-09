using Microsoft.EntityFrameworkCore;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RestaurantManageDAL
{
    public class BaseDal<T> where T : BaseEntity
    {
        //数据库上下文
        ManegeDbContext _DbContext;
        public BaseDal(ManegeDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        #region 添加数据

        /// <summary>
        /// 添加单条实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddSingleData(T entity)
        {
            _DbContext.Set<T>().Add(entity);
            int index = _DbContext.SaveChanges();
            if (index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="addEntityDatas"></param>
        /// <returns></returns>
        public int AddDatas(List<T> addEntityDatas)
        {
            _DbContext.Set<T>().AddRange(addEntityDatas);
            return _DbContext.SaveChanges();
        }

        #endregion



        #region 删除

        /// <summary>
        /// 硬删除单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteSingleData(string Id)
        {
            T entity = _DbContext.Set<T>().FirstOrDefault(e => e.ID == Id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                _DbContext.Set<T>().Remove(entity);
                int index = _DbContext.SaveChanges();
                if (index > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 批量硬删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int DeleteDatas(List<T> Ids)
        {
            _DbContext.Set<T>().RemoveRange(Ids);
            return _DbContext.SaveChanges();
        }

        #endregion


        #region 更改数据

        /// <summary>
        /// 更改单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateSingleData(T entity)
        {
            //数据库查出来的实体
            T dbEntity = _DbContext.Set<T>().FirstOrDefault(u => u.ID == entity.ID);

            //反射
            Type type = entity.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();

            Type type2 = dbEntity.GetType();
            PropertyInfo[] propertyInfos2 = type.GetProperties();

            //循环遍历两个对象各个属性值，并将要修改的数据覆盖原数据
            foreach (PropertyInfo p1 in propertyInfos)
            {
                foreach (PropertyInfo p2 in propertyInfos2)
                {
                    if (p1.Name == p2.Name && p1.GetType() == p2.GetType())
                    {
                        //若是属性相等，便将p1的值赋给p2
                        p2.SetValue(dbEntity, p1.GetValue(entity));
                        break;
                    }
                }
            }

            int index = _DbContext.SaveChanges();
            if (index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量更改数据
        /// </summary>
        /// <param name="entityIds"></param>
        /// <returns></returns>
        public int UpdateDatas(List<T> Ids)
        {
            _DbContext.Set<T>().UpdateRange(Ids);
            return _DbContext.SaveChanges();
        }

        #endregion



        #region 获取数据

        /// <summary>
        /// 根据Id获取单条实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetSingleEntityData(string Id)
        {
            T entity = _DbContext.Set<T>().FirstOrDefault(e => e.ID == Id);
            return entity;
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetEntityListDb()
        {
            return _DbContext.Set<T>();
        }

        #endregion
    }
}
