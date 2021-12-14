using IRestaurantManageDAL;
using RestaurantManageBll;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageBLL
{
    public class BaseDeleteBll<T> : BaseBll<T> where T : BaseDeleteEntity
    {
        private IBaseDal<T> _baseDal;
        public BaseDeleteBll(IBaseDal<T> baseDal) : base(baseDal)
        {
            _baseDal = baseDal;
        }

        /// <summary>
        /// 软删除单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool SoftDeleteSingleData(string Id)
        {
            T entity = _baseDal.GetSingleEntityData(Id);
            if (entity != null)
            {
                entity.IsDelete = true;
                entity.DeleteTime = DateTime.Now;
                return _baseDal.UpdateSingleData(entity);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量软删除数据
        /// </summary>
        /// <param name="Ids"></param>
        public void SoftDeleteDatas(List<string> Ids)
        {
            //获取实体数据集合
            var deleteDatas = _baseDal.GetEntityListDb().Where(de => Ids.Contains(de.ID)).ToList();
            DateTime deleteTime = DateTime.Now;
            foreach (var item in deleteDatas)
            {
                item.IsDelete = true;
                item.DeleteTime = deleteTime;
            }
            _baseDal.UpdateDatas(deleteDatas);
        }

        /// <summary>
        /// 获取下拉列表数据(有删除字段)
        /// </summary>
        /// <returns></returns>
        //public object GetDeleteSelectOptions()
        //{
        //    var entityDatas = _baseDal.GetEntityListDb().Where(e => !e.IsDelete).Select(e => new
        //    {
        //        e.ID,
        //        e.Name
        //    }).ToList();
        //    return entityDatas;
        //}
    }
}
